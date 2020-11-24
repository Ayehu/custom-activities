## AzureVMGetCpuUsage - Get Virtual Machine CPU usage metrics in percentage using the REST API

Remark - The portal needs to be configured first. https://portal.azure.com<br>
You'd need to store the API specific information from the portal (SubscriptionId).

### DLL's to reference
Newtonsoft.Json.dll

### Libraries to import
using System.Web;<br>
using Newtonsoft.Json.Linq;

### Mandatory fields to delete StorageAccount 

**token_password** 				- Authentication token received from another activity that does the authentication<br>
**resourceGroupName**			- Resource Group where the VM belongs to.<br>
**vmName**						- The Virtual Machine name to retrieve the usage.

<hr style="width:100%;text-align:left;margin-left:0">

The authorization token can be retrieved using the <a href="https://github.com/Ayehu/custom-activities/tree/master/Azure/AzureGetToken">AzureGetToken</a> activity or by using the <a href="https://github.com/Ayehu/custom-activities/tree/master/Azure/AzureRetrieveAccessToken">AzureRetrieveAccessToken</a> activity and selecting "https://management.azure.com/.default" for the <b>Scope</b>.
