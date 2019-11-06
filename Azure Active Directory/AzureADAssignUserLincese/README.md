## AzureADAssignUserLicense - Activity to Assign Exchange Online license to a user in Azure AD.

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

### Thhe below fields needs to be provided to apply license:
**UserId**			  - GUID that identifies a user. (unique id) 	                    
