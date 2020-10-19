<br>#     Github</br>
<br>Delete a deployment</br>
<br>To ensure there can always be an active deployment, you can only delete an _inactive_ deployment. Anyone with `repo` or `repo_deployment` scopes can delete an inactive deployment.

To set a deployment as inactive, you must:

*   Create a new deployment that is active so that the system has a record of the current state, then delete the previously active deployment.
*   Mark the active deployment as inactive by adding any non-successful deployment status.

For more information, see "[Create a deployment](https://developer.github.com/v3/repos/deployments/#create-a-deployment)" and "[Create a deployment status](https://developer.github.com/v3/repos/deployments/#create-a-deployment-status)."</br>
<br>Method: Delete</br>
<br>OperationID: repos/delete-deployment</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/deployments/{deployment_id}</br>
