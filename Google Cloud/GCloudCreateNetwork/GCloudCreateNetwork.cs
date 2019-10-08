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
    public class GCloudCreateNetwork : IActivity
    {
        public string Project;
        public string NetworkName;
        public string RoutingMode;
        public string PrivateKey;
        public string ServiceAccountEmail;


        public ICustomActivityResult Execute()
        {
            var result = CreateNetwork();

            return this.GenerateActivityResult(result.Result);
        }

        private async Task<string> CreateNetwork()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   Scopes = new[] { ComputeService.Scope.Compute, ComputeService.Scope.CloudPlatform }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GCloud Create Network"
            };

            var t = new ComputeService(cs);

            var network = new Network
            {
                Name = NetworkName,
                RoutingConfig = new NetworkRoutingConfig
                {
                    RoutingMode = RoutingMode
                }
            };

            var request = t.Networks.Insert(network, Project);

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
