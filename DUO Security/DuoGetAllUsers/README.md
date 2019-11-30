## DuoGetAllUsers - Get all users from Duo Security portal.

##### DLL's to reference

System.Web.dll </br>
System.Web.Extensions.dll </br>

##### Libraries to import
using System.Globalization; </br>
using System.IO; </br>
using System.Net; </br>
using System.Security.Cryptography; </br>
using System.Text; </br>
using System.Text.RegularExpressions </br>
using System.Web; </br>
using System.Web.Script.Serialization;

You'd need to store the API specific information from the portal.

IntegrationKey </br>
SecretKey </br>
ApiHost