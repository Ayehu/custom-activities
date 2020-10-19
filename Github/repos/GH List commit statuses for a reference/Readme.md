<br>#     Github</br>
<br>List commit statuses for a reference</br>
<br>Users with pull access in a repository can view commit statuses for a given ref. The ref can be a SHA, a branch name, or a tag name. Statuses are returned in reverse chronological order. The first status in the list will be the latest one.

This resource is also available via a legacy route: `GET /repos/:owner/:repo/statuses/:ref`.</br>
<br>Method: Get</br>
<br>OperationID: repos/list-commit-statuses-for-ref</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/commits/{ref}/statuses</br>
