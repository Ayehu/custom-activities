using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Services;
using Google.Apis.Compute.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Compute.v1.Data;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace ActivitiesAyehu
{
    public class GCloudListSnapshot : IActivity
    {
        public string Project;
        public string PrivateKey;
        public string ServiceAccountEmail;


        public ICustomActivityResult Execute()
        {
            var result = ListSnapshots();

            var dataTable = new DataTable("Image List", "ImageList");
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Disk size (Gb)");
            dataTable.Columns.Add("Kind");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Storage Bytes");
            dataTable.Columns.Add("Status");
            foreach (var img in result.Result)
                dataTable.Rows.Add(img.Id, img.Name, img.DiskSizeGb, img.Kind,
                    img.Description, img.StorageBytes, img.Status);

            return this.GenerateActivityResult(dataTable);
        }

        private async Task<IList<Snapshot>> ListSnapshots()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   Scopes = new[] { ComputeService.Scope.Compute, ComputeService.Scope.CloudPlatform }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GCloud List Snapshots"
            };

            var t = new ComputeService(cs);

            var request = t.Snapshots.List(Project);

            var response = request.Execute();

            return response.Items;
        }
    }
}
