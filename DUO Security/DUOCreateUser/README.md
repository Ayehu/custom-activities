## DUOCreateUser - Create a new user in DUO security portal.

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

These fields should be sent when calling the API.

### Mandatory fields when creating a user:
**UserName**	- The name of the user to create.
**RealName**	- The real name (or full name) of this user.
**FirsName**	- The user’s given name.
**LastName**	- The user’s surname.
**Email**		- The email address of this user.
**Status**		- active, bypass, disabled	