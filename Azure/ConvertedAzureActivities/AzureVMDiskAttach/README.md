## AzureVMDiskAttach - Activity to attach a Data Disk to a Virtual Machine.

Remark - The portal needs to be configured first. https://portal.azure.com

### DLL's to reference
Newtonsoft.Json.dll

### Mandatory fields when attaching a disk to VM:

**subscriptionId**		- The azure portal subscription Id

**vmName**				- Virtual Machine name where to attach the disk.

**diskName**			- The name of the disk to attach

**resourceGroupName**	- The portal resource group Disk is assigned to.

**api_version**			- Version of the API
