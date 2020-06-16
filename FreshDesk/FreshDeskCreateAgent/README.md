## FreshDeskCreateAgent - Create an agent in FreshDesk.

##### DLL's to reference
Newtonsoft.Json.dll  

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

### Mandatory fields:

**Subdomain name**	- Subdomain name (E.g.: get subdomain from subdomain.freshdesk.com)  
**API Key**			- API key available on profile settings page  
**Email**			- Agent e-mail  
**Name**			- Agent name  
**Language**		- Language of the agent  
**Group ID's**		- Comma separated Group ID's agent (e.g.: 1,2,4)  
**Role ID's**		- Comma separated Role ID's agent (e.g.: 1,2,4)  
**Skill ID's**		- Comma separated Skill ID's agent (e.g.: 1,2,4)  
