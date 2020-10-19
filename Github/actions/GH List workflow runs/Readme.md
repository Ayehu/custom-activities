<br>#     Github</br>
<br>List workflow runs</br>
<br>List all workflow runs for a workflow. You can replace `workflow_id` with the workflow file name. For example, you could use `main.yaml`. You can use parameters to narrow the list of results. For more information about using parameters, see [Parameters](https://developer.github.com/v3/#parameters).

Anyone with read access to the repository can use this endpoint. If the repository is private you must use an access token with the `repo` scope.</br>
<br>Method: Get</br>
<br>OperationID: actions/list-workflow-runs</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/workflows/{workflow_id}/runs</br>
