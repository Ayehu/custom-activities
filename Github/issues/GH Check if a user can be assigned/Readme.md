<br>#     Github</br>
<br>Check if a user can be assigned</br>
<br>Checks if a user has permission to be assigned to an issue in this repository.

If the `assignee` can be assigned to issues in the repository, a `204` header with no content is returned.

Otherwise a `404` status code is returned.</br>
<br>Method: Get</br>
<br>OperationID: issues/check-user-can-be-assigned</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/assignees/{assignee}</br>
