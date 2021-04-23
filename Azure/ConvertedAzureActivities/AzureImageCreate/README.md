## AzureImageCreate - Create an image from a VM.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
System.Net.Http.dll

### Mandatory fields to create Image

**subscriptionId**		- The azure portal subscription Id

**imageName**			- The image name to create.

**vmName**				- The name of the VM to create the image from.

**resourceGroupName**   - The portal resource group VM is.

**api_version**			- Version of the API
