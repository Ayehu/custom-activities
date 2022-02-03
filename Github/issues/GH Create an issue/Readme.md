<br>#     Github</br>
<br>Create an issue</br>
<br>Any user with pull access to a repository can create an issue. If [issues are disabled in the repository](https://help.github.com/articles/disabling-issues/), the API returns a `410 Gone` status.

This endpoint triggers [notifications](https://help.github.com/articles/about-notifications/). Creating content too quickly using this endpoint may result in abuse rate limiting. See "[Abuse rate limits](https://developer.github.com/v3/#abuse-rate-limits)" and "[Dealing with abuse rate limits](https://developer.github.com/v3/guides/best-practices-for-integrators/#dealing-with-abuse-rate-limits)" for details.</br>
<br>Method: Post</br>
<br>OperationID: issues/create</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/issues</br>
