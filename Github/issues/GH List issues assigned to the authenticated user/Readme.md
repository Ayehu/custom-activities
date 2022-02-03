<br>#     Github</br>
<br>List issues assigned to the authenticated user</br>
<br>List issues assigned to the authenticated user across all visible repositories including owned repositories, member
repositories, and organization repositories. You can use the `filter` query parameter to fetch issues that are not
necessarily assigned to you. See the [Parameters table](https://developer.github.com/v3/issues/#parameters) for more
information.


**Note**: GitHub's REST API v3 considers every pull request an issue, but not every issue is a pull request. For this
reason, "Issues" endpoints may return both issues and pull requests in the response. You can identify pull requests by
the `pull_request` key. Be aware that the `id` of a pull request returned from "Issues" endpoints will be an _issue id_. To find out the pull
request id, use the "[List pull requests](https://developer.github.com/v3/pulls/#list-pull-requests)" endpoint.</br>
<br>Method: Get</br>
<br>OperationID: issues/list</br>
<br>EndPoint:</br>
<br>/issues</br>
