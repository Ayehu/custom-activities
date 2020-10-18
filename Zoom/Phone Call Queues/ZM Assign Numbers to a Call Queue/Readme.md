<br>#     Zoom</br>
<br>Assign Numbers to a Call Queue</br>
<br>After [buying phone number(s)](https://support.zoom.us/hc/en-us/articles/360020808292#h_007ec8c2-0914-4265-8351-96ab23efa3ad), you can assign it, allowing callers to directly dial a number to reach a [call queue](https://support.zoom.us/hc/en-us/articles/360021524831-Managing-Call-Queues).
**Prerequisites:**
* Pro or higher account plan.
* Account owner or admin permissions
* Zoom Phone license
**Scopes:** `phone:write:admin` 

</br>
<br>Method: Post</br>
<br>OperationID: assignPhoneToCallQueue</br>
<br>EndPoint:</br>
<br>/phone/call_queues/{callQueueId}/phone_numbers</br>
<br>Usage: phone_numbers[]</br>
<br>[{
  "id": "%id%",
  "number": "%number%"
}]</br>
