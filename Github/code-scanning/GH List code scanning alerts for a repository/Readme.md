<br>#     Github</br>
<br>List code scanning alerts for a repository</br>
<br>Lists all open code scanning alerts for the default branch (usually `master`) and protected branches in a repository. For private repos, you must use an access token with the `repo` scope. For public repos, you must use an access token with `public_repo` and `repo:security_events` scopes. GitHub Apps must have the `security_events` read permission to use this endpoint.</br>
<br>Method: Get</br>
<br>OperationID: code-scanning/list-alerts-for-repo</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/code-scanning/alerts</br>
