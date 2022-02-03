<br>#     Zoom</br>
<br>List User's Chat Messages</br>
<br>A Zoom user can have conversations with other Zoom users via chat. Use this API to list the current user's chat messages between the user and an individual contact or a chat channel. In the query parameter, you must provide either of the following:
* `to_contact`: The email address of the contact with whom the user conversed by sending/receiving messages.
* `to_channel`: The channel ID of the channel to/from which the user has sent and/or received messages.
 **Specify a date** in the `date` query parameter to view messages from that date. If a date is not provided, the default value for the query will be the **current date**.
Note: This API only supports user-managed OAuth app.

**Scopes:** `chat_message:read`
 

</br>
<br>Method: Get</br>
<br>OperationID: getChatMessages</br>
<br>EndPoint:</br>
<br>/chat/users/{userId}/messages</br>
