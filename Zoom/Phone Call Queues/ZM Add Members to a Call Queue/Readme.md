<br>#     Zoom</br>
<br>Add Members to a Call Queue</br>
<br>Add phone users and/or [common area phones](https://support.zoom.us/hc/en-us/articles/360028516231-Managing-Common-Area-Phones) as members to a specific Call Queue.
**Prerequisites:**
* Pro or higher account plan.
* Zoom Phone license
**Scopes:** `phone:write:admin` 

</br>
<br>Method: Post</br>
<br>OperationID: addMembersToCallQueue</br>
<br>EndPoint:</br>
<br>/phone/call_queues/{callQueueId}/members</br>
<br>Usage: users[]</br>
<br>[{
  "id": "%id%",
  "email": "%email%"
}]</br>
