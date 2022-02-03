<br>#     Github</br>
<br>Remove a project from a team (Legacy)</br>
<br>**Deprecation Notice:** This endpoint route is deprecated and will be removed from the Teams API. We recommend migrating your existing code to use the new [Remove a project from a team](https://developer.github.com/v3/teams/#remove-a-project-from-a-team) endpoint.

Removes an organization project from a team. An organization owner or a team maintainer can remove any project from the team. To remove a project from a team as an organization member, the authenticated user must have `read` access to both the team and project, or `admin` access to the team or project. **Note:** This endpoint removes the project from the team, but does not delete it.</br>
<br>Method: Delete</br>
<br>OperationID: teams/remove-project-legacy</br>
<br>EndPoint:</br>
<br>/teams/{team_id}/projects/{project_id}</br>
