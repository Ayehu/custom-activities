#     Zoom


Invite Channel Members

A [channel](https://support.zoom.us/hc/en-us/articles/200912909-Getting-Started-With-Channels-Group-Messaging-) can have one or multiple members. Use this API to invite members that are in your contact list to a channel. The maximum number of members that can be added at once with this API is 5. 

Note: This API only supports user-managed OAuth app.

**Scope:** `chat_channel:write`
 

Method: Post

OperationID: inviteChannelMembers

EndPoint:

/chat/channels/{channelId}/members
