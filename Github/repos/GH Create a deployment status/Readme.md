<br>#     Github</br>
<br>Create a deployment status</br>
<br>Users with `push` access can create deployment statuses for a given deployment.

GitHub Apps require `read  write` access to "Deployments" and `read-only` access to "Repo contents" (for private repos). OAuth Apps require the `repo_deployment` scope.</br>
<br>Method: Post</br>
<br>OperationID: repos/create-deployment-status</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/deployments/{deployment_id}/statuses</br>
