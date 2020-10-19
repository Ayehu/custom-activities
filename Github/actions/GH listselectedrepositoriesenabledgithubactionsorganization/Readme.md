<br>#     Github</br>
<br>List selected repositories enabled for GitHub Actions in an organization</br>
<br>Lists the selected repositories that are enabled for GitHub Actions in an organization. To use this endpoint, the organization permission policy for `enabled_repositories` must be configured to `selected`. For more information, see "[Set GitHub Actions permissions for an organization](#set-github-actions-permissions-for-an-organization)."

You must authenticate using an access token with the `admin:org` scope to use this endpoint. GitHub Apps must have the `administration` organization permission to use this API.</br>
<br>Method: Get</br>
<br>OperationID: actions/list-selected-repositories-enabled-github-actions-organization</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/permissions/repositories</br>
