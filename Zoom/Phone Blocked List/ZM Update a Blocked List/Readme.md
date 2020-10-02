#     Zoom


Update a Blocked List

A Zoom account owner or a user with admin privilege can block phone numbers for phone users in an account. Blocked numbers can be inbound (numbers will be blocked from calling in) and outbound (phone users in your account won't be able to dial those numbers). Blocked callers will hear a generic message stating that the person they are calling is not available.Use this API to update information on the blocked list.
**Prerequisites:**
* Pro or higher account plan with Zoom phone license
**Scope:** `phone:write:admin` 






Method: Patch

OperationID: updateBlockedList

EndPoint:

/phone/blocked_list/{blockedListId}
