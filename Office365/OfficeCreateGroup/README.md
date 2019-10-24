## OfficeCreateGroup - Activity to create a Office365 mail group.

##### DLL's to reference
Microsoft.Graph.dll
Microsoft.Graph.Auth.dll
Microsoft.Graph.Core.dll
Microsoft.Identity.Client.dll

##### Libraries to import
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;

You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret

These fields should be sent when calling the API.

### The below fields needs to be provided to create a group:
**groupName**           - Display Name for new mail group

**groupMailNikName**    - The mail alias for the group. Must be unique

**groupDescription**    - Optional field to add a description for the new group
