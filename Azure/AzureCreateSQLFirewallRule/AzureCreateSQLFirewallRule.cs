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
    public class AzureCreateSQLFirewallRule : IActivity
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
        /// SQL server to apply the rule
        /// </summary>
        public string sqlServerName;

        /// <summary>
        /// Rule name
        /// </summary>
        public string firewallRuleName;

        /// <summary>
        /// IP address to apply
        /// </summary>
        public string ipAddress;

        public ICustomActivityResult Execute()
        {
            var azure = GetAzure();
            var server = azure.SqlServers.List().Where(x => x.Name.ToLower() == sqlServerName.ToLower()).FirstOrDefault();

            if (server != null)
            {
                server.FirewallRules.Define(firewallRuleName).WithIPAddress(ipAddress).Create();
                return this.GenerateActivityResult(GetActivityResult);
            }
            throw new Exception(string.Format("Server name '{0} not found'", sqlServerName));
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
