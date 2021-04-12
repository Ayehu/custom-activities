## AzureSnapshotCreate - Creates a snapshot from a disk.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
System.Net.Http.dll

### Mandatory fields to get Image

**subscriptionId**		- The azure portal subscription Id

**snapshotName**	    - The name of the snapshot that is being created.

**diskName**            - The disk name to create the snapshot from.

**resourceGroupName**   - The portal resource group disk is.

**api_version**			- Version of the API
