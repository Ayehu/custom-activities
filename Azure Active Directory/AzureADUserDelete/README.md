## AzureADDeleteUser - Activity to delete a user in Azure AD.

##### DLL's to reference
System.Net.Http.dll </br>

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

**Access token**      - Access token

**UserId**			  - GUID that identifies a user. (unique id) 	                    
