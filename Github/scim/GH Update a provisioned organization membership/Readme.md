<br>#     Github</br>
<br>Update a provisioned organization membership</br>
<br>Replaces an existing provisioned user's information. You must provide all the information required for the user as if you were provisioning them for the first time. Any existing user information that you don't provide will be removed. If you want to only update a specific attribute, use the [Update an attribute for a SCIM user](https://developer.github.com/v3/scim/#update-an-attribute-for-a-scim-user) endpoint instead.

You must at least provide the required values for the user: `userName`, `name`, and `emails`.

**Warning:** Setting `active: false` removes the user from the organization, deletes the external identity, and deletes the associated `{scim_user_id}`.</br>
<br>Method: Put</br>
<br>OperationID: scim/set-information-for-provisioned-user</br>
<br>EndPoint:</br>
<br>/scim/v2/organizations/{org}/Users/{scim_user_id}</br>
<br>Usage: emails[]</br>
<br>[{
  "type": "%type%",
  "value": "%value%",
  "primary": "%primary%"
}]</br>
