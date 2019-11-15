using System;
using System.Data;
using System.Linq;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADCreateGroup : IActivity
    {
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
        /// Display name of the group
        /// </summary>
        public string groupName;

       public ICustomActivityResult Execute()
        {
            var auth = GetAuthenticated();
            var existingGroup = auth.ActiveDirectoryGroups.List().ToList().Where(x => x.Name.ToLower() == groupName.ToLower()).FirstOrDefault();
            Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryGroup newGroup;

            if (existingGroup == null)
            {
                newGroup = auth.ActiveDirectoryGroups.
                    Define(groupName).
                    WithEmailAlias(groupName).Create();
            }
            else
                throw new Exception(string.Format("Group with name '{0}' already exist.", groupName));

            return this.GenerateActivityResult(GetActivityResult(newGroup.Id));
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

        private DataTable GetActivityResult(string groupId)
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");
            dt.Rows.Add(groupId);

            return dt;
        }
    }
}
