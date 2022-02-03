<br>#     Github</br>
<br>Add or update team project permissions</br>
<br>Adds an organization project to a team. To add a project to a team or update the team's permission on a project, the authenticated user must have `admin` permissions for the project. The project and team must be part of the same organization.

**Note:** You can also specify a team by `org_id` and `team_id` using the route `PUT /organizations/{org_id}/team/{team_id}/projects/{project_id}`.</br>
<br>Method: Put</br>
<br>OperationID: teams/add-or-update-project-permissions-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}/projects/{project_id}</br>
