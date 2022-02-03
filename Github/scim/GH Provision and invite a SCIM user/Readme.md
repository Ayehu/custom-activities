<br>#     Github</br>
<br>Provision and invite a SCIM user</br>
<br>Provision organization membership for a user, and send an activation email to the email address.</br>
<br>Method: Post</br>
<br>OperationID: scim/provision-and-invite-user</br>
<br>EndPoint:</br>
<br>/scim/v2/organizations/{org}/Users</br>
<br>Usage: emails[]</br>
<br>[{
  "value": "%value%",
  "primary": "%primary%",
  "type": "%type%"
}]</br>
