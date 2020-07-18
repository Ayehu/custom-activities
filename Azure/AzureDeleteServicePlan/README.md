## AzureDeleteServicePlan - Deletes an Azure ServicePlan by name.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
Microsoft.Azure.Management.Compute.Fluent.dll
Microsoft.Azure.Management.Fluent.dll
Microsoft.Azure.Management.ResourceManager.Fluent.dll
Microsoft.Azure.Management.Network.Fluent.dll
Microsoft.Azure.Management.Sql.Fluent.dll
Microsoft.Azure.Management.AppService.Fluent.dll
Microsoft.Rest.ClientRuntime.dll
Microsoft.Rest.ClientRuntime.Azure.dll
System.Net.Http.dll
Newtonsoft.Json.dll

##### Libraries to import
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;


You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret

### Mandatory fields to delete a ServicePlan 

**servicePlanName**			- App Service Plan
