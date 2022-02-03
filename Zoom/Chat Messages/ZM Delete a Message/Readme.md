<br>#     Zoom</br>
<br>Delete a Message</br>
<br>Delete a chat message that you previously sent to a contact or a channel. In the query parameter, you must provide either of the following:
* `to_contact`: The email address of the contact to whom you sent the message. Use this parameter to delete a message sent to an individual contact in Zoom.
* `to_channel`: The channel ID of the channel where you sent the message. Use this parameter to delete a message sent to a channel in Zoom.

 Note: This API only supports user-managed OAuth app.

**Scope:** `chat_message:write`
 
</br>
<br>Method: Delete</br>
<br>OperationID: deleteChatMessage</br>
<br>EndPoint:</br>
<br>/chat/users/me/messages/{messageId}</br>
