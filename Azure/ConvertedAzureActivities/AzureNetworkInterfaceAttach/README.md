## AzureNetworkInterfaceAttach - Azure Attach a secondary Network Interface to a Virtual Machine.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
System.Net.Http.dll
Newtonsoft.Json.dll

### Mandatory fields when attaching a secondary Network Interface to a VM: 

**subscriptionId**		- The azure portal subscription Id

**vmName**				- Virtual Machine name where to attach existing network interface.

**networkName**			- Network Interface name.

**resourceGroupName**   - The portal resource group VM is assigned to.