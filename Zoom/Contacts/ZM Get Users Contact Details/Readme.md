#     Zoom


Get User's Contact Details

A user under an organizationâ€™s Zoom account has internal users listed under Company Contacts in the Zoom Client. A Zoom user can also add another Zoom user as a [contact](https://support.zoom.us/hc/en-us/articles/115004055706-Managing-Contacts). Call this API to get information on a specific contact of the Zoom user.

 Note: This API only supports user-managed OAuth app.

**Scope**: `chat_contact:read`
 

Method: Get

OperationID: getUserContact

EndPoint:

/chat/users/me/contacts/{contactId}
