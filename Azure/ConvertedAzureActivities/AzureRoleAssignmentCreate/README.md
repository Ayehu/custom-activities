## AzureRoleAssignmentCreate - Creates a role assignment for a resource.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
System.Net.Http.dll
Newtonsoft.Json.dll

### Mandatory fields

**subscriptionId**		- The azure portal subscription Id

**resourceName**		- The resource name for which to add a new Role.

**roleName**			- The role name to add.

**principalId**         - The principal ID assigned to the role. This maps to the ID inside the Active Directory. It can point to a user, service principal, or security group.

**resourceGroupName**   - The portal resource is assigned to.

**api_version**			- Version of the API