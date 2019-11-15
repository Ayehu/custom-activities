# List users - Activity for getting users from Okta platform.

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in Okta.
2. Create a API token. You can create the User Token with following steps   API | Tokens | Create Token.
   URL - https://{{DOMAIN}}/admin/access/api/tokens (You can't see it later. Save at that time.).

Mandatory fields when getting users password:<br />
AuthorizationToken(string) - Use your existing API token which you get on step 2. Or create new one.<br />

Domain(string) - https://{{DOMAIN}}/dev/console. It will appear on any page when you are logged in.<br />

Optional fields:
Status(string) - Fitleres users by their status. Could be one of <br />
1. ACTIVE <br /> 
2. PROVISIONED <br />
3. STAGED <br />
4. RECOVERY <br />
5. DEPROVISIONED <br />
6. PASSWORD_EXPIRED <br />
