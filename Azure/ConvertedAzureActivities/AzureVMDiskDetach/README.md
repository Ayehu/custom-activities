## AzureVMDiskDetach - Activity to detach Data Disk from a Virtual Machine.

Remark - The portal needs to be configured first. https://portal.azure.com

### DLL's to reference
System.Net.Http.dll
Newtonsoft.Json.dll


### Mandatory fields when detaching a data disk from VM:

**subscriptionId**		- The azure portal subscription Id

**vmName**				- Virtual Machine name where to detach the disk.

**diskName**			- The name of the disk to detach

**resourceGroupName**   - The portal resource group Disk is assigned to.

**api_version**			- Version of the API
