<br>#     Github</br>
<br>Remove repository access to a self-hosted runner group in an organization</br>
<br>The self-hosted runner groups REST API is available with GitHub Enterprise Cloud. For more information, see "[GitHub's products](https://docs.github.com/github/getting-started-with-github/githubs-products)."


Removes a repository from the list of selected repositories that can access a self-hosted runner group. The runner group must have `visibility` set to `selected`. For more information, see "[Create a self-hosted runner group for an organization](#create-a-self-hosted-runner-group-for-an-organization)."

You must authenticate using an access token with the `admin:org` scope to use this endpoint.</br>
<br>Method: Delete</br>
<br>OperationID: actions/remove-repo-access-to-self-hosted-runner-group-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/runner-groups/{runner_group_id}/repositories/{repository_id}</br>
