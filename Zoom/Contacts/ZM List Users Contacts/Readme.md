#     Zoom


List User's Contacts

A user under an organizationâ€™s Zoom account has internal users listed under Company Contacts in the Zoom Client. A Zoom user can also add another Zoom user as a [contact](https://support.zoom.us/hc/en-us/articles/115004055706-Managing-Contacts). Call this API to list all the contacts of a Zoom user. Zoom contacts are categorized into "company contacts" and "external contacts". You must specify the contact type in the `type` query parameter. If you do not specify, by default, the type will be set as company contact.

 Note:  This API only supports user-managed OAuth app.

**Scope**: `chat_contact:read`
 

Method: Get

OperationID: getUserContacts

EndPoint:

/chat/users/me/contacts
