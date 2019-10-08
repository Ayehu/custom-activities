using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.Compute.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Compute.v1.Data;
using System.Threading.Tasks;
using System.Text;

namespace ActivitiesAyehu
{
    public class GCloudLaunchInstance : IActivity
    {
        public string Project;
        public string InstanceName;
        public string Zone;
        public string Region;
        public string MachineType;
        public string PrivateKey;
        public string ServiceAccountEmail;
        public string DiskSourceImage;


        public ICustomActivityResult Execute()
        {
            var result = InsertInstance();

            return this.GenerateActivityResult(result.Result);
        }

        private async Task<string> InsertInstance()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   Scopes = new[] { ComputeService.Scope.Compute, ComputeService.Scope.CloudPlatform }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GCloud Launch Instance"
            };

            var t = new ComputeService(cs);

            var niList = new List<NetworkInterface>() { new NetworkInterface() };

            var diskList = new List<AttachedDisk>()
            {
                new AttachedDisk()
                {
                    Boot = true,
                    InitializeParams = new AttachedDiskInitializeParams() { SourceImage = DiskSourceImage }
                }
            };

            var zoneRegion = Region + "-" + Zone;

            var instance = new Instance()
            {
                MachineType = string.Format("zones/{0}/machineTypes/{1}", zoneRegion, MachineType),
                Name = InstanceName,
                NetworkInterfaces = niList,
                Disks = diskList
            };

            var insertRequest = t.Instances.Insert(instance, Project, zoneRegion);

            var response = insertRequest.Execute();

            if (response.HttpErrorStatusCode != null)
            {
                var errorStr = new StringBuilder();
                foreach (var error in response.Error.Errors)
                    errorStr.AppendLine(error.Code + " - " + error.Message);
                return errorStr.ToString();
            }
            else return "Success";
        }
    }
}
