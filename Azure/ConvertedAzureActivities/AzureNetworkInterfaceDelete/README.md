## AzureNetworkInterfaceDelete - Deletes an Azure Network Interface by name

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
System.Net.Http.dll
Newtonsoft.Json.dll

You'd need to store the API specific information from the portal.

SubscriptionId

### Mandatory fields when deleting a Network Interface 

**networkName**			- Network Interface name.
**resourceGroupName**   - The portal resource group Network Interface is assigned to.
**api_version**			- Version of theq API