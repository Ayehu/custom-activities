<br>#     Zoom</br>
<br>Update the Account Owner</br>
<br>The current account owner can [change the owner of an account](https://support.zoom.us/hc/en-us/articles/115005686983-Change-Account-Owner) to another user on the same account. Use this API to change the owner of a Sub Account.
 Your account must be a Master Account in order to use this API to update the account owner of a Sub Account. Zoom only assigns this privilege to trusted partners and only approved partners can use this API. Contact the [**ISV team**](https://zoom.us/plan/api) for more details. Please note that the created account user will receive a confirmation email.

**Prerequisites**:
* Account owner or admin permissions of an account.
* Pro or a higher plan with Master Account option enabled..

**Scopes:**  `account:write:admin` or `account:master`
 </br>
<br>Method: Put</br>
<br>OperationID: updateAccountOwner</br>
<br>EndPoint:</br>
<br>/accounts/{accountId}/owner</br>
