using System;
using System.Data;
using System.Linq;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Fluent;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureCreateStorageAcctFirewallRule : IActivity
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
        /// The azure portal subscription Id (Free Trial/Premium)
        /// </summary>
        public string subscriptionId;

        /// <summary>
        /// The name of the the account to apply the rule
        /// </summary>
        public string storageAccountName;

        /// <summary>
        /// The IP Address to allow access. 
        /// Important: It has to be a public IP addresses only, not private/internal
        /// </summary>
        /// <remarks>Only IPV4 address is allowed</remarks>
        public string ipAddress;

        public ICustomActivityResult Execute()
        {
            var azure = GetAzure();
            var acct = azure.StorageAccounts.List().Where(x => x.Name.ToLower() == storageAccountName.ToLower()).FirstOrDefault();

            if (acct != null)
            {
                var v = acct.Update().WithAccessFromIpAddress(ipAddress).Apply();
                return this.GenerateActivityResult(GetActivityResult);
            }
            else
                throw new Exception(string.Format("Storage Account name '{0}' not found", storageAccountName));
        }

        private IAzure GetAzure()
        {
            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(appId, secret, tenantId, AzureEnvironment.AzureGlobalCloud);
            var azure = Azure
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(credentials)
                .WithSubscription(subscriptionId);

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
