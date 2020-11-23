## AzureVMGetCpuUsage - Get Virtual Machine CPU usage metrics in percentage using the REST API

Remark - The portal needs to be configured first. https://portal.azure.com

### DLL's to reference
Newtonsoft.Json.dll

### Libraries to import
using System.Web;<br>
using Newtonsoft.Json.Linq;

You'd need to store the API specific information from the portal.

SubscriptionId

### Mandatory fields to delete StorageAccount 

**token_password** 				- Authentication token received from another activity that does the authentication<br>
**resourceGroupName**			- Resource Group where the VM belongs to.<br>
**vmName**						- The Virtual Machine name to retrieve the usage.
