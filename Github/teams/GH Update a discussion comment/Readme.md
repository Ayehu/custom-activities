<br>#     Github</br>
<br>Update a discussion comment</br>
<br>Edits the body text of a discussion comment. OAuth access tokens require the `write:discussion` [scope](https://developer.github.com/apps/building-oauth-apps/understanding-scopes-for-oauth-apps/).

**Note:** You can also specify a team by `org_id` and `team_id` using the route `PATCH /organizations/{org_id}/team/{team_id}/discussions/{discussion_number}/comments/{comment_number}`.</br>
<br>Method: Patch</br>
<br>OperationID: teams/update-discussion-comment-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}/discussions/{discussion_number}/comments/{comment_number}</br>
