<br>#     Zoom</br>
<br>Invite Channel Members</br>
<br>A [channel](https://support.zoom.us/hc/en-us/articles/200912909-Getting-Started-With-Channels-Group-Messaging-) can have one or multiple members. Use this API to invite members that are in your contact list to a channel. The maximum number of members that can be added at once with this API is 5. 

Note: This API only supports user-managed OAuth app.

**Scope:** `chat_channel:write`
 </br>
<br>Method: Post</br>
<br>OperationID: inviteChannelMembers</br>
<br>EndPoint:</br>
<br>/chat/channels/{channelId}/members</br>
<br>Usage: members[]</br>
<br>[{
  "email": "%email%"
}]</br>
