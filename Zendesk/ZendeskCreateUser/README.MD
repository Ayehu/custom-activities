
### ZendeskCreateUser - Activity to create a new user.

**DLL's to reference**
ZendeskApi_v2;

**Libraries to import**
System.Data;
System.Net;
ZendeskApi_v2;
ZendeskApi_v2.Models.Users;

### Mandatory fields.
**Username** - Specifies the username of the Zendesk account.

**ApiToken** - Specifies the api token of the Zendesk account.

**Domain** - Specifies the sub domain of the Zendesk account.

**Email** - Specifies the email of the new user.

**Name** - Specifies the name of the new user.

### Optional fields.
**Phone** - Specifies the phone of the new user.

**Role** - Specifies the role of the new user.

**Active** - Specifies the active status of the new user.

**Verified** - Specifies the verification status of the new user.


### Zendesk API Reference.

[Create User](https://developer.zendesk.com/rest_api/docs/support/users#create-user)