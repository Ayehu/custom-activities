using System;
using System.Linq;
using System.Data;
using System.Net;
using System.Net.Http;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Rest.ClientRuntime;
using Microsoft.Rest.ClientRuntime.Azure;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureRestartVMInstance : IActivity
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
        /// Account subscription ID
        /// </summary>
        public string subscriptionId;
		
		/// <summary>
        /// Virtual Machine name
        /// </summary>
        public string vmName;

        ICustomActivityResult IActivity.Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");

            var azure = this.GetAzure();
            var subscription = azure.GetCurrentSubscription();
            var vm = azure.VirtualMachines.List().Where(x => x.Name.ToLower() == vmName.ToLower()).FirstOrDefault();
			
			if (vm == null)
                throw new Exception(string.Format("The virtual machine {0} was not found", vmName));
			
            vm.Restart();

            dt.Rows.Add("Success");
            return this.GenerateActivityResult(dt);
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
    }
}
