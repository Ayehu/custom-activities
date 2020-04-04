## DuoVerifyIdentity - Send an identity verification request to a Duo user.

##### DLL's to reference (Global Assembly)

System.Web.dll </br>
System.Web.Extensions.dll </br>

##### DLL's to reference (Assembly Path)

Newtonsoft.Json.dll </br>

##### Libraries to import
using System.Globalization; </br>
using System.IO; </br>
using System.Net; </br>
using System.Security.Cryptography; </br>
using System.Text; </br>
using System.Text.RegularExpressions </br>
using System.Web; </br>
using System.Web.Script.Serialization; </br>
using Newtonsoft.Json; </br>
using Newtonsoft.Json.Linq; </br>
 </br>
You'd need to store the API specific information from the portal.

IntegrationKey </br>
SecretKey </br>
ApiHost

These fields should be sent when calling the API.

### Mandatory fields when verifying user identity:
**Duo Username**	- The Duo username to which the identity verification request will be sent
<br><br><br>
### Notes:
This Custom Activity requires the "Auth API" (https://duo.com/docs/authapi) to be enabled on your Duo account.
<br><br>
-Sign up for an account with Duo (https://signup.duo.com/).
<br>
-Login to the Duo Admin Panel (https://admin.duosecurity.com/) and navigate to the Applications section.
<br>
-Click Protect an Application and locate Auth API in the applications list.  Click Protect this Application to get your integration key, secret key, and API hostname (see Getting Started for help).
