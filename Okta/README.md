# Okta 
**Okta is the identity standard.**

[Okta website](https://www.okta.com/) <br/>
[Official documentation](https://developer.okta.com/docs/)

# Okta Activities

## Dependencies:
1. Newtonsoft.Json

## Remarks:
1. Create an account in Okta.
2. Create a API token. You can create the User Token with following steps   API | Tokens | Create Token.
   URL - https://{{DOMAIN}}/admin/access/api/tokens (You can't see it later. Save at that time.).

## Mandatory fields for using api :<br />
1. AuthorizationToken(string) - Use your existing API token which you get on step 2. Or create new one.<br />
2. Domain(string) - https://{{DOMAIN}}/dev/console. It will appear on any page when you are logged in.<br />
