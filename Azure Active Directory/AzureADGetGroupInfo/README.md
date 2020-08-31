## AzureADGetGroupInfo - Retrieves information about a group. It can be a Security or Office365.

##### DLL's to reference
System.Net.Http.dll </br>
Newtonsoft.Json.dll </br>
Microsoft.Identity.Client.dll

##### Libraries to import

using Newtonsoft.Json; </br>
using Newtonsoft.Json.Linq; </br>
using Microsoft.Identity.Client; </br>

You'd need to store the API specific information from the portal.

ApplicationId </br>
TenantId </br>
Secret </br>

These fields should be sent when calling the API.

### Thhe below field needs to be provided to get information:
**groupName**			  - Group name to retrieve the information.
