<br>#     Github</br>
<br>Create a commit status</br>
<br>Users with push access in a repository can create commit statuses for a given SHA.

Note: there is a limit of 1000 statuses per `sha` and `context` within a repository. Attempts to create more than 1000 statuses will result in a validation error.</br>
<br>Method: Post</br>
<br>OperationID: repos/create-commit-status</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/statuses/{sha}</br>
