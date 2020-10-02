#     Zoom


Join a Channel

A [channel](https://support.zoom.us/hc/en-us/articles/200912909-Getting-Started-With-Channels-Group-Messaging-) can have one or multiple members. Use this API to join a channel that is open for anyone in the same organization to join. You cannot use this API to join private channels that only allows invited members to be a part of it.

 Note: This API only supports user-managed OAuth app.

**Scope:** `chat_channel:write`
 

Method: Post

OperationID: joinChannel

EndPoint:

/chat/channels/{channelId}/members/me
