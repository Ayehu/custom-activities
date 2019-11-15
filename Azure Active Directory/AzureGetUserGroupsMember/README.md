## AzureGetUserGroupsMember - Get groups where a specific user is member of

##### DLL's to reference
Microsoft.Azure.Management.Fluent.dll </br>
Microsoft.Azure.Management.ResourceManager.Fluent.dll </br>
Microsoft.Azure.Management.Graph.RBAC.Fluent.dll </br>
Microsoft.Rest.ClientRuntime.dll </br>
System.Net.Http.dll </br>
Newtonsoft.Json.dll </br>

##### Libraries to import
using Microsoft.Azure.Management.Fluent; </br>
using Microsoft.Azure.Management.ResourceManager.Fluent; </br>
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

You'd need to store the API specific information from the portal.

ApplicationId </br>
TenantId </br>
Secret </br>

These fields should be sent when calling the API.

### The below fields needs to be provided to get groups:
**userId**           - The user Id or the user email
