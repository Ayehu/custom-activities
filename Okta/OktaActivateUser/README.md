# Activate user - Activity to activate a user of Okta platform.

## Note
**Use [OktaSetPassword](https://github.com/Ayehu/custom-activities/tree/master/Okta/OktaSetPassword) activity immidiatly after in order to complete user activation.**<br />
**[Official documentation of activate user flow.](https://developer.okta.com/docs/reference/api/users/#activate-user)**

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in Okta.
2. Create a API token. You can create the User Token with following steps   API | Tokens | Create Token.
   URL - https://{{DOMAIN}}/admin/access/api/tokens (You can't see it later. Save at that time.).

Mandatory fields when creating a user :<br />
AuthorizationToken(string) - Use your existing API token which you get on step 2. Or create new one.<br />
Domain(string) - https://{{DOMAIN}}/dev/console. It will appear on any page when you are logged in.<br />

UserId(string) -  You can get the user id by clicking "Users" section from the top menu.  
				  Url - https://{{DOMAIN}}/admin/user/profile/view/{{UserId}} <br />
