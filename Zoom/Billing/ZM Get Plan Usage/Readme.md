#     Zoom


Get Plan Usage

Get information on usage of [plans](https://marketplace.zoom.us/docs/api-reference/other-references/plans) of a Sub Account or a Master Account. To get plan usage for Master Account, provide the keyword "me" as the value of the `accountId` path parameter. To get plan usage of Sub Accounts, provide the actual account Id of the Sub Account as the value of the `accountId` path parameter. 

**Prerequisite**:
Account type: Master Account on a paid Pro, Business or Enterprise plan.
**Scope:** `billing:master`
 

Method: Get

OperationID: getPlanUsage

EndPoint:

/accounts/{accountId}/plans/usage
