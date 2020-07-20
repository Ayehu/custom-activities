using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureQueryResources : IActivity
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
        public string secretpassword;

        /// <summary>
        /// The azure portal subscription Id (Free Trial/Premium)
        /// </summary>
        public string subscriptionId;

        public ICustomActivityResult Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Name");
            dt.Columns.Add("Type");

            ResourceManagementClient client = new ResourceManagementClient(GetRestClient);
            client.SubscriptionId = subscriptionId;

            var resources = client.Resources.ListAsync().Result;

            foreach (var res in resources)
            {
                dt.Rows.Add(res.Name, res.Type);
            }

            return this.GenerateActivityResult(dt);
        }

        private RestClient GetRestClient
        {
            get
            {
                var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(appId, secretpassword, tenantId, AzureEnvironment.AzureGlobalCloud);
                return RestClient.Configure()
                                  .WithEnvironment(AzureEnvironment.AzureGlobalCloud)
                                  .WithCredentials(credentials)
                                  .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                                  .Build();
            }
        }
    }
}
