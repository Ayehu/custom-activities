<br>#     Github</br>
<br>Get a workflow</br>
<br>Gets a specific workflow. You can replace `workflow_id` with the workflow file name. For example, you could use `main.yaml`. Anyone with read access to the repository can use this endpoint. If the repository is private you must use an access token with the `repo` scope. GitHub Apps must have the `actions:read` permission to use this endpoint.</br>
<br>Method: Get</br>
<br>OperationID: actions/get-workflow</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/workflows/{workflow_id}</br>
