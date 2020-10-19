<br>#     Github</br>
<br>Get team membership for a user (Legacy)</br>
<br>**Deprecation Notice:** This endpoint route is deprecated and will be removed from the Teams API. We recommend migrating your existing code to use the new [Get team membership for a user](https://developer.github.com/v3/teams/members/#get-team-membership-for-a-user) endpoint.

Team members will include the members of child teams.

To get a user's membership with a team, the team must be visible to the authenticated user.

**Note:** The `role` for organization owners returns as `maintainer`. For more information about `maintainer` roles, see [Create a team](https://developer.github.com/v3/teams/#create-a-team).</br>
<br>Method: Get</br>
<br>OperationID: teams/get-membership-for-user-legacy</br>
<br>EndPoint:</br>
<br>/teams/{team_id}/memberships/{username}</br>
