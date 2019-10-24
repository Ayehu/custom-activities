## OfficeSendEmail - Activity to send an email on behalf of a Office365 user.

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

### Mandatory fields when sending an email:

**subject**			  - Email subject 

**messageBody**   	  - The text of the message to be sent 

**fromEmail**		  - The sender's email

**toEmail**			  - The recipient of the email
