## AzureCreateVMInstance - Activity to create a new Azure Virtual Machine.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
Microsoft.Azure.Management.Compute.Fluent.dll
Microsoft.Azure.Management.Fluent.dll
Microsoft.Azure.Management.ResourceManager.Fluent.dll
Microsoft.Azure.Management.Network.Fluent.dll

##### Libraries to import
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Network.Fluent;


You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret

### Mandatory fields when creating a VM:

**subscriptionId**		- The azure portal subscription Id (Free Trial/Premium)

**vmName**				- Virtual Machine name

**vmGroupName**			- Virtual Machine Group Name

**vmUserName**			- Virtual Machine User Name

**vmPassword**			- Virtual Machine  password

**vmTypeId**			- Id of the OS to install
