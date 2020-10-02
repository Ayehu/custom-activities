#     Zoom


Update a User's Password

Update the [password](https://support.zoom.us/hc/en-us/articles/206344385-Change-a-User-s-Password) of a user using which the user can login to Zoom. After this request is processed successfully, an email notification will be sent to the user stating that the password was changed.
**Scopes:** `user:write:admin` `user:write`
 
**Prerequisites:**
* Owner or admin of the Zoom account.

Method: Put

OperationID: userPassword

EndPoint:

/users/{userId}/password
