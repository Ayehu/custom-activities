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
    public class GDriveCopyFile : IActivity
    {
        public string ServiceAccountEmail, PrivateKey, UserId;

        public string FileId, ParentID, Name;

        public ICustomActivityResult Execute()
        {
            var result = CopyFile();

            return this.GenerateActivityResult(result);
        }

        private string CopyFile()
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
                ApplicationName = "GDriveUploadFile"
            };

            var t = new DriveService(cs);

            var request = t.Files.Copy(new Google.Apis.Drive.v3.Data.File()
            {
                Name = Name,
                Parents = new List<string> { ParentID }
            }, FileId);

            var prog = request.Execute();

            return "Success";
        }
    }
}
