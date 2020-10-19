<br>#     Github</br>
<br>Set allowed actions for a repository</br>
<br>Sets the actions that are allowed in a repository. To use this endpoint, the repository permission policy for `allowed_actions` must be configured to `selected`. For more information, see "[Set GitHub Actions permissions for a repository](#set-github-actions-permissions-for-a-repository)."

If the repository belongs to an organization or enterprise that has `selected` actions set at the organization or enterprise levels, then you cannot override any of the allowed actions settings.

To use the `patterns_allowed` setting for private repositories, the repository must belong to an enterprise. If the repository does not belong to an enterprise, then the `patterns_allowed` setting only applies to public repositories.

You must authenticate using an access token with the `repo` scope to use this endpoint. GitHub Apps must have the `administration` repository permission to use this API.</br>
<br>Method: Put</br>
<br>OperationID: actions/set-allowed-actions-repository</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/permissions/selected-actions</br>
