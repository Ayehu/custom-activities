<br>#     LogicMonitor</br>
<br>add user</br>
<br>LM add user</br>
<br>Method: Post</br>
<br>OperationID: addAdmin</br>
<br>EndPoint:</br>
<br>/setting/admins</br>
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
