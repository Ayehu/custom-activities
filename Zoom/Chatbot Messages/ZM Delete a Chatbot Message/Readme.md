#     Zoom


Delete a Chatbot Message

Delete a message that was sent by your chatbot app. 

**Scopes:** `imchat:bot`

**Authorization Flow**: Client Credentials Flow
To get authorized, make a POST request to `/oauth/token` endpoint with grant type as `client_credentials`. Use `https://api.zoom.us/oauth/token?grant_type=client_credentials` as the endpoint for the request. 
You will need to send your ClientID and Secret as a Basic base64 encoded AUthorization header. Ex. `Basic base64Encode({client_id}:{client_sceret})` Next, use the token received (access_token) as a bearer token while making the DELETE /im/chat/messages/{message_id} request to delete a message.
Learn more about how to authotize chatbots in the [Chatbot Authorization](https://marketplace.zoom.us/docs/guides/chatbots/authorization) guide.

Method: Delete

OperationID: deleteAChatbotMessage

EndPoint:

/im/chat/messages/{message_id}
