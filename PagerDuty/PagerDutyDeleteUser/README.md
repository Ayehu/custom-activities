# Incident Creation - Activity to create a new incident in PagerDuty platform.

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in PagerDuty.
3. Create a team and add users there which will receive notifications.
4. Create a service.
5. Create an API User Token.

Mandatory fields when creating an incident :<br />
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | User -> My Profile -> User Settings -> Create API User Token<br />
User Id(string) - Get User Id from | Configuration -> Users , open the user and take id from URI (users/USER_ID) <br />
