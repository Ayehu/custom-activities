## OfficeCreateMailboxRule - Activity to create a new mailbox rule in Azure AD for Office365.

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

### Mandatory fields when creating a mailbox rule:

**userEmail**		  - User's email to create the rule

**ruleDisplayName**   - The rule name

**senderContains**    - Apply the rule if sender contains this string

**bodyContains**	  - Apply the rule if body contains this string

**forwardAction**	  - Indicates that email have to be forwarded

**forwardEmail**      - Forward email to the specified email address

**deleteAction**      - Indicates that email have to be deleted

