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
        public string ServiceAccountEmail, PrivateKey, AdminUser;

        public string UserEmail;

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
                   User = AdminUser,
                   Scopes = new[] { DirectoryService.Scope.AdminDirectoryUser, DirectoryService.Scope.AdminDirectoryGroup }
               }.FromPrivateKey(PrivateKey));

            var cs = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GSuiteDeleteUser"
            };

            var t = new DirectoryService(cs);

            var request = t.Users.Delete(UserEmail);

            request.Execute();

            return "Success";
        }
    }
}
