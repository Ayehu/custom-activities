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
    public class GCloudCreateSnapshot : IActivity
    {
        public string SourceDisk;
        public string SnapshotName;
        public string Project;
        public string Zone;
        public string Region;
        public string PrivateKey;
        public string ServiceAccountEmail;


        public ICustomActivityResult Execute()
        {
            var result = CreateSnapshot();

            return this.GenerateActivityResult(result.Result);
        }

        private async Task<string> CreateSnapshot()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   Scopes = new[] { ComputeService.Scope.Compute, ComputeService.Scope.CloudPlatform }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GCloud Create Snapshot"
            };

            var t = new ComputeService(cs);

            var snapshot = new Snapshot()
            {
                Name = SnapshotName
            };

            var request = t.Disks.CreateSnapshot(snapshot, Project, Region + "-" + Zone, SourceDisk);

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
