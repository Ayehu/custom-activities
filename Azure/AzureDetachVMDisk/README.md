## AzureDetachVMDisk - Activity to detach Data Disk from a Virtual Machine.

Remark - The portal needs to be configured first. https://portal.azure.com

### DLL's to reference
Microsoft.Azure.Management.Compute.Fluent.dll<br>
Microsoft.Azure.Management.Fluent.dll<br>
Microsoft.Azure.Management.ResourceManager.Fluent.dll<br>
Microsoft.Azure.Management.Network.Fluent.dll<br>
Microsoft.Rest.ClientRuntime.Azure.dll<br>
Microsoft.Rest.ClientRuntime.dll<br>
System.Net.dll<br>
System.Net.Http.dll<br>
System.XML.dll<br>
System.Data.dll<br>
System.dll<br>
Newtonsoft.Json.dll

### Libraries to import
using System;<br>
using System.Linq;<br>
using System.Data;<br>
using System.Net;<br>
using System.Net.Http;<br>
using Ayehu.Sdk.ActivityCreation.Interfaces;<br>
using Ayehu.Sdk.ActivityCreation.Extension;<br>
using Microsoft.Azure.Management.Fluent;<br>
using Microsoft.Azure.Management.ResourceManager.Fluent;<br>
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;<br>
using Microsoft.Azure.Management.Compute.Fluent;<br>
using Microsoft.Rest.ClientRuntime;<br>
using Microsoft.Rest.ClientRuntime.Azure;<br>
using Newtonsoft.Json;<br>
using Newtonsoft.Json.Linq;

### You'd need to store the API specific information from the portal.

ApplicationId<br>
TenantId<br>
Secret

### Mandatory fields when detaching a data disk from VM:

**subscriptionId**		- The azure portal subscription Id (Free Trial/Premium)

**vmName**				- Virtual Machine name where to detach the disk.

**diskName**			- The name of the disk to detach
