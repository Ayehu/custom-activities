## GDriveDeleteFile - Delete a file in a Google Drive account.

Remark - To run this activity you need to:  
1. Set-up a new Service Account following this [tutorial](https://docs.bmc.com/docs/PATROL4GoogleCloudPlatform/10/creating-a-service-account-key-in-the-google-cloud-platform-project-799095477.html);  
2. Delegate domain-wide authority to your service account following this [tutorial](https://developers.google.com/admin-sdk/directory/v1/guides/delegation)
3. And allow your gSuite account to give access to your Service Account access the users' data. Follow the same tutorial from item 2. The necessary scope is: https://www.googleapis.com/auth/drive.  

##### DLL's to reference
Google.Apis.Auth.dll  
Google.Apis.Auth.PlatformServices.dll  
Google.Apis.Drive.v3.dll  
Google.Apis.Core.dll  
Google.Apis.dll  
Google.Apis.PlatformServices.dll  

You can find the dll's at [nuget](https://www.nuget.org/packages/Google.Apis.Drive.v3/).  

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;  
using Ayehu.Sdk.ActivityCreation.Extension;  
using Google.Apis.Auth.OAuth2;  
using Google.Apis.Drive.v3;  
using Google.Apis.Services;  
using System.IO;  
using System.Web;  
using System.Collections.Generic;  

### Mandatory fields:

**FileId**				- ID of the file to delete. Get the file ID getting a requesting a shareable link. Inside the link you can find the ID.   
**UserId**				- User e-mail to impersonate  
**ServiceAccountEmail**	- Service Account E-mail. You can create one following this [tutorial](https://docs.bmc.com/docs/PATROL4GoogleCloudPlatform/10/creating-a-service-account-key-in-the-google-cloud-platform-project-799095477.html)  
**PrivateKey**			- When creating a service account, you will be able to donwload a JSON file. Inside the file you can get the private key for the chosen service Account  