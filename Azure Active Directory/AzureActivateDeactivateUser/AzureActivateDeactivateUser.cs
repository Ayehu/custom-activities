using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Ayehu.Sdk.ActivityCreation
{
    /// <summary>
    /// Activate or Deactivate an ActiveDirectory user
    /// </summary>
    public class AzureActivateDeactivateUser : IActivity
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

        public string acctState;
        public string isEnabled;

        /// <summary>
        /// The user id or email
        /// </summary>
        public string userId;

        public ICustomActivityResult Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");

            var auth = GetAuthenticated();
            var user = auth.ActiveDirectoryUsers.GetById(userId);

            if (user != null && user.UserPrincipalName != "")
            {
                user.Update().WithAccountEnabled(Convert.ToBoolean(Convert.ToInt32(isEnabled))).Apply();
            }
            else
                throw new Exception(string.Format("User with id='{0}' not found", userId));

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
