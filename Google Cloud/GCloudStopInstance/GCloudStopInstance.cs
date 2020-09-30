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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ActivitiesAyehu
{
    public class GCloudStopInstance : IActivity
    {
        public string Project;
        public string InstanceName;
        public string Zone;
        public string Region;
        public string PrivateKey;
        public string ServiceAccountEmail;


        public ICustomActivityResult Execute()
        {
            var result = StopInstance();

            return this.GenerateActivityResult(result.Result);
        }

        private async Task<string> StopInstance()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   Scopes = new[] { ComputeService.Scope.Compute, ComputeService.Scope.CloudPlatform }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GCloud Stop Instance"
            };

            var t = new ComputeService(cs);

            var zoneRegion = Region + "-" + Zone;

            var insertRequest = t.Instances.Stop(Project, zoneRegion, InstanceName);

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
