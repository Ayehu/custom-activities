<br>#     Github</br>
<br>Set selected organizations enabled for GitHub Actions in an enterprise</br>
<br>Replaces the list of selected organizations that are enabled for GitHub Actions in an enterprise. To use this endpoint, the enterprise permission policy for `enabled_organizations` must be configured to `selected`. For more information, see "[Set GitHub Actions permissions for an enterprise](#set-github-actions-permissions-for-an-enterprise)."

You must authenticate using an access token with the `admin:enterprise` scope to use this endpoint.</br>
<br>Method: Put</br>
<br>OperationID: enterprise-admin/set-selected-organizations-enabled-github-actions-enterprise</br>
<br>EndPoint:</br>
<br>/enterprises/{enterprise}/actions/permissions/organizations</br>
