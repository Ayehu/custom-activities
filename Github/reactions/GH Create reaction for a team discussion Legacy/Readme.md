<br>#     Github</br>
<br>Create reaction for a team discussion (Legacy)</br>
<br>**Deprecation Notice:** This endpoint route is deprecated and will be removed from the Teams API. We recommend migrating your existing code to use the new [`Create reaction for a team discussion`](https://developer.github.com/v3/reactions/#create-reaction-for-a-team-discussion) endpoint.

Create a reaction to a [team discussion](https://developer.github.com/v3/teams/discussions/). OAuth access tokens require the `write:discussion` [scope](https://developer.github.com/apps/building-oauth-apps/understanding-scopes-for-oauth-apps/). A response with a `Status: 200 OK` means that you already added the reaction type to this team discussion.</br>
<br>Method: Post</br>
<br>OperationID: reactions/create-for-team-discussion-legacy</br>
<br>EndPoint:</br>
<br>/teams/{team_id}/discussions/{discussion_number}/reactions</br>
