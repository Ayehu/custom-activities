<br>#     Zoom</br>
<br>Add IM Directory Group Members</br>
<br>Add members to an [IM directory group](https://support.zoom.us/hc/en-us/articles/203749815-IM-Management) under an account.
**Scope:** `imgroup:write:admin`
 </br>
<br>Method: Post</br>
<br>OperationID: imGroupMembersCreate</br>
<br>EndPoint:</br>
<br>/im/groups/{groupId}/members</br>
<br>Usage: members[]</br>
<br>[{
  "id": "%id%",
  "email": "%email%"
}]</br>
