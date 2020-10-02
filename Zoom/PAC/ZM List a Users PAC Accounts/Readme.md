#     Zoom


List a User's PAC Accounts

[Personal Audio Conference](https://support.zoom.us/hc/en-us/articles/204517069-Getting-Started-with-Personal-Audio-Conference) (PAC) allows Pro or higher account holders to host meetings through PSTN (phone dial-in) only.Use this API to list a user's PAC accounts.
**Scopes:** `user:read:admin` `user:read`

 
**Prerequisites:**
* A Pro or higher plan with [Premium Audio Conferencing](https://support.zoom.us/hc/en-us/articles/204517069-Getting-Started-with-Personal-Audio-Conference) add-on.
* Personal Audio Conference must be enabled in the user's profile.

Method: Get

OperationID: userPACs

EndPoint:

/users/{userId}/pac
