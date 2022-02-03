<br>#     Github</br>
<br>List workflow runs for a repository</br>
<br>Lists all workflow runs for a repository. You can use parameters to narrow the list of results. For more information about using parameters, see [Parameters](https://developer.github.com/v3/#parameters).

Anyone with read access to the repository can use this endpoint. If the repository is private you must use an access token with the `repo` scope. GitHub Apps must have the `actions:read` permission to use this endpoint.</br>
<br>Method: Get</br>
<br>OperationID: actions/list-workflow-runs-for-repo</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/runs</br>
