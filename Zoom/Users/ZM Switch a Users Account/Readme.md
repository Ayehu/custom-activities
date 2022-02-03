<br>#     Zoom</br>
<br>Switch a User's Account</br>
<br>Disassociate a user from one Account and move the user to another Account under the same Master Account. 

With this API, a user under a Master Account or a Sub Account can be moved to another Sub Account within the same Master Account. To move a user from a Master Account to a Sub Account, use `me` as the value for `accountId`. In this scenario, "me" refers to the Account ID of the Master Account. 

To move a user from one Sub Account to another Sub Account, provide the Sub Account's Account ID as the value for `accountId`. 

**Prerequisites**:
* The account should have Pro or a higher plan with Master Account option enabled.
* The user whose account needs to be switched should not be an admin or an owner of that account.
* The user should not have the same [managed domain](https://support.zoom.us/hc/en-us/articles/203395207-What-is-Managed-Domain-) as the account owner.

**Scope:** `user:master` 
</br>
<br>Method: Put</br>
<br>OperationID: switchUserAccount</br>
<br>EndPoint:</br>
<br>/accounts/{accountId}/users/{userId}/account</br>
