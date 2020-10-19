<br>#     Github</br>
<br>Create a review for a pull request</br>
<br>This endpoint triggers [notifications](https://help.github.com/articles/about-notifications/). Creating content too quickly using this endpoint may result in abuse rate limiting. See "[Abuse rate limits](https://developer.github.com/v3/#abuse-rate-limits)" and "[Dealing with abuse rate limits](https://developer.github.com/v3/guides/best-practices-for-integrators/#dealing-with-abuse-rate-limits)" for details.

Pull request reviews created in the `PENDING` state do not include the `submitted_at` property in the response.

**Note:** To comment on a specific line in a file, you need to first determine the _position_ of that line in the diff. The GitHub REST API v3 offers the `application/vnd.github.v3.diff` [media type](https://developer.github.com/v3/media/#commits-commit-comparison-and-pull-requests). To see a pull request diff, add this media type to the `Accept` header of a call to the [single pull request](https://developer.github.com/v3/pulls/#get-a-pull-request) endpoint.

The `position` value equals the number of lines down from the first "@@" hunk header in the file you want to add a comment. The line just below the "@@" line is position 1, the next line is position 2, and so on. The position in the diff continues to increase through lines of whitespace and additional hunks until the beginning of a new file.</br>
<br>Method: Post</br>
<br>OperationID: pulls/create-review</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/pulls/{pull_number}/reviews</br>
<br>Usage: comments[]</br>
<br>[{
  "path": "%path%",
  "position": "%position%",
  "body": "%comments_body%",
  "line": "%line%",
  "side": "%side%",
  "start_line": "%start_line%",
  "start_side": "%start_side%"
}]</br>
