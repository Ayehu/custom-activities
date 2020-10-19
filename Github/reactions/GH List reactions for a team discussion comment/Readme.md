<br>#     Github</br>
<br>List reactions for a team discussion comment</br>
<br>List the reactions to a [team discussion comment](https://developer.github.com/v3/teams/discussion_comments/). OAuth access tokens require the `read:discussion` [scope](https://developer.github.com/apps/building-oauth-apps/understanding-scopes-for-oauth-apps/).

**Note:** You can also specify a team by `org_id` and `team_id` using the route `GET /organizations/:org_id/team/:team_id/discussions/:discussion_number/comments/:comment_number/reactions`.</br>
<br>Method: Get</br>
<br>OperationID: reactions/list-for-team-discussion-comment-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}/discussions/{discussion_number}/comments/{comment_number}/reactions</br>
