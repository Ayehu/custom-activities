# Create user - Activity to create user in Okta platform.

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in Okta.
2. Create a API token. You can create the User Token with following steps   API | Tokens | Create Token.
   URL - https://{{DOMAIN}}/admin/access/api/tokens (You can't see it later. Save at that time.).

Mandatory fields when creating a user :<br />
AuthorizationToken(string) - Use your existing API token which you get on step 2. Or create new one.<br />

Domain(string) - https://{{DOMAIN}}/dev/console. It will appear on any page when you are logged in.<br />

FirstName(string) - New user's first name.<br />
LastName(string) - New user's last name.<br />
Email(string) - New user's email address/login.<br />
Password(string) - New user's password.<br />
Activate(boolean) - Should it create activated user or not? Can be "yes" or "no". <br />

Optional Fields: <br />
MobilePhone - New user's phone number.