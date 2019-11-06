
### ZendeskUpdateUser - Activity to update a user.

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

**UserId** - Specifies the user id of the updating user.

### Optional fields.
**Email** - Specifies the email of the updating user.

**Name** - Specifies the name of the updating user.

**Phone** - Specifies the phone of the updating user.

**Role** - Specifies the role of the updating user.

**Active** - Specifies the active status of the updating user.

**Verified** - Specifies the verification status of the updating user.

**Suspended** - Specifies the suspension status of the updating user.

### Zendesk API Reference.

[Update User](https://developer.zendesk.com/rest_api/docs/support/users#update-user)