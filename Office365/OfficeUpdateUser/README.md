## OfficeUdpdateUser - Activity to update a user in Azure AD for Office365.

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

### One of the below fields needs to be provided to update a user:

**userId**			  - GUID that identifies a user. (unique id) 	                    

**firstName**		  - User FirstName to update

**lastName**		  - User LastName to update
