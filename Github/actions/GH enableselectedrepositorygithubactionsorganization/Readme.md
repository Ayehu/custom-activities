<br>#     Github</br>
<br>Enable a selected repository for GitHub Actions in an organization</br>
<br>Adds a repository to the list of selected repositories that are enabled for GitHub Actions in an organization. To use this endpoint, the organization permission policy for `enabled_repositories` must be must be configured to `selected`. For more information, see "[Set GitHub Actions permissions for an organization](#set-github-actions-permissions-for-an-organization)."

You must authenticate using an access token with the `admin:org` scope to use this endpoint. GitHub Apps must have the `administration` organization permission to use this API.</br>
<br>Method: Put</br>
<br>OperationID: actions/enable-selected-repository-github-actions-organization</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/permissions/repositories/{repository_id}</br>
