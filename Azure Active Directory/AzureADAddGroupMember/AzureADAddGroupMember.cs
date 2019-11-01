using System;
using System.Data;
using System.Linq;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADAddGroupMember : IActivity
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
        /// Group name to add a member
        /// </summary>
        public string groupName;

        /// <summary>
        /// User's email to add to the group
        /// </summary>
        public string userEmail;

        /// <summary>
        /// Role id to add to the group
        /// </summary>
        public string roleId;

        public ICustomActivityResult Execute()
        {
            var auth = GetAuthenticated();
            var adGroup = auth.ActiveDirectoryGroups.List().Where(x => x.Name.ToLower() == groupName.ToLower()).FirstOrDefault();

            if (adGroup == null)
                throw new Exception(string.Format("Group with name '{0} not found'", groupName));

            if (!string.IsNullOrEmpty(userEmail))
            {
                var users = auth.ActiveDirectoryUsers.List();
                var user = auth.ActiveDirectoryUsers.List().Where(u => u.UserPrincipalName.ToLower() == userEmail.ToLower()).FirstOrDefault();

                if (user != null && !string.IsNullOrEmpty(user.UserPrincipalName))
                    AddMemeber(adGroup, user);
                else
                    throw new Exception(string.Format("User with email '{0}' not found", userEmail));
            }
            else if (!string.IsNullOrEmpty(roleId))
            {
                var sp = auth.ServicePrincipals.List().Where(r => r.Id == roleId).FirstOrDefault();

                if (sp != null)
                    AddMemeber(adGroup, sp);
                else
                    throw new Exception(string.Format("Role with Id '{0}' not found", roleId));
            }
            else
            {
                throw new Exception("You need to provide either a server role or a user");
            }

            return this.GenerateActivityResult(GetActivityResult);
        }


        private void AddMemeber(IActiveDirectoryGroup adGroup, IActiveDirectoryObject obj)
        {
            var adGroupMembers = adGroup.ListMembers();
            var member = adGroupMembers.Where(m => m.Id == obj.Id).FirstOrDefault();

            if (member == null)
                adGroup.Update().WithMember(obj.Id).Apply();
            else
                throw new Exception("Member already exist in this group");
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
