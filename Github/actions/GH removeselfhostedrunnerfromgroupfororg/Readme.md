<br>#     Github</br>
<br>Remove a self-hosted runner from a group for an organization</br>
<br>The self-hosted runner groups REST API is available with GitHub Enterprise Cloud. For more information, see "[GitHub's products](https://docs.github.com/github/getting-started-with-github/githubs-products)."


Removes a self-hosted runner from a group configured in an organization. The runner is then returned to the default group.

You must authenticate using an access token with the `admin:org` scope to use this endpoint.</br>
<br>Method: Delete</br>
<br>OperationID: actions/remove-self-hosted-runner-from-group-for-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/runner-groups/{runner_group_id}/runners/{runner_id}</br>
