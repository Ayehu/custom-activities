<br>#     Github</br>
<br>Create a project card</br>
<br>**Note**: GitHub's REST API v3 considers every pull request an issue, but not every issue is a pull request. For this reason, "Issues" endpoints may return both issues and pull requests in the response. You can identify pull requests by the `pull_request` key.

Be aware that the `id` of a pull request returned from "Issues" endpoints will be an _issue id_. To find out the pull request id, use the "[List pull requests](https://developer.github.com/v3/pulls/#list-pull-requests)" endpoint.</br>
<br>Method: Post</br>
<br>OperationID: projects/create-card</br>
<br>EndPoint:</br>
<br>/projects/columns/{column_id}/cards</br>
