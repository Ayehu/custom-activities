<br>#     Zoom</br>
<br>List Recordings of an Account</br>
<br>List [Cloud Recordings](https://support.zoom.us/hc/en-us/articles/203741855-Cloud-Recording) available on an Account.

> To access a password protected cloud recording, add an "access_token" parameter to the download URL and provide [JWT](https://marketplace.zoom.us/docs/guides/getting-started/app-types/create-jwt-app) as the value of the "access_token".

**Prerequisites**:
* A Pro or a higher paid plan with Cloud Recording option enabled.
**Scopes**: `recording:read:admin` or `account:read:admin`

If the scope `recording:read:admin` is used, the Account ID of the Account must be provided in the `accountId` path parameter to list recordings that belong to the Account. This scope only works for Sub Accounts. 

To list recordings of a Master Account, the scope must be `account:read:admin` and the value of `accountId` should be `me`. 
</br>
<br>Method: Get</br>
<br>OperationID: getAccountCloudRecording</br>
<br>EndPoint:</br>
<br>/accounts/{accountId}/recordings</br>
