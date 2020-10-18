<br>#     Zoom</br>
<br>Update a Message</br>
<br>Each chat message has a unique identifier. Use this API to edit a chat message that you previously sent to either a contact or a channel in Zoom by providing the ID of the message as the value of the `messageId` parameter. The ID can be retrieved from List User's Chat Messages API. Additionally, as a query parameter, you must provide either the **email address** of the contact or the **Channel ID** of the channel where the message was sent. 

 Note:  This API only supports user-managed OAuth app.

**Scope:** `chat_message:write`	
 



</br>
<br>Method: Put</br>
<br>OperationID: editMessage</br>
<br>EndPoint:</br>
<br>/chat/users/me/messages/{messageId}</br>
