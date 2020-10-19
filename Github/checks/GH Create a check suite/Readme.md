<br>#     Github</br>
<br>Create a check suite</br>
<br>**Note:** The Checks API only looks for pushes in the repository where the check suite or check run were created. Pushes to a branch in a forked repository are not detected and return an empty `pull_requests` array and a `null` value for `head_branch`.

By default, check suites are automatically created when you create a [check run](https://developer.github.com/v3/checks/runs/). You only need to use this endpoint for manually creating check suites when you've disabled automatic creation using "[Update repository preferences for check suites](https://developer.github.com/v3/checks/suites/#update-repository-preferences-for-check-suites)". Your GitHub App must have the `checks:write` permission to create check suites.</br>
<br>Method: Post</br>
<br>OperationID: checks/create-suite</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/check-suites</br>
