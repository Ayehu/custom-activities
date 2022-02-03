<br>#     Github</br>
<br>Create a commit comment</br>
<br>Create a comment for a commit using its `:commit_sha`.

This endpoint triggers [notifications](https://help.github.com/articles/about-notifications/). Creating content too quickly using this endpoint may result in abuse rate limiting. See "[Abuse rate limits](https://developer.github.com/v3/#abuse-rate-limits)" and "[Dealing with abuse rate limits](https://developer.github.com/v3/guides/best-practices-for-integrators/#dealing-with-abuse-rate-limits)" for details.</br>
<br>Method: Post</br>
<br>OperationID: repos/create-commit-comment</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/commits/{commit_sha}/comments</br>
