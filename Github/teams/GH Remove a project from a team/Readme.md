<br>#     Github</br>
<br>Remove a project from a team</br>
<br>Removes an organization project from a team. An organization owner or a team maintainer can remove any project from the team. To remove a project from a team as an organization member, the authenticated user must have `read` access to both the team and project, or `admin` access to the team or project. This endpoint removes the project from the team, but does not delete the project.

**Note:** You can also specify a team by `org_id` and `team_id` using the route `DELETE /organizations/{org_id}/team/{team_id}/projects/{project_id}`.</br>
<br>Method: Delete</br>
<br>OperationID: teams/remove-project-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}/projects/{project_id}</br>
