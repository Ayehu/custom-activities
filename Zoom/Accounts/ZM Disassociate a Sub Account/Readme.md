#     Zoom


Disassociate a Sub Account

Disassociate a Sub Account from the Master Account. This will leave the Sub Account intact but it will no longer be associated with the master account.  Your account must be a Master Account in order to disassociate Sub Accounts. Zoom only assigns this privilege to trusted partners and only approved partners can use this API. Contact the [**ISV team**](https://zoom.us/plan/api) for more details. 

**Prerequisites:**
* Pro or a higher paid account with Master Account option enabled. 
**Scope**: `account:write:admin`
 

Method: Delete

OperationID: accountDisassociate

EndPoint:

/accounts/{accountId}
