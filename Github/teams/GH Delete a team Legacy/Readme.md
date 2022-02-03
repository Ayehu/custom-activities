<br>#     Github</br>
<br>Delete a team (Legacy)</br>
<br>**Deprecation Notice:** This endpoint route is deprecated and will be removed from the Teams API. We recommend migrating your existing code to use the new [Delete a team](https://developer.github.com/v3/teams/#delete-a-team) endpoint.

To delete a team, the authenticated user must be an organization owner or team maintainer.

If you are an organization owner, deleting a parent team will delete all of its child teams as well.</br>
<br>Method: Delete</br>
<br>OperationID: teams/delete-legacy</br>
<br>EndPoint:</br>
<br>/teams/{team_id}</br>
