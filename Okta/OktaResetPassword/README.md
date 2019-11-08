#Reset user  password- Activity to reset user password on Okta platform.

Remark:
1. Create an account in Okta.
2. Create a API token. You can create the User Token with following steps   API | Tokens | Create Token.
   URL - https://{{DOMAIN}}/admin/access/api/tokens (You can't see it later. Save at that time.).

Mandatory fields when resetting user password:<br />
AuthorizationToken(string) - Use your existing API token which you get on step 2. Or create new one.<br />

Domain(string) - https://{{DOMAIN}}/dev/console. It will appear on any page when you are logged in.<br />

UserId(string) -  You can get the user id by clicking "Users" section from the top menu.  
				  Url - https://{{DOMAIN}}/admin/user/profile/view/{{UserId}} <br />