<h1>AzureADAddUserToGroup</h1>
<h3>Add an Azure AD user to a group.</h3>
Please note that this version is using the Microsoft Graph API rather than the soon-to-be deprecated Azure Active Directory Graph API.  The required permissions can be found here: <a href="https://docs.microsoft.com/en-us/graph/api/group-post-members?view=graph-rest-1.0&tabs=http">https://docs.microsoft.com/en-us/graph/api/group-post-members?view=graph-rest-1.0&tabs=http</a>.

<h3>Libraries to Import</h3>
using Ayehu.Sdk.ActivityCreation.Extension;<br>
using Ayehu.Sdk.ActivityCreation.Interfaces;<br>
using Microsoft.Identity.Client;<br>
using Newtonsoft.Json;<br>
using Newtonsoft.Json.Linq;<br>
using System;<br>
using System.Data;<br>
using System.IO;<br>
using System.Net;<br>

<h3>DLLs to Reference</h3>
Microsoft.Identity.Client.dll<br>
Microsoft.Rest.ClientRuntime.dll<br>
System.Net.Http.dll<br>
Newtonsoft.Json.dll<br>

<h3>Input Fields</h3>
<b>App ID:</b> Application Registration ID.<br>
<b>Tenant ID:</b> Application Registration Tenant ID.<br>
<b>Secret:</b> Application Registration Client Secret.<br>
<b>Group Name:</b> Azure AD Group Name.<br>
<b>User Email:</b> Azure AD User Email Address.<br>

<h3>Output:</h3>
Successful executions will return "Success".
<br><br>
Otherwise, a detailed error message will be returned (e.g. "User not found", "Group not found", etc.).
