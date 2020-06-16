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
**Status**			- Ticket status  
**Priority**		- Ticket priority  
**Email**			- Email of the requester  
**Subject**			- Subject of the ticket  
**Description**		- Description of the ticket  
**Custom Fields**	- Custom fiedls in JSON format. e.g.: { "field_key1": "field_value1", "field_key2": "field_value2" } (Read [here](https://support.freshdesk.com/support/solutions/articles/216548) for details)  
**Attachment**		- Path for file to be attached
