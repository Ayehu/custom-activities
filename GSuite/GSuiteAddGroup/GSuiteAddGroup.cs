using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using System.Collections.Generic;

namespace ActivitiesAyehu
{
    public class GSuiteAddGroup : IActivity
    {
        public string ServiceAccountEmail, PrivateKey, UserId;

        public string GroupEmail, GroupName;

        public ICustomActivityResult Execute()
        {
            var result = AddGroup();

            return this.GenerateActivityResult(result);
        }

        private string AddGroup()
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
                ApplicationName = "GSuiteAddGroup"
            };

            var t = new DirectoryService(cs);

            var request = t.Groups.Insert(new Group
            {
                Email = GroupEmail,
                Name = GroupName
            });

            request.Execute();

            return "Success";
        }
    }
}
