<br>#     Github</br>
<br>Set SCIM information for a provisioned enterprise user</br>
<br>**Note:** The SCIM API endpoints for enterprise accounts are currently in beta and are subject to change.

Replaces an existing provisioned user's information. You must provide all the information required for the user as if you were provisioning them for the first time. Any existing user information that you don't provide will be removed. If you want to only update a specific attribute, use the [Update an attribute for a SCIM user](#update-an-attribute-for-an-enterprise-scim-user) endpoint instead.

You must at least provide the required values for the user: `userName`, `name`, and `emails`.

**Warning:** Setting `active: false` removes the user from the enterprise, deletes the external identity, and deletes the associated `{scim_user_id}`.</br>
<br>Method: Put</br>
<br>OperationID: enterprise-admin/set-information-for-provisioned-enterprise-user</br>
<br>EndPoint:</br>
<br>/scim/v2/enterprises/{enterprise}/Users/{scim_user_id}</br>
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
