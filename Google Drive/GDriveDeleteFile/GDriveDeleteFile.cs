using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System.IO;
using System.Web;
using System.Collections.Generic;

namespace ActivitiesAyehu
{
    public class GDriveDeleteFile : IActivity
    {
        public string ServiceAccountEmail, UserId, PrivateKey;

        public string FileId;

        public ICustomActivityResult Execute()
        {
            var result = DeleteFile();

            return this.GenerateActivityResult(result);
        }

        private string DeleteFile()
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
                ApplicationName = "GDriveDeleteFile"
            };

            var t = new DriveService(cs);

            var request = t.Files.Delete(FileId);

            var res = request.Execute();
            
            return "Success";
        }
    }
}
