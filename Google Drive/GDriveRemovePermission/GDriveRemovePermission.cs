using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System.Linq;

namespace ActivitiesAyehu
{
    public class GDriveRemovePermission : IActivity
    {
        public string ServiceAccountEmail, PrivateKey, UserId;

        public string FileId, PermissionId;

        public ICustomActivityResult Execute()
        {
            var result = RemovePermission();

            return this.GenerateActivityResult(result);
        }

        private string RemovePermission()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   User = UserId,
                   Scopes = new[] { DriveService.Scope.Drive }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GDriveRemovePermission"
            };

            var t = new DriveService(cs);

            var listReq = t.Permissions.List(FileId);
            listReq.Fields = "permissions(id,emailAddress)";
            var permissionList = listReq.Execute();
            var perm = permissionList.Permissions.First(p => p.EmailAddress == PermissionId);

            var request = t.Permissions.Delete(FileId, perm.Id);

            var prog = request.Execute();

            return "Success";
        }
    }
}
