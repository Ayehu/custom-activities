<br>#     Ayehu</br>
<br>AY RecipientAccountCreateUserGroup</br>
<br>Method: Post</br>
<br>OperationID: RecipientAccount_CreateUserGroup</br>
<br>EndPoint:</br>
<br>/Api/recipients/createUserGroup</br>
<br>Usage: owners[]</br>
<br>[{
  "activeDirectoryId": "%owners_activeDirectoryId%",
  "userGroupId": "%userGroupId%",
  "name": "%owners_name%",
  "id": "%owners_id%"
}]</br>
<br>Usage: groupMembers[]</br>
<br>[{
  "permissionType": "%permissionType%",
  "orderIndex": "%orderIndex%",
  "activeDirectoryId": "%groupMembers_activeDirectoryId%",
  "userGroupId": "%groupMembers_userGroupId%",
  "name": "%groupMembers_name%",
  "id": "%groupMembers_id%"
}]</br>
