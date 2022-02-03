<br>#     Github</br>
<br>Delete team discussion reaction</br>
<br>**Note:** You can also specify a team or organization with `team_id` and `org_id` using the route `DELETE /organizations/:org_id/team/:team_id/discussions/:discussion_number/reactions/:reaction_id`.

Delete a reaction to a [team discussion](https://developer.github.com/v3/teams/discussions/). OAuth access tokens require the `write:discussion` [scope](https://developer.github.com/apps/building-oauth-apps/understanding-scopes-for-oauth-apps/).</br>
<br>Method: Delete</br>
<br>OperationID: reactions/delete-for-team-discussion</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}/discussions/{discussion_number}/reactions/{reaction_id}</br>
