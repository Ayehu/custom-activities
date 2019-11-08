
### ZendeskListUsers - Activity to get a list of all users.

**DLL's to reference**
ZendeskApi_v2;
Newtonsoft.Json;

**Libraries to import**
System.Data;
System.Linq;
System.Net;
ZendeskApi_v2;
ZendeskApi_v2.Models.Users;

### Mandatory fields.
**Username** - Specifies the username of the Zendesk account.

**ApiToken** - Specifies the api token of the Zendesk account.

**Domain** - Specifies the sub domain of the Zendesk account.

**UserType** -- Specifies the type of users, value can be "admin", "agent" and "end-user".

**This activity can retrive 1000 users per page**

### Zendesk API Reference.

[List Users](https://developer.zendesk.com/rest_api/docs/support/users#list-users)