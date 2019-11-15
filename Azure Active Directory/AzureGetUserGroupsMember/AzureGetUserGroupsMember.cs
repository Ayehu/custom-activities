using System;
using System.Data;
using System.Linq;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureGetUserGroupsMember : IActivity
    {
        /// <summary>
        /// APPLICATION (CLIENT) ID
        /// </summary>
        public string appId;

        /// <summary>
        /// Directory (tenant) ID
        /// </summary>
        public string tenantId;

        /// <summary>
        /// Client secret
        /// </summary>
        /// <remarks>
        /// A secret string that the application uses to prove its identity when requesting a token. 
        /// Also can be referred to as application password.
        /// </remarks>
        public string secret;

        /// <summary>
        /// User's email/userId to get information
        /// </summary>
        public string userId;


        public ICustomActivityResult Execute()
        {
            var auth = GetAuthenticated();
            var user = auth.ActiveDirectoryUsers.List().Where(u => u.Id == userId || u.UserPrincipalName.ToLower() == userId.Trim().ToLower()).FirstOrDefault();

            if (user != null)
            {
                DataTable dt = new DataTable("resultSet");
                dt.Columns.Add("Id");
                dt.Columns.Add("Group Name");

                auth.ActiveDirectoryGroups.List().ToList().ForEach(g =>
                {
                    bool found = g.ListMembers().Where(m => m.Id == user.Id).FirstOrDefault() != null;

                    if (found)
                    {
                        dt.Rows.Add(g.Id, g.Name);
                    }
                });

                return this.GenerateActivityResult(dt);
            }
            else
                throw new Exception(string.Format("User with id='{0}' not found", userId));
        }

        private Azure.IAuthenticated GetAuthenticated()
        {
            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(appId, secret, tenantId, AzureEnvironment.AzureGlobalCloud);
            var azure = Azure
                   .Configure()
                   .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                   .Authenticate(credentials);

            return azure;
        }
    }
}
