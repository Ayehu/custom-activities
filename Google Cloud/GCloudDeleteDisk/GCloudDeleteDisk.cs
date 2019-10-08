using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Services;
using Google.Apis.Compute.v1;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;
using System.Text;

namespace ActivitiesAyehu
{
    public class GCloudDeleteDisk : IActivity
    {
        public string Project;
        public string DiskName;
        public string Region;
        public string Zone;
        public string PrivateKey;
        public string ServiceAccountEmail;


        public ICustomActivityResult Execute()
        {
            var result = DeleteDisk();

            return this.GenerateActivityResult(result.Result);
        }

        private async Task<string> DeleteDisk()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   Scopes = new[] { ComputeService.Scope.Compute, ComputeService.Scope.CloudPlatform }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GCloud Delete Disk"
            };

            var t = new ComputeService(cs);

            var request = t.Disks.Delete(Project, Region + "-" + Zone, DiskName);

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
