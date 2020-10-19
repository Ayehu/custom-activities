<br>#     Github</br>
<br>Get allowed actions for an organization</br>
<br>Gets the selected actions that are allowed in an organization. To use this endpoint, the organization permission policy for `allowed_actions` must be configured to `selected`. For more information, see "[Set GitHub Actions permissions for an organization](#set-github-actions-permissions-for-an-organization).""

You must authenticate using an access token with the `admin:org` scope to use this endpoint. GitHub Apps must have the `administration` organization permission to use this API.</br>
<br>Method: Get</br>
<br>OperationID: actions/get-allowed-actions-organization</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/permissions/selected-actions</br>
