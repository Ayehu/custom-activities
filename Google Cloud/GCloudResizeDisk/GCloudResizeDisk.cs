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
using System.Data;

namespace ActivitiesAyehu
{
    public class GCloudResizeDisk : IActivity
    {
        public string Project;
        public string DiskName;
        public string NewSize;
        public string Region;
        public string Zone;
        public string PrivateKey;
        public string ServiceAccountEmail;


        public ICustomActivityResult Execute()
        {
            var result = ResizeDisk();

            return this.GenerateActivityResult(result.Result);
        }

        private async Task<string> ResizeDisk()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   Scopes = new[] { ComputeService.Scope.Compute, ComputeService.Scope.CloudPlatform }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GCloud Resize Disk"
            };

            var t = new ComputeService(cs);

            var drr = new DisksResizeRequest
            {
                SizeGb = long.Parse(NewSize)
            };

            var request = t.Disks.Resize(drr, Project, Region + "-" + Zone, DiskName);

            var response = request.Execute();

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
