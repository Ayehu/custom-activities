
### ZendeskUpdateTicket - Activity to update a ticket.

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

### Optional fields.
**Comment** - Specifies the new comment of the ticket.

**Subject** - Specifies the subject of the ticket.

**Type** - Specifies the type of the ticket.

**Priority** - Specifies the priority of the ticket.

If you want to set the status to hold, make sure all other fields are null, otherwise the system will return 402 exceptions.
### Zendesk API Reference.

[Update Ticket](https://developer.zendesk.com/rest_api/docs/support/tickets#update-ticket)