<br>#     Github</br>
<br>Create a reply for a review comment</br>
<br>Creates a reply to a review comment for a pull request. For the `comment_id`, provide the ID of the review comment you are replying to. This must be the ID of a _top-level review comment_, not a reply to that comment. Replies to replies are not supported.

This endpoint triggers [notifications](https://help.github.com/articles/about-notifications/). Creating content too quickly using this endpoint may result in abuse rate limiting. See "[Abuse rate limits](https://developer.github.com/v3/#abuse-rate-limits)" and "[Dealing with abuse rate limits](https://developer.github.com/v3/guides/best-practices-for-integrators/#dealing-with-abuse-rate-limits)" for details.</br>
<br>Method: Post</br>
<br>OperationID: pulls/create-reply-for-review-comment</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/pulls/{pull_number}/comments/{comment_id}/replies</br>
