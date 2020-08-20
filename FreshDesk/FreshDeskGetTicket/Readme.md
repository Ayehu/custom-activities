## FreshDeskViewTickets - List all tickets in FreshDesk.

##### DLL's to reference
Newtonsoft.Json.dll  

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;<br>
using Ayehu.Sdk.ActivityCreation.Extension;<br>
using System;<br>
using System.Text;<br>
using System.Net;<br>
using Newtonsoft.Json;<br>
using Newtonsoft.Json.Linq;<br>
using System.IO;<br>

### Mandatory fields:

**Instance URL**	- Your instance's base URL (e.g. mycompany.freshservice.com)  .
**Username**			- Username with which to authenticate.
**Password**      - Password with which to authenticate.
**Ticket ID**     - The display ID of the ticket.
