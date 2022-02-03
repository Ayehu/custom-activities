<br>#     Github</br>
<br>Check team permissions for a repository (Legacy)</br>
<br>**Note**: Repositories inherited through a parent team will also be checked.

**Deprecation Notice:** This endpoint route is deprecated and will be removed from the Teams API. We recommend migrating your existing code to use the new [Check team permissions for a repository](https://developer.github.com/v3/teams/#check-team-permissions-for-a-repository) endpoint.

You can also get information about the specified repository, including what permissions the team grants on it, by passing the following custom [media type](https://developer.github.com/v3/media/) via the `Accept` header:</br>
<br>Method: Get</br>
<br>OperationID: teams/check-permissions-for-repo-legacy</br>
<br>EndPoint:</br>
<br>/teams/{team_id}/repos/{owner}/{repo}</br>
