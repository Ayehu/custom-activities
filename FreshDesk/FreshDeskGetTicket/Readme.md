## FreshDeskGetTicket - Retrieve information on an individual FreshDesk ticket.

### DLLs to reference
Newtonsoft.Json.dll

### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;<br>
using Ayehu.Sdk.ActivityCreation.Extension;<br>
using System;<br>
using System.Text;<br>
using System.Net;<br>
using Newtonsoft.Json;<br>
using Newtonsoft.Json.Linq;<br>
using System.IO;<br>

### Mandatory fields:
**Instance URL**	- Your instance's base URL (e.g. mycompany.freshservice.com).<br>
**Username**			- Username with which to authenticate.<br>
**Password**      - Password with which to authenticate.<br>
**Ticket ID**     - The display ID of the ticket.
