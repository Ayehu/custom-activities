<br>#     Zoom</br>
<br>Unassign User's Calling Plan</br>
<br>Unassign a [calling plan](https://marketplace.zoom.us/docs/api-reference/other-references/plans#zoom-phone-calling-plans) that was previously assigned to a [Zoom Phone](https://support.zoom.us/hc/en-us/categories/360001370051) user.

**Scopes**: `phone:write` `phone:write:admin` 
**Prerequisite:** 
1. Business or Enterprise account
2. A Zoom Phone license</br>
<br>Method: Delete</br>
<br>OperationID: unassignCallingPlan</br>
<br>EndPoint:</br>
<br>/phone/users/{userId}/calling_plans/{type}</br>
