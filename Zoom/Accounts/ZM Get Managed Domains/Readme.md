<br>#     Zoom</br>
<br>Get Managed Domains</br>
<br>Get a Sub Account's [managed domains](https://support.zoom.us/hc/en-us/articles/203395207-What-is-Managed-Domain-).

**Note:** This API can be used by Zoom Accounts that are on a Pro or a higher plan as well accounts that have Master and Sub Accounts options enabled. 
To get managed domains of the Master Account, provide `me` as the value for accountId in the path parameter. Provide the Sub Account's Account ID as the value of accountId path parameter to get managed domains of the Sub Account.

**Prerequisites:**
* Pro or a higher paid account with Master Account option enabled. 
**Scope:** `account:read:admin`
 

</br>
<br>Method: Get</br>
<br>OperationID: accountManagedDomain</br>
<br>EndPoint:</br>
<br>/accounts/{accountId}/managed_domains</br>
