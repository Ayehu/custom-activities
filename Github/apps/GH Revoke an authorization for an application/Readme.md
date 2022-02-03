<br>#     Github</br>
<br>Revoke an authorization for an application</br>
<br>**Deprecation Notice:** GitHub will replace and discontinue OAuth endpoints containing `access_token` in the path parameter. We are introducing new endpoints that allow you to securely manage tokens for OAuth Apps by using `access_token` as an input parameter. The OAuth Application API will be removed on May 5, 2021. For more information, including scheduled brownouts, see the [blog post](https://developer.github.com/changes/2020-02-14-deprecating-oauth-app-endpoint/).

OAuth application owners can revoke a single token for an OAuth application. You must use [Basic Authentication](https://developer.github.com/v3/auth#basic-authentication) when accessing this endpoint, using the OAuth application's `client_id` and `client_secret` as the username and password.</br>
<br>Method: Delete</br>
<br>OperationID: apps/revoke-authorization-for-application</br>
<br>EndPoint:</br>
<br>/applications/{client_id}/tokens/{access_token}</br>
