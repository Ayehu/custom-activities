<br>#     Zoom</br>
<br>Unassign a Member</br>
<br>Use this API to remove a member from a Call Queue who was previously added to that Call Queue. The member could be a phone user or a [common area phone](https://support.zoom.us/hc/en-us/articles/360028516231-Managing-Common-Area-Phones). A member who is a Call Queue Manager cannot be unassigned from the Call Queue using this API. 
**Prerequisites:**
* Pro or higher account plan.
* Zoom Phone license
**Scopes:** `phone:write:admin` 

</br>
<br>Method: Delete</br>
<br>OperationID: unassignMemberFromCallQueue</br>
<br>EndPoint:</br>
<br>/phone/call_queues/{callQueueId}/members/{memberId}</br>
