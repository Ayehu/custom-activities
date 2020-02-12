## TrendMicroRecolateAgent - Relocate an Agent in Trend Micro.

Remark - To run this activity you need to:  
1. Add an application following this [tutorial](https://docs.trendmicro.com/all/ent/apex-svc/2019/en-us/apexCen_saas_2019_api.pdf) at pages 1-3;  

##### DLL's to reference
Newtonsoft.Json.dll  

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.Generic;
using System.Net.Http;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Net.Http.Headers;
using System.Threading;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

### Mandatory fields:

**Base URL**			- Group's name  
**Application ID**		- E-mail to access new Google Account  
**API Key**				- User e-mail to impersonate  
**Dest. Server ID**		- Service Account E-mail. You can create one following this [tutorial](https://docs.bmc.com/docs/PATROL4GoogleCloudPlatform/10/creating-a-service-account-key-in-the-google-cloud-platform-project-799095477.html)  
**Dest. Folder Path**	- When creating a service account, you will be able to donwload a JSON file. Inside the file you can get the private key for the chosen service Account  
