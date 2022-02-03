<br>#     Zoom</br>
<br>Add Group Members</br>
<br>Add members to a [group](https://support.zoom.us/hc/en-us/articles/204519819-Group-Management-) under your account.

**Prerequisite**: Pro, Business, or Education account
**Scopes**: `group:write:admin`
 </br>
<br>Method: Post</br>
<br>OperationID: groupMembersCreate</br>
<br>EndPoint:</br>
<br>/groups/{groupId}/members</br>
<br>Usage: members[]</br>
<br>[{
  "id": "%id%",
  "email": "%email%"
}]</br>
