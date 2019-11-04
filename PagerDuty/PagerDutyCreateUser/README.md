# User Creation - Activity to create a new user in PagerDuty platform.

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in PagerDuty.
3. Create a team and add users there which will receive notifications.
4. Create a service.
5. Create an API User Token.

Mandatory fields when creating an incident :<br />
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | User -> My Profile -> User Settings -> Create API User Token<br />
From(string) - The email address of a valid user associated with the account making the request.<br />

Name(string) - New user's name.<br />
Email(string) - New user's email address.<br />
Role(string) - New user's role. Can be one of those values <br />
1. admin
2. limited_user
3. observer
4. owner
5. read_only_user
6. restricted_access
7. read_only_limited_user
8. user

Job Title(string) - New user's job title.<br />
Description(string) - New user's description.<br />
 