<br>#     Github</br>
<br>Create reaction for a team discussion</br>
<br>Create a reaction to a [team discussion](https://developer.github.com/v3/teams/discussions/). OAuth access tokens require the `write:discussion` [scope](https://developer.github.com/apps/building-oauth-apps/understanding-scopes-for-oauth-apps/). A response with a `Status: 200 OK` means that you already added the reaction type to this team discussion.

**Note:** You can also specify a team by `org_id` and `team_id` using the route `POST /organizations/:org_id/team/:team_id/discussions/:discussion_number/reactions`.</br>
<br>Method: Post</br>
<br>OperationID: reactions/create-for-team-discussion-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}/discussions/{discussion_number}/reactions</br>
