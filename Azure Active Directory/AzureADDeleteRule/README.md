## AzureADDeleteMailboxRule - Activity to delete a mailbox rule in Azure AD for Office365.

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

### Mandatory fields when deleting a mailbox rule:

**userEmail**		  - User's email to delete the rule 

**ruleName**   		  - The rule name. It's case INSENSITIVE.
