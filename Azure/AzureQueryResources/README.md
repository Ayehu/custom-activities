## AzureQueryResources - List all resources for a subscription.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
Microsoft.Rest.ClientRuntime.Azure.dll
Microsoft.Rest.ClientRuntime.dll
Microsoft.Azure.Management.ResourceManager.Fluent.dll
Microsoft.Azure.Management.Fluent.dll
System.Net.Http.dll
Newtonsoft.Json.dll

##### Libraries to import
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;


You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret
SubscriptionId
