## OfficeDeleteGroup - Activity to delete a Office365 mail group.

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

### One of the below fields needs to be provided to delete a user:
**groupName**           - The name of the mail group to delete. It's case INSENSITIVE.
