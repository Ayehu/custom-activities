
### ZendeskDeleteTicket - Activity to delete an existing ticket.

**DLL's to reference**
ZendeskApi_v2;

**Libraries to import**
System.Data;
System.Net;
ZendeskApi_v2;
ZendeskApi_v2.Models.Tickets;

### Mandatory fields.
**Username** - Specifies the username of the Zendesk account.
**ApiToken** - Specifies the api token of the Zendesk account.
**Domain** - Specifies the sub domain of the Zendesk account.
**TicketId** - Specifies the ticket id.

### Zendesk API Reference.

[Delete Ticket](https://developer.zendesk.com/rest_api/docs/support/tickets#delete-ticket)