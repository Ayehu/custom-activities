## FreshDeskDeleteTicket - Delete a ticket in FreshDesk.

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
**ID**				- Ticket ID
