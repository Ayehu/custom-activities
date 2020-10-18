<br>#     LogicMonitor</br>
<br>update user</br>
<br>LM update user</br>
<br>Method: Patch</br>
<br>OperationID: patchAdminById</br>
<br>EndPoint:</br>
<br>/setting/admins/{id}</br>
<br>Usage: apiTokens[]</br>
<br>[{
  "note": "%note%",
  "status": "%status%"
}]</br>
<br>Usage: roles[]</br>
<br>{
  "customHelpLabel": "%customHelpLabel%",
  "customHelpURL": "%customHelpURL%",
  "description": "%description%",
  "name": "%name%",
  "privileges": "[%privileges%]",
  "requireEULA": "%requireEULA%",
  "twoFARequired": "%twoFARequired%"
}</br>
