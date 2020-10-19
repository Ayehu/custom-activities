<br>#     Github</br>
<br>Get a check run</br>
<br>**Note:** The Checks API only looks for pushes in the repository where the check suite or check run were created. Pushes to a branch in a forked repository are not detected and return an empty `pull_requests` array.

Gets a single check run using its `id`. GitHub Apps must have the `checks:read` permission on a private repository or pull access to a public repository to get check runs. OAuth Apps and authenticated users must have the `repo` scope to get check runs in a private repository.</br>
<br>Method: Get</br>
<br>OperationID: checks/get</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/check-runs/{check_run_id}</br>
