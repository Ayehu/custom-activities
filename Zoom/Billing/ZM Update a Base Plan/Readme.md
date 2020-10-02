#     Zoom


Update a Base Plan

Update a base plan of a Sub Account.   Only a Master Account can use this API to update the base plan of a Sub Account whose billing charges are paid by the Master Account. Zoom only assigns this privilege to trusted partners and only approved partners can use this API. Contact the [**ISV team**](https://zoom.us/plan/api) for more details.
**Scopes:** `billing:master`
**Prerequisites:**
* The Sub Account must have a Pro or a higher plan.
 

Method: Put

OperationID: accountPlanBaseUpdate

EndPoint:

/accounts/{accountId}/plans/base
