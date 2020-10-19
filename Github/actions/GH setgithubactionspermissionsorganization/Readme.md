<br>#     Github</br>
<br>Set GitHub Actions permissions for an organization</br>
<br>Sets the GitHub Actions permissions policy for repositories and allowed actions in an organization.

If the organization belongs to an enterprise that has set restrictive permissions at the enterprise level, such as `allowed_actions` to `selected` actions, then you cannot override them for the organization.

You must authenticate using an access token with the `admin:org` scope to use this endpoint. GitHub Apps must have the `administration` organization permission to use this API.</br>
<br>Method: Put</br>
<br>OperationID: actions/set-github-actions-permissions-organization</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/permissions</br>
