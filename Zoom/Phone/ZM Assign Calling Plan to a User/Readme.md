<br>#     Zoom</br>
<br>Assign Calling Plan to a User</br>
<br>Assign [calling plan](https://marketplace.zoom.us/docs/api-reference/other-references/plans#zoom-phone-calling-plans) to a [Zoom Phone](https://support.zoom.us/hc/en-us/categories/360001370051-Zoom-Phone) user.

**Scopes**: `phone:write` `phone:write:admin` 
**Prerequisite:** 
1. Business or Enterprise account
2. A Zoom Phone license

</br>
<br>Method: Post</br>
<br>OperationID: assignCallingPlan</br>
<br>EndPoint:</br>
<br>/phone/users/{userId}/calling_plans</br>
<br>Usage: calling_plans[]</br>
<br>[{
  "type": "%type%"
}]</br>
