<br>#     Github</br>
<br>Get an issue</br>
<br>The API returns a [`301 Moved Permanently` status](https://developer.github.com/v3/#http-redirects) if the issue was
[transferred](https://help.github.com/articles/transferring-an-issue-to-another-repository/) to another repository. If
the issue was transferred to or deleted from a repository where the authenticated user lacks read access, the API
returns a `404 Not Found` status. If the issue was deleted from a repository where the authenticated user has read
access, the API returns a `410 Gone` status. To receive webhook events for transferred and deleted issues, subscribe
to the [`issues`](https://developer.github.com/webhooks/event-payloads/#issues) webhook.

**Note**: GitHub's REST API v3 considers every pull request an issue, but not every issue is a pull request. For this
reason, "Issues" endpoints may return both issues and pull requests in the response. You can identify pull requests by
the `pull_request` key. Be aware that the `id` of a pull request returned from "Issues" endpoints will be an _issue id_. To find out the pull
request id, use the "[List pull requests](https://developer.github.com/v3/pulls/#list-pull-requests)" endpoint.</br>
<br>Method: Get</br>
<br>OperationID: issues/get</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/issues/{issue_number}</br>
