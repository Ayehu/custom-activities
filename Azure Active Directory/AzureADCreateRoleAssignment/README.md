## AzureADCreateRoleAssignment - Add Role assignment for an Application or an AD user.

##### DLL's to reference
Microsoft.Azure.Management.Fluent.dll </br>
Microsoft.Azure.Management.ResourceManager.Fluent.dll </br>
Microsoft.Azure.Management.Graph.RBAC.Fluent.dll </br>
Microsoft.Rest.ClientRuntime.dll </br>
Microsoft.Rest.ClientRuntime.Azure.dll </br>
Microsoft.Graph.dll
Microsoft.Graph.Core.dll
Microsoft.Graph.Auth.dll
Microsoft.Identity.Client.dll
System.Net.Http.dll </br>
Newtonsoft.Json.dll </br>

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces; </br>
using Ayehu.Sdk.ActivityCreation.Extension; </br>
using Microsoft.Azure.Management.Fluent; </br>
using Microsoft.Azure.Management.ResourceManager.Fluent; </br>
using Microsoft.Azure.Management.ResourceManager.Fluent.Core; </br>
using Microsoft.Azure.Management.Graph.RBAC.Fluent; </br>
using Microsoft.Graph; </br>
using System.Collections.Generic; </br>
using System.Reflection; </br>
using System.Linq; </br>


You'd need to store the API specific information from the portal.

ApplicationId </br>
TenantId </br>
Secret </br>
SubscriptionId </br>

These fields should be sent when calling the API.

**objectName** - The name of a security group or an ActiveDirectory user email. </br>
**roleNameId** - Id of the selected role </br>

