
### ZendeskCreateTicket - Activity to create a new ticket.

**DLL's to reference**
ZendeskApi_v2;

**Libraries to import**
System.Data;
System.Net;
ZendeskApi_v2;
ZendeskApi_v2.Models.Tickets;

### Mandatory fields when creating a checkpoint.
**Username** - Specifies the username of the Zendesk account.
**ApiToken** - Specifies the api token of the Zendesk account.
**Domain** - Specifies the sub domain of the Zendesk account.
**Comment** - Specifies the inital comment of the new ticket.
**Subject** - Specifies the subject of the new ticket.
**Type** - Specifies the type of the new ticket.
**Priority** - Specifies the priority of the new ticket.

### Zendesk API Reference.

[Create Ticket](https://developer.zendesk.com/rest_api/docs/support/tickets#create-ticket)