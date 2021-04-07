## AzureVMDiskDelete - Activity to delete a Data Disk.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
System.Net.Http.dllnagement.ResourceManager.Fluent.Core


### Mandatory fields when deleting a VM disk:

**subscriptionId**		- The azure portal subscription Id

**diskName**			- The name of the disk to delete

**resourceGroupName**   - The portal resource group Disk is assigned to.
