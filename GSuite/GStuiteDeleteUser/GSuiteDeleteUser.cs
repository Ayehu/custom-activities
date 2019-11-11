using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using System.Collections.Generic;

namespace ActivitiesAyehu
{
    public class GSuiteDeleteUser : IActivity
    {
        public string ServiceAccountEmail, PrivateKey, UserId;

        public string PrimaryEmail;

        public ICustomActivityResult Execute()
        {
            var result = DeleteUser();

            return this.GenerateActivityResult(result);
        }

        private string DeleteUser()
        {
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(ServiceAccountEmail)
               {
                   User = UserId,
                   Scopes = new[] { DirectoryService.Scope.AdminDirectoryUser, DirectoryService.Scope.AdminDirectoryGroup }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GSuiteDeleteUser"
            };

            var t = new DirectoryService(cs);

            var request = t.Users.Delete(PrimaryEmail);

            request.Execute();

            return "Success";
        }
    }
}
