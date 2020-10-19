<br>#     Github</br>
<br>List jobs for a workflow run</br>
<br>Lists jobs for a workflow run. Anyone with read access to the repository can use this endpoint. If the repository is private you must use an access token with the `repo` scope. GitHub Apps must have the `actions:read` permission to use this endpoint. You can use parameters to narrow the list of results. For more information about using parameters, see [Parameters](https://developer.github.com/v3/#parameters).</br>
<br>Method: Get</br>
<br>OperationID: actions/list-jobs-for-workflow-run</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/runs/{run_id}/jobs</br>
