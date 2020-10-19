<br>#     Github</br>
<br>Set SCIM information for a provisioned enterprise group</br>
<br>**Note:** The SCIM API endpoints for enterprise accounts are currently in beta and are subject to change.

Replaces an existing provisioned group’s information. You must provide all the information required for the group as if you were provisioning it for the first time. Any existing group information that you don't provide will be removed, including group membership. If you want to only update a specific attribute, use the [Update an attribute for a SCIM enterprise group](#update-an-attribute-for-a-scim-enterprise-group) endpoint instead.</br>
<br>Method: Put</br>
<br>OperationID: enterprise-admin/set-information-for-provisioned-enterprise-group</br>
<br>EndPoint:</br>
<br>/scim/v2/enterprises/{enterprise}/Groups/{scim_group_id}</br>
<br>Usage: members[]</br>
<br>[{
  "value": "%value%"
}]</br>
