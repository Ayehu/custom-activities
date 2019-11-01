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
    public class AzureADRemoveGroupMember : IActivity
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
        /// Group name to containing member
        /// </summary>
        public string groupName;

        /// <summary>
        /// The group member to remove
        /// </summary>
        public string memberId;

        public ICustomActivityResult Execute()
        {
            var auth = GetAuthenticated();
            var adGroup = auth.ActiveDirectoryGroups.List().Where(x => x.Name.ToLower() == groupName.ToLower()).FirstOrDefault();

            if (adGroup == null)
                throw new Exception(string.Format("Group with name '{0} not found'", groupName));

            var adGroupMembers = adGroup.ListMembers();
            var member = adGroupMembers.Where(m => m.Id == memberId).FirstOrDefault();

            if (member != null)
                adGroup.Update().WithoutMember(member.Id).Apply();
            else
                throw new Exception(string.Format("Group member with id '{0}' not found", memberId));

            return this.GenerateActivityResult(GetActivityResult);
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

        private DataTable GetActivityResult
        {
            get
            {
                DataTable dt = new DataTable("resultSet");
                dt.Columns.Add("Result");
                dt.Rows.Add("Success");

                return dt;
            }
        }
    }
}
