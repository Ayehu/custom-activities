<br>#     Zoom</br>
<br>Send Chatbot Messages</br>
<br>Send chatbot messages from your marketplace chatbot app.
**Scopes:** `imchat:bot`
**Authorization Flow**: Client Credentials Flow
To get authorized, make a POST request to `/oauth/token` endpoint with grant type as `client_credentials`. Use `https://api.zoom.us/oauth/token?grant_type=client_credentials` as the endpoint for the request. 
You will need to send your ClientID and Secret as a Basic base64 encoded AUthorization header. Ex. `Basic base64Encode({client_id}:{client_sceret})` Next, use the token recieved (access_token) as a bearer token while making the POST /im/chat/messages request to send chatbot messages.
Learn more about how to authorize chatbots in the [Chatbot Authorization](https://marketplace.zoom.us/docs/guides/chatbots/authorization) guide.</br>
<br>Method: Post</br>
<br>OperationID: sendchatbot</br>
<br>EndPoint:</br>
<br>/im/chat/messages</br>
