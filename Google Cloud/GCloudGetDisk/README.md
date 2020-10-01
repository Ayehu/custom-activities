## GCloudGetDisk - Retrieve details on a Google Cloud disk.

Remark - To start an instance in Google Cloud you need to set-up a new Service Account at https://cloud.google.com. Check this [tutorial](https://docs.bmc.com/docs/PATROL4GoogleCloudPlatform/10/creating-a-service-account-key-in-the-google-cloud-platform-project-799095477.html).  

##### DLL's to reference
Google.Apis.Auth.dll  
Google.Apis.Auth.PlatformServices.dll  
Google.Apis.Compute.v1.dll  
Google.Apis.Core.dll  
Google.Apis.dll  
Google.Apis.PlatformServices.dll  
Newtonsoft.Json.dll  

You can find the dll's at [nuget](https://www.nuget.org/packages/Google.Apis.Compute.v1).

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Google.Apis.Services;
using Google.Apis.Compute.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Compute.v1.Data;
using System;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

### Mandatory fields when retrieving disk information:
**Project**				- The name of the Google Cloud Project you are working on (e.g.,  peak-equator-254518)  
**DiskName**		- Disk name for which to retrieve details  
**Region**				- Region which the instance will be hosted (e.g., us-central1-a)  
**Zone**				- Zone inside the region, usually a letter  
**ServiceAccountEmail**	- Service Account E-mail. You can create one following this [tutorial](https://docs.bmc.com/docs/PATROL4GoogleCloudPlatform/10/creating-a-service-account-key-in-the-google-cloud-platform-project-799095477.html)  
**PrivateKey**			- When creating a service account, you will be able to donwload a JSON file. Inside the file you can get the private key for the chosen service Account  
