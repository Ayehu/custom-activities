## AzureADRemoveGroupMember - Activity to remove a member from Azure AD security group.

##### DLL's to reference
Microsoft.Azure.Management.Fluent.dll
Microsoft.Azure.Management.ResourceManager.Fluent.dll
Microsoft.Azure.Management.Graph.RBAC.Fluent.dll
Microsoft.Rest.ClientRuntime.dll
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

These fields should be sent when calling the API.

### The below fields needs to be provided to remove a member from group:
**groupName**           - The Group Name to remove the member (Case insensitive)

**userEmail**			- User's email to remove from the group (Case insensitive)

**roleId**				- Role id to remove from the group (It's either userEmail or roleId. Can't be both at the same time)
