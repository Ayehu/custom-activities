<br>#     Zoom</br>
<br>Unassign a Phone Number</br>
<br>After assigning a phone number, you can unbind it if you don't want it to be assigned to a [Call Queue](https://support.zoom.us/hc/en-us/articles/360021524831-Managing-Call-Queues). Use this API to unbind a phone number from a Call Queue. After successful unbinding, the number will appear in the [Unassigned tab](https://zoom.us/signin#/numbers/unassigned).
**Prerequisites:**
* Pro or higher account palan
* Account owner or admin permissions
* Zoom Phone license  **Scopes:** `phone:write:admin` 

</br>
<br>Method: Delete</br>
<br>OperationID: unAssignPhoneNumCallQueue</br>
<br>EndPoint:</br>
<br>/phone/call_queues/{callQueueId}/phone_numbers/{phoneNumberId}</br>
