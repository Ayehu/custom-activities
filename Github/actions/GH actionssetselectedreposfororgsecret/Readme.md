<br>#     Github</br>
<br>Set selected repositories for an organization secret</br>
<br>Replaces all repositories for an organization secret when the `visibility` for repository access is set to `selected`. The visibility is set when you [Create or update an organization secret](https://developer.github.com/v3/actions/secrets/#create-or-update-an-organization-secret). You must authenticate using an access token with the `admin:org` scope to use this endpoint. GitHub Apps must have the `secrets` organization permission to use this endpoint.</br>
<br>Method: Put</br>
<br>OperationID: actions/set-selected-repos-for-org-secret</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/secrets/{secret_name}/repositories</br>
