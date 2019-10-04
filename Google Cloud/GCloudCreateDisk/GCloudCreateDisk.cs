using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Services;
using Google.Apis.Compute.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Compute.v1.Data;
using System.Threading.Tasks;
using System.Text;

namespace ActivitiesAyehu
{
    public class GCloudCreateDisk : IActivity
    {
        public string SourceImage;
        public string Type;
        public string SizeGb;
        public string DiskName;
        public string Zone;
        public string Region;
        public string Project;
        public string PrivateKey;
        public string ServiceAccountEmail;


        public ICustomActivityResult Execute()
        {
            var result = CreateDisk();

            return this.GenerateActivityResult(result.Result);
        }

        private async Task<string> CreateDisk()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   Scopes = new[] { ComputeService.Scope.Compute, ComputeService.Scope.CloudPlatform }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GCloud Create Disk"
            };

            var t = new ComputeService(cs);

            var disk = new Disk()
            {
                Name = DiskName,
                SourceImage = SourceImage,
                Type = Type,
                SizeGb = long.Parse(SizeGb)
            };

            var request = t.Disks.Insert(disk, Project, Region + "-" + Zone);

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
