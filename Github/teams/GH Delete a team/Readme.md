<br>#     Github</br>
<br>Delete a team</br>
<br>To delete a team, the authenticated user must be an organization owner or team maintainer.

If you are an organization owner, deleting a parent team will delete all of its child teams as well.

**Note:** You can also specify a team by `org_id` and `team_id` using the route `DELETE /organizations/{org_id}/team/{team_id}`.</br>
<br>Method: Delete</br>
<br>OperationID: teams/delete-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}</br>
