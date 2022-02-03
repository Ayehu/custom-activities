<br>#     Github</br>
<br>Set GitHub Actions permissions for a repository</br>
<br>Sets the GitHub Actions permissions policy for enabling GitHub Actions and allowed actions in the repository.

If the repository belongs to an organization or enterprise that has set restrictive permissions at the organization or enterprise levels, such as `allowed_actions` to `selected` actions, then you cannot override them for the repository.

You must authenticate using an access token with the `repo` scope to use this endpoint. GitHub Apps must have the `administration` repository permission to use this API.</br>
<br>Method: Put</br>
<br>OperationID: actions/set-github-actions-permissions-repository</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/permissions</br>
