## AzureADGetUserInfo - Get user infromation from Azure Active Directory.

##### DLL's to reference
Microsoft.Azure.Management.Fluent.dll </br>
Microsoft.Azure.Management.ResourceManager.Fluent.dll </br>
Microsoft.Azure.Management.Graph.RBAC.Fluent.dll </br>
Microsoft.Rest.ClientRuntime.dll </br>
Microsoft.Rest.ClientRuntime.Azure.dll </br>
System.Net.Http.dll </br>
Newtonsoft.Json.dll </br>
Microsoft.Graph.dll </br>
Microsoft.Graph.Auth.dll </br>
Microsoft.Graph.Core.dll </br>
Microsoft.Identity.Client.dll

##### Libraries to import

using Microsoft.Azure.Management.Fluent; </br>
using Microsoft.Azure.Management.ResourceManager.Fluent; </br>
using Microsoft.Azure.Management.ResourceManager.Fluent.Core; </br>
using Microsoft.Graph; </br>
using Microsoft.Identity.Client; </br>
using Microsoft.Graph.Auth;

You'd need to store the API specific information from the portal.

ApplicationId </br>
TenantId </br>
Secret </br>

These fields should be sent when calling the API.

### Thhe below field needs to be provided to get information:
**userEmail**			  - User email to retrieve the information.
