using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Services;
using Google.Apis.Compute.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Compute.v1.Data;
using System;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ActivitiesAyehu
{
    public class GCloudGetDisk : IActivity
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

            JObject jsonResults = JObject.Parse(result.Result);

            DataTable dt = new DataTable("resultSet");

            dt.Rows.Add(dt.NewRow());

            foreach(JProperty property in jsonResults.Properties())
            {
                dt.Columns.Add(property.Name);
                
                dt.Rows[0][property.Name] = property.Value;
            }

            return this.GenerateActivityResult(dt);
        }

        private async Task<string> ResizeDisk()
        {
            try
            {
                ServiceAccountCredential credential = new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(ServiceAccountEmail)
                   {
                       Scopes = new[] { ComputeService.Scope.Compute, ComputeService.Scope.CloudPlatform }
                   }.FromPrivateKey(PrivateKey));

                var cs = new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "GCloud Get Disk"
                };

                var t = new ComputeService(cs);

                var request = t.Disks.Get(Project, Region + "-" + Zone, DiskName);

                var response = await request.ExecuteAsync();

                return JsonConvert.SerializeObject(response);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}