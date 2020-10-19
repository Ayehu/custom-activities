<br>#     Github</br>
<br>Get allowed actions for a repository</br>
<br>Gets the settings for selected actions that are allowed in a repository. To use this endpoint, the repository policy for `allowed_actions` must be configured to `selected`. For more information, see "[Set GitHub Actions permissions for a repository](#set-github-actions-permissions-for-a-repository)."

You must authenticate using an access token with the `repo` scope to use this endpoint. GitHub Apps must have the `administration` repository permission to use this API.</br>
<br>Method: Get</br>
<br>OperationID: actions/get-allowed-actions-repository</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/permissions/selected-actions</br>
