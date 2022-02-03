<br>#     Github</br>
<br>Reset a token</br>
<br>OAuth applications can use this API method to reset a valid OAuth token without end-user involvement. Applications must save the "token" property in the response because changes take effect immediately. You must use [Basic Authentication](https://developer.github.com/v3/auth#basic-authentication) when accessing this endpoint, using the OAuth application's `client_id` and `client_secret` as the username and password. Invalid tokens will return `404 NOT FOUND`.</br>
<br>Method: Patch</br>
<br>OperationID: apps/reset-token</br>
<br>EndPoint:</br>
<br>/applications/{client_id}/token</br>
