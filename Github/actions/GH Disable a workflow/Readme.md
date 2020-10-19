<br>#     Github</br>
<br>Disable a workflow</br>
<br>Disables a workflow and sets the `state` of the workflow to `disabled_manually`. You can replace `workflow_id` with the workflow file name. For example, you could use `main.yaml`.

You must authenticate using an access token with the `repo` scope to use this endpoint. GitHub Apps must have the `actions:write` permission to use this endpoint.</br>
<br>Method: Put</br>
<br>OperationID: actions/disable-workflow</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/workflows/{workflow_id}/disable</br>
