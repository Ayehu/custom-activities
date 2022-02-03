<br>#     Github</br>
<br>Remove organization access to a self-hosted runner group in an enterprise</br>
<br>Removes an organization from the list of selected organizations that can access a self-hosted runner group. The runner group must have `visibility` set to `selected`. For more information, see "[Create a self-hosted runner group for an enterprise](#create-a-self-hosted-runner-group-for-an-enterprise)."

You must authenticate using an access token with the `admin:enterprise` scope to use this endpoint.</br>
<br>Method: Delete</br>
<br>OperationID: enterprise-admin/remove-org-access-to-self-hosted-runner-group-in-enterprise</br>
<br>EndPoint:</br>
<br>/enterprises/{enterprise}/actions/runner-groups/{runner_group_id}/organizations/{org_id}</br>
