## DuoVerifyIdentity - Send an identity verification request to a Duo user.

### DLL/Library Configuration
##### DLLs to Reference (Global Assembly)
System.Web.dll </br>
System.Web.Extensions.dll </br>
##### DLLs to Reference (Assembly Path)
Newtonsoft.Json.dll (.dll available in "C:\Program Files\Ayehu\eyeShare Executor Server\Newtonsoft.Json.dll" folder)</br>
##### Libraries to Import
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
 </br><br>


### Mandatory Activity Fields:
**Integration Key** - Integration key from "Auth API" settings.
<br>
**Secret Key** - Secret key from "Auth API" settings.
<br>
**API Hostname** - Full Duo API hostname URL (e.g. api-12345678.duosecurity.com)
<br>
**Duo Username**	- The Duo username to which the identity verification request will be sent
<br><br>



### Notes:
This Custom Activity requires the "Auth API" (https://duo.com/docs/authapi) to be enabled on your Duo account.
<br>
1. Sign up for an account with Duo (https://signup.duo.com/).
2. Login to the Duo Admin Panel (https://admin.duosecurity.com/) and navigate to the Applications section.
3. Click "Protect an Application" and locate "Auth API" in the applications list.  Click "Protect this Application" to get your integration key, secret key, and API hostname (see <a href="https://duo.com/docs/getting-started">Getting Started</a> for help).

<br><br>
### Possible Output:
When a Duo user successfully verifies their identity, this activity will return "allow".  When they refuse it or otherwise do not successfully verify the request, this activity will return "deny".

<br><br>
### Example Usage:
A workflow is designed to automatically facilitate password reset requests.  Your organization keeps a record of the Duo username that corresponds to each account in the system (e.g. Active Directory).  Before initiating the password reset, the Duo username can be queried from those records and then an identity verification request can be pushed to that user's mobile device.  Upon a successful verification, the password reset can proceed safely.
