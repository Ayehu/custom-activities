<br>#     Github</br>
<br>Provision a SCIM enterprise group and invite users</br>
<br>**Note:** The SCIM API endpoints for enterprise accounts are currently in beta and are subject to change.

Provision an enterprise group, and invite users to the group. This sends invitation emails to the email address of the invited users to join the GitHub organization that the SCIM group corresponds to.</br>
<br>Method: Post</br>
<br>OperationID: enterprise-admin/provision-and-invite-enterprise-group</br>
<br>EndPoint:</br>
<br>/scim/v2/enterprises/{enterprise}/Groups</br>
<br>Usage: members[]</br>
<br>[{
  "value": "%value%"
}]</br>
