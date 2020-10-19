<br>#     Github</br>
<br>Create or update IdP group connections (Legacy)</br>
<br>**Deprecation Notice:** This endpoint route is deprecated and will be removed from the Teams API. We recommend migrating your existing code to use the new [`Create or update IdP group connections`](https://developer.github.com/v3/teams/team_sync/#create-or-update-idp-group-connections) endpoint.

Team synchronization is available for organizations using GitHub Enterprise Cloud. For more information, see [GitHub's products](https://help.github.com/github/getting-started-with-github/githubs-products) in the GitHub Help documentation.

Creates, updates, or removes a connection between a team and an IdP group. When adding groups to a team, you must include all new and existing groups to avoid replacing existing groups with the new ones. Specifying an empty `groups` array will remove all connections for a team.</br>
<br>Method: Patch</br>
<br>OperationID: teams/create-or-update-idp-group-connections-legacy</br>
<br>EndPoint:</br>
<br>/teams/{team_id}/team-sync/group-mappings</br>
<br>Usage: groups[]</br>
<br>[{
  "group_id": "%group_id%",
  "group_name": "%group_name%",
  "group_description": "%group_description%",
  "id": "%id%",
  "name": "%name%",
  "description": "%description%"
}]</br>
