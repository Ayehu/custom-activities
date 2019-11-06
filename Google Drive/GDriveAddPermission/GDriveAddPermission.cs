using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Drive.v3.Data;

namespace ActivitiesAyehu
{
    public class GDriveAddPermission : IActivity
    {
        public string ServiceAccountEmail, PrivateKey, UserId;

        public string FileId, EmailToAllow, Role;

        public ICustomActivityResult Execute()
        {
            var result = AddPermission();

            return this.GenerateActivityResult(result);
        }

        private string AddPermission()
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
                ApplicationName = "GDriveAddPermission"
            };

            var t = new DriveService(cs);

            var request = t.Permissions.Create(new Permission
            {
                EmailAddress = EmailToAllow,
                Type = "user",
                Role = Role
            }, FileId);

            var prog = request.Execute();

            return "Success";
        }
    }
}
