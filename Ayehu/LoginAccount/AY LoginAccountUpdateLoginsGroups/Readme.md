<br>#     Ayehu</br>
<br>AY LoginAccountUpdateLoginsGroups</br>
<br>Method: Put</br>
<br>OperationID: LoginAccount_UpdateLoginsGroups</br>
<br>EndPoint:</br>
<br>/Api/loginAccount/updateLoginsGroups</br>
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
