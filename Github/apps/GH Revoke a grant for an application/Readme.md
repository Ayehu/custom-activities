<br>#     Github</br>
<br>Revoke a grant for an application</br>
<br>**Deprecation Notice:** GitHub will replace and discontinue OAuth endpoints containing `access_token` in the path parameter. We are introducing new endpoints that allow you to securely manage tokens for OAuth Apps by using `access_token` as an input parameter. The OAuth Application API will be removed on May 5, 2021. For more information, including scheduled brownouts, see the [blog post](https://developer.github.com/changes/2020-02-14-deprecating-oauth-app-endpoint/).

OAuth application owners can revoke a grant for their OAuth application and a specific user. You must use [Basic Authentication](https://developer.github.com/v3/auth#basic-authentication) when accessing this endpoint, using the OAuth application's `client_id` and `client_secret` as the username and password. You must also provide a valid token as `:access_token` and the grant for the token's owner will be deleted.

Deleting an OAuth application's grant will also delete all OAuth tokens associated with the application for the user. Once deleted, the application will have no access to the user's account and will no longer be listed on [the Applications settings page under "Authorized OAuth Apps" on GitHub](https://github.com/settings/applications#authorized).</br>
<br>Method: Delete</br>
<br>OperationID: apps/revoke-grant-for-application</br>
<br>EndPoint:</br>
<br>/applications/{client_id}/grants/{access_token}</br>
