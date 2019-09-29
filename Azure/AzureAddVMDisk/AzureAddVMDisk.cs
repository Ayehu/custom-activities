using System;
using System.Data;
using System.Linq;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureAddVMDisk : IActivity
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
        /// Disk size in GB
        /// </summary>
        public string sizeGB;

        /// <summary>
        /// Virtual Machine name
        /// </summary>
        public string vmName;

        /// <summary>
        /// The new disk name
        /// </summary>
        public string diskName;

         public ICustomActivityResult Execute()
        {
            var azure = GetAzure();
            var vm = azure.VirtualMachines.List().Where(x => x.Name.ToLower() == vmName.ToLower()).FirstOrDefault();
            int size = int.Parse(sizeGB);

            if (vm == null)
                throw new Exception(string.Format("The virtual machine {0} was not found", vmName));

            if (string.IsNullOrEmpty(diskName.Trim()))
                throw new Exception("The disk name can't be empty");

            if (size == 0)
                throw new Exception("Disk size must be greater than zero");

            var disk = new DataDisk(
                vm.StorageProfile.DataDisks.Count + 1,
                DiskCreateOptionTypes.Empty,
                diskName);

            disk.DiskSizeGB = size;
            disk.Validate();

            vm.StorageProfile.DataDisks.Add(disk);
            vm.StorageProfile.Validate();
            vm.Update().Apply();

            return this.GenerateActivityResult(GetActivityResult);
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
