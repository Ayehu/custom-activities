
### ZendeskCreateTicket - Activity to create a new ticket.

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
**Comment** - Specifies the inital comment of the new ticket.

**Subject** - Specifies the subject of the new ticket.

**Type** - Specifies the type of the new ticket.

**Priority** - Specifies the priority of the new ticket.

When creating a new ticket, if the subject is null and the comment contains text content, the system will automatically set the first few words of the comment as the subject.

### Zendesk API Reference.

[Create Ticket](https://developer.zendesk.com/rest_api/docs/support/tickets#create-ticket)