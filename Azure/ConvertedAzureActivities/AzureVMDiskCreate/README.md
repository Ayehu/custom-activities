## AzureVMDiskCreate - Activity to create a Data Disk.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference

System.Net.Http.dll
Newtonsoft.Json.dll

### Mandatory fields when creating a VM disk:

**subscriptionId**		- The azure portal subscription Id (Free Trial/Premium)

**resourceGroupName**	- Resource Group where to create the disk. So this disk can be attached to a VM inside the same group.

**diskName**			- The name of the new diskName

**sizeGB**				- Size in GB for the new disk
