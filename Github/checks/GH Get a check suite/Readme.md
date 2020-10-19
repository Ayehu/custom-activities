<br>#     Github</br>
<br>Get a check suite</br>
<br>**Note:** The Checks API only looks for pushes in the repository where the check suite or check run were created. Pushes to a branch in a forked repository are not detected and return an empty `pull_requests` array and a `null` value for `head_branch`.

Gets a single check suite using its `id`. GitHub Apps must have the `checks:read` permission on a private repository or pull access to a public repository to get check suites. OAuth Apps and authenticated users must have the `repo` scope to get check suites in a private repository.</br>
<br>Method: Get</br>
<br>OperationID: checks/get-suite</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/check-suites/{check_suite_id}</br>
