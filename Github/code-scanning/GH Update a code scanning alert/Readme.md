<br>#     Github</br>
<br>Update a code scanning alert</br>
<br>Updates the status of a single code scanning alert. For private repos, you must use an access token with the `repo` scope. For public repos, you must use an access token with `public_repo` and `repo:security_events` scopes.
GitHub Apps must have the `security_events` write permission to use this endpoint.</br>
<br>Method: Patch</br>
<br>OperationID: code-scanning/update-alert</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/code-scanning/alerts/{alert_number}</br>
