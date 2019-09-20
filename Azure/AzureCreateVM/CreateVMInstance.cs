using System;
using System.Data;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Network.Fluent;

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
    public class CreateVMInstance : IActivity
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
        /// Id of the OS to install
        /// </summary>
        public int vmTypeId;

        private string publisher;
        private string offer;
        private string sku;

        public ICustomActivityResult Execute()
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result");

            IAvailabilitySet availabilitySet = null;
            IPublicIPAddress publicIPAddress = null;
            INetworkInterface networkInterface = null;
            INetwork network = null;
            //IDisk managedDisk = null;
            IResourceGroup resourceGroup = null;

            var azure = this.GetAzure();

            try
            {
                InitImageVersion();

                var location = Region.USEast;
                resourceGroup = azure.ResourceGroups
                    .Define(vmGroupName)
                    .WithRegion(Region.USEast)
                    .Create();

                availabilitySet = azure.AvailabilitySets.Define("AVSet")
                   .WithRegion(location)
                   .WithExistingResourceGroup(vmGroupName)
                   .WithSku(AvailabilitySetSkuTypes.Aligned)
                   .Create();

                publicIPAddress = azure.PublicIPAddresses.Define("PublicIP")
                    .WithRegion(location)
                    .WithExistingResourceGroup(vmGroupName)
                    .WithDynamicIP()
                    .Create();

                network = azure.Networks.Define("VNet")
                    .WithRegion(location)
                    .WithExistingResourceGroup(vmGroupName)
                    .WithAddressSpace("10.0.0.0/16")
                    .WithSubnet("Subnet", "10.0.0.0/24")
                    .Create();

                networkInterface = azure.NetworkInterfaces.Define("NIC")
                    .WithRegion(location)
                    .WithExistingResourceGroup(vmGroupName)
                    .WithExistingPrimaryNetwork(network)
                    .WithSubnet("Subnet")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithExistingPrimaryPublicIPAddress(publicIPAddress)
                    .Create();

                if (vmTypeId == (int)VMType.WindowsServer10Pro ||
                    vmTypeId == (int)VMType.WindowsServer2012 ||
                    vmTypeId == (int)VMType.WindowsServer2016 ||
                    vmTypeId == (int)VMType.WindowsServer2019)
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
                /*if (availabilitySet != null)
                {
                    azure.AvailabilitySets.DeleteById(availabilitySet.Id);
                }

                if (publicIPAddress != null)
                {
                    azure.PublicIPAddresses.DeleteById(publicIPAddress.Id);
                }

                if (network != null)
                {
                    azure.Networks.DeleteById(network.Id);
                }

                if (networkInterface != null)
                {
                    azure.NetworkInterfaces.DeleteById(networkInterface.Id);
                }

                if (managedDisk != null)
                {
                    azure.Disks.DeleteById(managedDisk.Id);
                }*/

                if (resourceGroup != null)
                {
                    azure.ResourceGroups.DeleteByName(resourceGroup.Name);
                }

                throw new Exception(ex.Message);
            }

            return this.GenerateActivityResult(dt);
        }

        private void InitImageVersion()
        {
            switch (vmTypeId)
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
