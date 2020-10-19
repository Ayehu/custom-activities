<br>#     Github</br>
<br>Remove a repository from a team (Legacy)</br>
<br>**Deprecation Notice:** This endpoint route is deprecated and will be removed from the Teams API. We recommend migrating your existing code to use the new [Remove a repository from a team](https://developer.github.com/v3/teams/#remove-a-repository-from-a-team) endpoint.

If the authenticated user is an organization owner or a team maintainer, they can remove any repositories from the team. To remove a repository from a team as an organization member, the authenticated user must have admin access to the repository and must be able to see the team. NOTE: This does not delete the repository, it just removes it from the team.</br>
<br>Method: Delete</br>
<br>OperationID: teams/remove-repo-legacy</br>
<br>EndPoint:</br>
<br>/teams/{team_id}/repos/{owner}/{repo}</br>
