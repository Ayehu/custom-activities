using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System.IO;

namespace ActivitiesAyehu
{
    public class GDriveGetFile : IActivity
    {
        public string ServiceAccountEmail, PrivateKey, UserId;

        public string FileId, FilePath;

        public ICustomActivityResult Execute()
        {
            var result = GetFile();

            return this.GenerateActivityResult(result);
        }

        private string GetFile()
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

            if (!File.Exists(FilePath))
            {
                var file = File.Create(FilePath);
                file.Close();
            }
            using (FileStream fileStream = new FileStream(FilePath, FileMode.Open))
            {
                var request = t.Files.Get(FileId);

                request.Download(fileStream);
            }

            return "Success";
        }
    }
}
