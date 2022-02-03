<br>#     Zoom</br>
<br>Unassign all Phone Numbers</br>
<br>Use this API to unbind all phone numbers that are assigned to a [Call Queue](https://support.zoom.us/hc/en-us/articles/360021524831-Managing-Call-Queues) After successful unbinding, the numbers will appear in the [Unassigned tab](https://zoom.us/signin#/numbers/unassigned). If you only need to unassign a specific phone number, use the Unassign a Phone Number API instead. 
**Prerequisites:**
* Pro or higher account palan
* Account owner or admin permissions
* Zoom Phone license  **Scopes:** `phone:write:admin` 

</br>
<br>Method: Delete</br>
<br>OperationID: unassignAPhoneNumCallQueue</br>
<br>EndPoint:</br>
<br>/phone/call_queues/{callQueueId}/phone_numbers</br>
