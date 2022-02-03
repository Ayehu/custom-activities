<br>#     Github</br>
<br>Check team permissions for a repository</br>
<br>Checks whether a team has `admin`, `push`, `maintain`, `triage`, or `pull` permission for a repository. Repositories inherited through a parent team will also be checked.

You can also get information about the specified repository, including what permissions the team grants on it, by passing the following custom [media type](https://developer.github.com/v3/media/) via the `application/vnd.github.v3.repository+json` accept header.

If a team doesn't have permission for the repository, you will receive a `404 Not Found` response status.

**Note:** You can also specify a team by `org_id` and `team_id` using the route `GET /organizations/{org_id}/team/{team_id}/repos/{owner}/{repo}`.</br>
<br>Method: Get</br>
<br>OperationID: teams/check-permissions-for-repo-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}/repos/{owner}/{repo}</br>
