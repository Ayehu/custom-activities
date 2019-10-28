## BoxDeleteUser - Delete user from Box account.

Remark - To be able to access remotely your Box account, follow this [tutorial](https://developer.box.com/docs/setting-up-a-jwt-app) to setup.  

##### DLL's to reference
Box.V2.dll  
BouncyCastle.Crypto.dll  
Microsoft.IdentityModel.Tokens.dll  
Microsoft.IdentityModel.Logging.dll  
System.IdentityModel.Tokens.Jwt.dll  

You can find the dll at [nuget](https://www.nuget.org/packages/Box.V2/).  

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;  
using Ayehu.Sdk.ActivityCreation.Extension;  
using Box.V2.Config;  
using Box.V2.JWTAuth;  
using Box.V2.Models.Request;  

### Mandatory fields when delete a user:
**UserId**				- User e-mail to impersonate  
**ClientId**			- Data contained in config.json file.  
**ClientSecret**		- Data contained in config.json file.  
**EntrepriseId**		- Data contained in config.json file.  
**Passphrase**			- Data contained in config.json file.  
**JwtPublicKey**		- Data contained in config.json file.  
**PrivateKey**			- Data contained in config.json file.  
**UserIdToDelete**		- User e-mail to be deleted.  