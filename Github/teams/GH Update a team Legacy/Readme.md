<br>#     Github</br>
<br>Update a team (Legacy)</br>
<br>**Deprecation Notice:** This endpoint route is deprecated and will be removed from the Teams API. We recommend migrating your existing code to use the new [Update a team](https://developer.github.com/v3/teams/#update-a-team) endpoint.

To edit a team, the authenticated user must either be an organization owner or a team maintainer.

**Note:** With nested teams, the `privacy` for parent teams cannot be `secret`.</br>
<br>Method: Patch</br>
<br>OperationID: teams/update-legacy</br>
<br>EndPoint:</br>
<br>/teams/{team_id}</br>
