using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Ayehu.Sdk.ActivityCreation
{
    /// <summary>
    /// Virtual Machine OS type
    /// </summary>
    enum VMType
    {
        WindowsServer10Pro = 1,
        WindowsServer2019,
        WindowsServer2016,
        WindowsServer2012,
        UbuntuServer,
        RedHatEnterprise,
        SuseLinuxEnterprise,
        CentOS,
        Debian9
    }

    /// <summary>
    /// Creates a new Azure VM
    /// </summary>
    public class AzureCreateVMInstance : IActivity
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
        /// Virtual Machine name
        /// </summary>
        public string vmName;
        /// <summary>
        /// Virtual Machine Group Name
        /// </summary>
        public string vmGroupName;
        /// <summary>
        /// Virtual Machine User Name
        /// </summary>
        public string vmUserName;
        /// <summary>
        /// Virtual Machine  password
        /// </summary>
        public string vmPassword;
        /// <summary>
        /// The name of the OS
        /// </summary>
        public string vmTypeId;
        /// <summary>
        /// Id of the OS to install
        /// </summary>
        public int typeId;

        private string publisher;
        private string offer;
        private string sku;

        public ICustomActivityResult Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");

            IResourceGroup resourceGroup = null;
            var azure = this.GetAzure();

            try
            {
                InitImageVersion();

                var location = Region.USEast;

                resourceGroup = azure.ResourceGroups.GetByName(vmGroupName);

                if (resourceGroup == null)
                {
                    resourceGroup = azure.ResourceGroups
                        .Define(vmGroupName)
                        .WithRegion(location)
                        .Create();
                }

                var availabilitySet = azure.AvailabilitySets.Define("AVSet-" + vmName)
                     .WithRegion(location)
                     .WithExistingResourceGroup(vmGroupName)
                     .WithSku(AvailabilitySetSkuTypes.Aligned)
                     .Create();

                var publicIPAddress = azure.PublicIPAddresses.Define("PublicIP-" + vmName)
                    .WithRegion(location)
                    .WithExistingResourceGroup(vmGroupName)
                    .WithDynamicIP()
                    .Create();

                var network = azure.Networks.Define("VNet-" + vmName)
                    .WithRegion(location)
                    .WithExistingResourceGroup(vmGroupName)
                    .WithAddressSpace("10.0.0.0/16")
                    .WithSubnet("Subnet", "10.0.0.0/24")
                    .Create();

                var networkInterface = azure.NetworkInterfaces.Define("NIC-" + vmName)
                    .WithRegion(location)
                    .WithExistingResourceGroup(vmGroupName)
                    .WithExistingPrimaryNetwork(network)
                    .WithSubnet("Subnet")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithExistingPrimaryPublicIPAddress(publicIPAddress)
                    .Create();

                if (typeId == (int)VMType.WindowsServer10Pro ||
                    typeId == (int)VMType.WindowsServer2012 ||
                    typeId == (int)VMType.WindowsServer2016 ||
                    typeId == (int)VMType.WindowsServer2019)
                {
                    azure.VirtualMachines.Define(vmName).
                       WithRegion(location)
                       .WithExistingResourceGroup(vmGroupName)
                       .WithExistingPrimaryNetworkInterface(networkInterface)
                       .WithLatestWindowsImage(publisher, offer, sku)
                       .WithAdminUsername(vmUserName)
                       .WithAdminPassword(vmPassword)
                       .WithComputerName(vmName)
                       .WithExistingAvailabilitySet(availabilitySet)
                       .WithSize(VirtualMachineSizeTypes.StandardDS1)
                       .Create();
                }
                else
                {
                    azure.VirtualMachines.Define(vmName).
                       WithRegion(location)
                       .WithExistingResourceGroup(vmGroupName)
                       .WithExistingPrimaryNetworkInterface(networkInterface)
                       .WithLatestLinuxImage(publisher, offer, sku)
                       .WithRootUsername(vmUserName)
                       .WithRootPassword(vmPassword)
                       .WithComputerName(vmName)
                       .WithExistingAvailabilitySet(availabilitySet)
                       .WithSize(VirtualMachineSizeTypes.StandardDS1)
                       .Create();
                }

                dt.Rows.Add("Success");
            }
            catch (Exception ex)
            {
                if (resourceGroup != null)
                {
                    azure.ResourceGroups.DeleteByName(resourceGroup.Name);
                }

                string innerMessage = (ex.InnerException != null)
                      ? ex.InnerException.Message
                      : "";

                throw new Exception(ex.Message + ": " + innerMessage + ": " + ex.StackTrace + " vmTypeId: " + typeId);
            }

            return this.GenerateActivityResult(dt);
        }

        private void InitImageVersion()
        {
            switch (typeId)
            {
                case (int)VMType.CentOS:
                    {
                        publisher = "OpenLogic";
                        offer = "CentOS";
                        sku = "7.5";
                        break;
                    }
                case (int)VMType.Debian9:
                    {
                        publisher = "credativ";
                        offer = "Debian";
                        sku = "7.6";
                        break;
                    }
                case (int)VMType.RedHatEnterprise:
                    {
                        publisher = "RedHat";
                        offer = "RHEL";
                        sku = "18.04-LTS";
                        break;
                    }
                case (int)VMType.SuseLinuxEnterprise:
                    {
                        publisher = "SUSE";
                        offer = "SLES";
                        sku = "15";
                        break;
                    }
                case (int)VMType.UbuntuServer:
                    {
                        publisher = "Canonical";
                        offer = "UbuntuServer";
                        sku = "18.04-LTS";
                        break;
                    }
                case (int)VMType.WindowsServer10Pro:
                    {
                        publisher = "MicrosoftWindowsDesktop";
                        offer = "Windows-10";
                        sku = "RS3-Pro";
                        break;
                    }
                case (int)VMType.WindowsServer2012:
                    {
                        publisher = "MicrosoftWindowsServer";
                        offer = "WindowsServer";
                        sku = "2012-R2-Datacenter";
                        break;
                    }
                case (int)VMType.WindowsServer2016:
                    {
                        publisher = "MicrosoftWindowsServer";
                        offer = "WindowsServer";
                        sku = "2016-Datacenter";
                        break;
                    }
                case (int)VMType.WindowsServer2019:
                    {
                        publisher = "MicrosoftWindowsServer";
                        offer = "WindowsServer";
                        sku = "2019-Datacenter";
                        break;
                    }
            }
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
