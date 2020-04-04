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
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

You'd need to store the API specific information from the portal.

IntegrationKey </br>
SecretKey </br>
ApiHost

These fields should be sent when calling the API.

### Mandatory fields when verifying user identity:
**Duo Username**	- The Duo username to which the identity verification request will be sent
