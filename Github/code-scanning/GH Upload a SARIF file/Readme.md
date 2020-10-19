<br>#     Github</br>
<br>Upload a SARIF file</br>
<br>Upload a SARIF file containing the results of a code scanning analysis to make the results available in a repository.
For private repos, you must use an access token with the `repo` scope. For public repos, you must use an access token with `public_repo` and `repo:security_events` scopes. GitHub Apps must have the `security_events` write permission to use this endpoint.</br>
<br>Method: Post</br>
<br>OperationID: code-scanning/upload-sarif</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/code-scanning/sarifs</br>
