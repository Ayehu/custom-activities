## AzureADAddGroupMember - Activity to add a member to Azure AD security group.
Please note that this version is using the soon-to-be deprecated Azure Active Directory Graph API.  For the equivalent activity using the Microsoft Graph API, <a href="https://github.com/Ayehu/custom-activities/tree/master/Azure%20Active%20Directory/AzureADAddUserToGroup">AzureADAddUserToGroup</a>.

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
using Microsoft.Azure.Management.ResourceManager.Fluent.Core; </br>

You'd need to store the API specific information from the portal. </br>
ApplicationId </br>
TenantId </br>
Secret

These fields should be sent when calling the API.

### The below fields needs to be provided to add a group member: 
**groupName**           - The name of the group to add the member (Case insensitive). Also accepts group id.

**userEmail**			- User's email to add to the group (Case insensitive)

**roleId**				- Role id to add to the group (It's either userEmail or roleId. Can't be both at the same time)
