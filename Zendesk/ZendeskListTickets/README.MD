
### ZendeskListTickets - Activity to get a list of all tickets.

**DLL's to reference**
ZendeskApi_v2;
Newtonsoft.Json;

**Libraries to import**
System.Data;
System.Linq;
System.Net;
Newtonsoft.Json;
Newtonsoft.Json.Linq;
ZendeskApi_v2;
ZendeskApi_v2.Models.Tickets;

### Mandatory fields.
**Username** - Specifies the username of the Zendesk account.

**ApiToken** - Specifies the api token of the Zendesk account.

**Domain** - Specifies the sub domain of the Zendesk account.

**This activity can retrive up to 1000 tickets**

### Zendesk API Reference.

[List Users](https://developer.zendesk.com/rest_api/docs/support/users#list-users)