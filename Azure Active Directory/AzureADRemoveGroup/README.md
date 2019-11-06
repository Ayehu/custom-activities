## AzureADRemoveGroup - Activity to remove an Azure AD security group.

##### DLL's to reference
Microsoft.Azure.Management.Fluent.dll </br>
Microsoft.Azure.Management.ResourceManager.Fluent.dll </br>
Microsoft.Azure.Management.Graph.RBAC.Fluent.dll </br>
Microsoft.Rest.ClientRuntime.dll </br>
System.Net.Http.dll </br>
Newtonsoft.Json.dll

##### Libraries to import
using Microsoft.Azure.Management.Fluent; </br>
using Microsoft.Azure.Management.ResourceManager.Fluent; </br>
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

You'd need to store the API specific information from the portal.
ApplicationId
TenantId
Secret

These fields should be sent when calling the API.

### The below fields needs to be provided to remove a group:
**groupName**           - Name of the group to be removed (Case insensitive)
