<br>#     Github</br>
<br>Add selected repository to an organization secret</br>
<br>Adds a repository to an organization secret when the `visibility` for repository access is set to `selected`. The visibility is set when you [Create or update an organization secret](https://developer.github.com/v3/actions/secrets/#create-or-update-an-organization-secret). You must authenticate using an access token with the `admin:org` scope to use this endpoint. GitHub Apps must have the `secrets` organization permission to use this endpoint.</br>
<br>Method: Put</br>
<br>OperationID: actions/add-selected-repo-to-org-secret</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/secrets/{secret_name}/repositories/{repository_id}</br>
