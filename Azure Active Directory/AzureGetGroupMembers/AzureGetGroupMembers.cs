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
    public class AzureGetGroupMembers : IActivity
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
        /// Group to get information
        /// </summary>
        public string groupId;

        public ICustomActivityResult Execute()
        {
            var auth = GetAuthenticated();
            var group = auth.ActiveDirectoryGroups.List().Where(x => x.Id == groupId).FirstOrDefault();

            if (group != null)
            {
                DataTable dt = new DataTable("resultSet");
                dt.Columns.Add("Id");
                dt.Columns.Add("Type");
                dt.Columns.Add("Member Name");
                dt.Columns.Add("Member Details");
                var members = group.ListMembers().ToList();

                members.ForEach(m =>
                {
                    var user = auth.ActiveDirectoryUsers.List().Where(u => u.Id == m.Id).FirstOrDefault();
                    dt.Rows.Add(m.Id, user != null ? "User" : "Role", m.Name, user != null ? user.UserPrincipalName : "");
                });                

                return this.GenerateActivityResult(dt);
            }
            else throw new Exception(string.Format("Group with Id={0} not found", groupId));
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
