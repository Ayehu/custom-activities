<br>#     Zoom</br>
<br>Create a Call Queue</br>
<br>Call queues allow you to route incoming calls to a group of users. For instance, you can use call queues to route calls to various departments in your organization such as sales, engineering, billing, customer service etc. Use this API to [create a call queue](https://support.zoom.us/hc/en-us/articles/360021524831-Managing-Call-Queues#h_e81faeeb-9184-429a-aaea-df49ff5ff413). You can add phone users or common area phones to call queues.

**Prerequisites:**
* Pro, Business, or Education account
* Account owner or admin permissions
* Zoom Phone license
**Scopes:** `phone:write:admin` 



</br>
<br>Method: Post</br>
<br>OperationID: createCallQueue</br>
<br>EndPoint:</br>
<br>/phone/call_queues</br>
<br>Usage: users[]</br>
<br>[{
  "id": "%id%",
  "email": "%email%"
}]</br>
