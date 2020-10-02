#     Zoom


Update Billing Information

Update [billing information](https://support.zoom.us/hc/en-us/articles/201363263-About-Billing) for a Sub Account under a Master account. This API can only be used to update Billing information of Pro or higher Sub Accounts whose billing charges are paid by their Master account. Only Master Accounts can use this API. Zoom only assigns this privilege to trusted partners and only approved partners can use this API. Contact the [**ISV team**](https://zoom.us/plan/api) for more details.

**Prerequisites:**
* Pro or a higher paid account with Master Account option enabled. 
**Scope**:`billing:master`
 

Method: Patch

OperationID: accountBillingUpdate

EndPoint:

/accounts/{accountId}/billing
