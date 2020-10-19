<br>#     Github</br>
<br>List check suites for a Git reference</br>
<br>**Note:** The Checks API only looks for pushes in the repository where the check suite or check run were created. Pushes to a branch in a forked repository are not detected and return an empty `pull_requests` array and a `null` value for `head_branch`.

Lists check suites for a commit `ref`. The `ref` can be a SHA, branch name, or a tag name. GitHub Apps must have the `checks:read` permission on a private repository or pull access to a public repository to list check suites. OAuth Apps and authenticated users must have the `repo` scope to get check suites in a private repository.</br>
<br>Method: Get</br>
<br>OperationID: checks/list-suites-for-ref</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/commits/{ref}/check-suites</br>
