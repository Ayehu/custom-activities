using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureADCreateRoleAssignment : IActivity
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
        public string secretpassword;

        /// <summary>
        /// The azure portal subscription Id (Free Trial/Premium)
        /// </summary>
        public string subscriptionId;

        /// <summary>
        /// The name of a security group or an ActiveDirectory user email.
        /// </summary>
        public string objectName;

        public string roleNameId;
        public string roleName;

        public ICustomActivityResult Execute()
        {
            var auth = GetAuthenticated();
            IActiveDirectoryObject ADObject = auth.ActiveDirectoryUsers.GetByName(objectName);

            if (ADObject == null)
                ADObject = auth.ActiveDirectoryGroups.GetByName(roleNameId);
            
            if (ADObject == null)
                throw new Exception(string.Format("Active Directory object '{0}' not found.", objectName));

            var role = auth.RoleAssignments.
                Define(Guid.NewGuid().ToString()).ForObjectId(ADObject.Id).
                WithBuiltInRole(this.GetRole(roleNameId)).
                WithSubscriptionScope(subscriptionId).Create();

            return this.GenerateActivityResult(GetActivityResult(role.Id));
        }

        private Azure.IAuthenticated GetAuthenticated()
        {
            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(appId, secretpassword, tenantId, AzureEnvironment.AzureGlobalCloud);
            var azure = Azure
                   .Configure()
                   .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                   .Authenticate(credentials);

            return azure;
        }

        private DataTable GetActivityResult(string roleId)
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");
            dt.Rows.Add(roleId);

            return dt;
        }

        private BuiltInRole GetRole(string roleName)
        {
            var fields = typeof(BuiltInRole).GetFields();
            var field = fields.Where(x => x.Name.ToLower() == roleName.ToLower()).FirstOrDefault();
            return field.GetValue(null) as BuiltInRole;
        }
    }
}
