<br>#     Github</br>
<br>Enable a workflow</br>
<br>Enables a workflow and sets the `state` of the workflow to `active`. You can replace `workflow_id` with the workflow file name. For example, you could use `main.yaml`.

You must authenticate using an access token with the `repo` scope to use this endpoint. GitHub Apps must have the `actions:write` permission to use this endpoint.</br>
<br>Method: Put</br>
<br>OperationID: actions/enable-workflow</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/workflows/{workflow_id}/enable</br>
