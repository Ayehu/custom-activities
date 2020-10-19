<br>#     Github</br>
<br>Delete an app authorization</br>
<br>OAuth application owners can revoke a grant for their OAuth application and a specific user. You must use [Basic Authentication](https://developer.github.com/v3/auth#basic-authentication) when accessing this endpoint, using the OAuth application's `client_id` and `client_secret` as the username and password. You must also provide a valid OAuth `access_token` as an input parameter and the grant for the token's owner will be deleted.
Deleting an OAuth application's grant will also delete all OAuth tokens associated with the application for the user. Once deleted, the application will have no access to the user's account and will no longer be listed on [the application authorizations settings screen within GitHub](https://github.com/settings/applications#authorized).</br>
<br>Method: Delete</br>
<br>OperationID: apps/delete-authorization</br>
<br>EndPoint:</br>
<br>/applications/{client_id}/grant</br>
