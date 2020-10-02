#     Zoom


Unassign a Phone Number

After assigning a phone number, you can unbind it if you don't want it to be assigned to a [Call Queue](https://support.zoom.us/hc/en-us/articles/360021524831-Managing-Call-Queues). Use this API to unbind a phone number from a Call Queue. After successful unbinding, the number will appear in the [Unassigned tab](https://zoom.us/signin#/numbers/unassigned).
**Prerequisites:**
* Pro or higher account palan
* Account owner or admin permissions
* Zoom Phone license  **Scopes:** `phone:write:admin` 



Method: Delete

OperationID: unAssignPhoneNumCallQueue

EndPoint:

/phone/call_queues/{callQueueId}/phone_numbers/{phoneNumberId}
