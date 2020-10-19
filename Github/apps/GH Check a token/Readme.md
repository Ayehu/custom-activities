<br>#     Github</br>
<br>Check a token</br>
<br>OAuth applications can use a special API method for checking OAuth token validity without exceeding the normal rate limits for failed login attempts. Authentication works differently with this particular endpoint. You must use [Basic Authentication](https://developer.github.com/v3/auth#basic-authentication) to use this endpoint, where the username is the OAuth application `client_id` and the password is its `client_secret`. Invalid tokens will return `404 NOT FOUND`.</br>
<br>Method: Post</br>
<br>OperationID: apps/check-token</br>
<br>EndPoint:</br>
<br>/applications/{client_id}/token</br>
