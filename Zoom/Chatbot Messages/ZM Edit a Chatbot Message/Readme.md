<br>#     Zoom</br>
<br>Edit a Chatbot Message</br>
<br>Edit a message that was [sent](https://marketplace.zoom.us/docs/api-reference/zoom-api/im-chat/sendchatbot) by your Chatbot app. After sending a message using the Send Chatbot Message API, you must store the messageId returned in the response so that you can make edits to the associated message using this API.

**Scope:** `imchat:bot`
**Authorization Flow**: Client Credentials Flow
To get authorized, make a POST request to `/oauth/token` endpoint with grant type as `client_credentials`. Use `https://api.zoom.us/oauth/token?grant_type=client_credentials` as the endpoint for the request. 
You will need to send your ClientID and Secret as a Basic base64 encoded AUthorization header. Ex. `Basic base64Encode({client_id}:{client_sceret})` Next, use the token received (access_token) as a bearer token while making the PUT /im/chat/messages/{message_id} request to edit a chatbot message.
Learn more about how to authotize chatbots in the [Chatbot Authorization](https://marketplace.zoom.us/docs/guides/chatbots/authorization) guide.</br>
<br>Method: Put</br>
<br>OperationID: editChatbotMessage</br>
<br>EndPoint:</br>
<br>/im/chat/messages/{message_id}</br>
