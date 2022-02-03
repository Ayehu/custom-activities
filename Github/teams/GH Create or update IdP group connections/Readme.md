<br>#     Github</br>
<br>Create or update IdP group connections</br>
<br>Team synchronization is available for organizations using GitHub Enterprise Cloud. For more information, see [GitHub's products](https://help.github.com/github/getting-started-with-github/githubs-products) in the GitHub Help documentation.

Creates, updates, or removes a connection between a team and an IdP group. When adding groups to a team, you must include all new and existing groups to avoid replacing existing groups with the new ones. Specifying an empty `groups` array will remove all connections for a team.

**Note:** You can also specify a team by `org_id` and `team_id` using the route `PATCH /organizations/{org_id}/team/{team_id}/team-sync/group-mappings`.</br>
<br>Method: Patch</br>
<br>OperationID: teams/create-or-update-idp-group-connections-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}/team-sync/group-mappings</br>
<br>Usage: groups[]</br>
<br>[{
  "group_id": "%group_id%",
  "group_name": "%group_name%",
  "group_description": "%group_description%"
}]</br>
