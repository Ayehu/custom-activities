## FreshDeskCreateTicket - Create a ticket in FreshDesk.

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
**Name**			- Company Name  
**Industry**		- Industry type  
**Domains**			- Comma separated domains (E.g.: mycompany1.com,mycompany2.com). Contacts whose email addresses contain these domains will be associated with this company  
**Description**		- Company description  
**Renewal Date**	- Contract renewal date  
**Health Score**	- Company health score  
**Account Tier**	- Company account tier
