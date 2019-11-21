using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using System.Collections.Generic;

namespace ActivitiesAyehu
{
    public class GSuiteResetPassword : IActivity
    {
        public string ServiceAccountEmail, PrivateKey, AdminUser;

        public string UserEmail, NewPassword;

        public ICustomActivityResult Execute()
        {
            var result = ResetPassword();

            return this.GenerateActivityResult(result);
        }

        private string ResetPassword()
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
                ApplicationName = "GSuiteUpdatePassword"
            };

            var t = new DirectoryService(cs);

            var request = t.Users.Update(new User
            {
                Password = NewPassword
            }, UserEmail);

            var res  = request.Execute();

            return "Success";
        }
    }
}
