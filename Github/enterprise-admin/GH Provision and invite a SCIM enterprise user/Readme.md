<br>#     Github</br>
<br>Provision and invite a SCIM enterprise user</br>
<br>**Note:** The SCIM API endpoints for enterprise accounts are currently in beta and are subject to change.

Provision enterprise membership for a user, and send organization invitation emails to the email address.

You can optionally include the groups a user will be invited to join. If you do not provide a list of `groups`, the user is provisioned for the enterprise, but no organization invitation emails will be sent.</br>
<br>Method: Post</br>
<br>OperationID: enterprise-admin/provision-and-invite-enterprise-user</br>
<br>EndPoint:</br>
<br>/scim/v2/enterprises/{enterprise}/Users</br>
<br>Usage: emails[]</br>
<br>[{
  "value": "%value%",
  "type": "%type%",
  "primary": "%primary%"
}]</br>
<br>Usage: groups[]</br>
<br>[{
  "value": "%groups_value%"
}]</br>
