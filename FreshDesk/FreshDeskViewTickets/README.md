## FreshDeskViewTickets - List all tickets in FreshDesk.

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
**Page Size**		- Line numbers to display in page  
**Page**			- Page number to be displayed  
**Query**			- Query according to the format described [here](https://developers.freshdesk.com/api/#filter_tickets), e.g.: "priority:3" to fetch all tickets with priority 3