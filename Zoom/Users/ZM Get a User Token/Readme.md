<br>#     Zoom</br>
<br>Get a User Token</br>
<br>Retrieve a user's token. This token is used for starting meetings with the Client SDK.
**Scopes:** `user:read:admin` `user:read`
If a user signed into Zoom using Google or Facebook, a null value will be returned for the token. To get the token with this API, ask the user to sign into Zoom using their email and password instead.</br>
<br>Method: Get</br>
<br>OperationID: userToken</br>
<br>EndPoint:</br>
<br>/users/{userId}/token</br>
