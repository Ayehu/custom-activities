#     Zoom


Unassign User's Calling Plan

Unassign a [calling plan](https://marketplace.zoom.us/docs/api-reference/other-references/plans#zoom-phone-calling-plans) that was previously assigned to a [Zoom Phone](https://support.zoom.us/hc/en-us/categories/360001370051) user.

**Scopes**: `phone:write` `phone:write:admin` 
**Prerequisite:** 
1. Business or Enterprise account
2. A Zoom Phone license

Method: Delete

OperationID: unassignCallingPlan

EndPoint:

/phone/users/{userId}/calling_plans/{type}
