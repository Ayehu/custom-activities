#     Zoom


Delete a Blocked List

A Zoom account owner or a user with admin privilege can block phone numbers for phone users in an account. Blocked numbers can be inbound (numbers will be blocked from calling in) and outbound (phone users in your account won't be able to dial those numbers).
Use this API to delete a blocked list and therefore removing the associated number from the blocked list. The number will be unblocked after the deletion.
**Prerequisites:**
* Pro or higher account plan with Zoom phone license
**Scope:** `phone:write:admin` 







Method: Delete

OperationID: deleteABlockedList

EndPoint:

/phone/blocked_list/{blockedListId}
