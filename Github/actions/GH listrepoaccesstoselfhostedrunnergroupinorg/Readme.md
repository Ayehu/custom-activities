<br>#     Github</br>
<br>List repository access to a self-hosted runner group in an organization</br>
<br>The self-hosted runner groups REST API is available with GitHub Enterprise Cloud and GitHub Enterprise Server. For more information, see "[GitHub's products](https://docs.github.com/github/getting-started-with-github/githubs-products)."

Lists the repositories with access to a self-hosted runner group configured in an organization.

You must authenticate using an access token with the `admin:org` scope to use this endpoint.</br>
<br>Method: Get</br>
<br>OperationID: actions/list-repo-access-to-self-hosted-runner-group-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/runner-groups/{runner_group_id}/repositories</br>
