## GCloudResizeDisk - Resize a disk in Google Cloud.

Remark - To resize a disk in Google Cloud you need to set-up a new Service Account at https://cloud.google.com. Check this [tutorial](https://docs.bmc.com/docs/PATROL4GoogleCloudPlatform/10/creating-a-service-account-key-in-the-google-cloud-platform-project-799095477.html).  

##### DLL's to reference
Google.Apis.Auth.dll  
Google.Apis.Auth.PlatformServices.dll  
Google.Apis.Compute.v1.dll  
Google.Apis.Core.dll  
Google.Apis.dll  
Google.Apis.PlatformServices.dll  
Newtonsoft.Json.dll  

You can find the dll's at [nuget](https://www.nuget.org/packages/Google.Apis.Compute.v1) or in the root directory ([https://github.com/Ayehu/custom-activities/blob/master/Google%20Cloud/DLL.zip](https://github.com/Ayehu/custom-activities/blob/master/Google%20Cloud/DLL.zip)).

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;<br>
using Ayehu.Sdk.ActivityCreation.Extension;<br>
using Google.Apis.Services;<br>
using Google.Apis.Compute.v1;<br>
using Google.Apis.Auth.OAuth2;<br>
using Google.Apis.Compute.v1.Data;<br>
using System;<br>
using System.Text;<br>
using System.Data;<br>
using System.Threading.Tasks;<br>
using System.Collections.Generic;<br>
using Newtonsoft.Json.Linq;<br>
using Newtonsoft.Json;<br> 

### Mandatory fields when resizend a disk:
**Project**				- The name of the Google Cloud Project you are working on (e.g.,  peak-equator-254518)  
**DiskName**			- Disk name to be resized  
**NewSize**				- New disk size  
**Region**				- Region which the disk is hosted (e.g., us-central1-a)  
**Zone**				- Zone inside the region, usually a letter  
**ServiceAccountEmail**	- Service Account E-mail. You can create one following this [tutorial](https://docs.bmc.com/docs/PATROL4GoogleCloudPlatform/10/creating-a-service-account-key-in-the-google-cloud-platform-project-799095477.html)  
**PrivateKey**			- When creating a service account, you will be able to donwload a JSON file. Inside the file you can get the private key for the chosen service Account  
