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

Note that in order to use this Custom Activity, you will need to replace the <b>Ayehu.Sdk.ActivityCreation.dll</b> file in the "eyeShare Executor Server" folder with the one found at the link below:
<br><br>
<a href="https://github.com/Ayehu/Custom-Activity-Helper/tree/master/1.1.0">https://github.com/Ayehu/Custom-Activity-Helper/tree/master/1.1.0</a>
<br><br>
You can find the DLL in its default installation directory of "C:\Program Files\Ayehu\eyeShare Executor Server".
<br><br>
The authorization token can be retrieved using the <a href="https://github.com/Ayehu/custom-activities/tree/master/Azure/AzureGetToken">AzureGetToken</a> activity or by using the <a href="https://github.com/Ayehu/custom-activities/tree/master/Azure/AzureRetrieveAccessToken">AzureRetrieveAccessToken</a> activity and selecting "https://management.azure.com/.default" for the <b>Scope</b>.
