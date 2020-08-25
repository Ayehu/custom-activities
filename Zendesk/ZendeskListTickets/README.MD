
### ZendeskListTickets - Activity to get a list of all tickets.

**DLL's to reference**
ZendeskApi_v2;<br>
Newtonsoft.Json;<br>

**Libraries to import**
System.Data;<br>
System.Linq;<br>
System.Net;<br>
Newtonsoft.Json;<br>
Newtonsoft.Json.Linq;<br>
ZendeskApi_v2;<br>
ZendeskApi_v2.Models.Tickets;<br>

### Mandatory fields.
**Username** - Specifies the username of the Zendesk account.

**ApiToken** - Specifies the api token of the Zendesk account.

**Domain** - Specifies the sub domain of the Zendesk account.

**Page** - Specifies the page number, each page can retrieve 1000 tickets (default page number is 1, which retrieves the first 1000 tickets).

### Optional fields.

**Type** - Specifies the type of the tickets.

**Priority** -Specifies the priority of the tickets.

**Status** - Specifies the status of the tickets.

**This activity can retrive 1000 tickets per page**

### Zendesk API Reference.

[List Tickets](https://developer.zendesk.com/rest_api/docs/support/tickets#list-tickets)
