<br>#     Github</br>
<br>Get allowed actions for an enterprise</br>
<br>Gets the selected actions that are allowed in an enterprise. To use this endpoint, the enterprise permission policy for `allowed_actions` must be configured to `selected`. For more information, see "[Set GitHub Actions permissions for an enterprise](#set-github-actions-permissions-for-an-enterprise)."

You must authenticate using an access token with the `admin:enterprise` scope to use this endpoint.</br>
<br>Method: Get</br>
<br>OperationID: enterprise-admin/get-allowed-actions-enterprise</br>
<br>EndPoint:</br>
<br>/enterprises/{enterprise}/actions/permissions/selected-actions</br>
