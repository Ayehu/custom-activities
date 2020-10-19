<br>#     Github</br>
<br>Delete a file</br>
<br>Deletes a file in a repository.

You can provide an additional `committer` parameter, which is an object containing information about the committer. Or, you can provide an `author` parameter, which is an object containing information about the author.

The `author` section is optional and is filled in with the `committer` information if omitted. If the `committer` information is omitted, the authenticated user's information is used.

You must provide values for both `name` and `email`, whether you choose to use `author` or `committer`. Otherwise, you'll receive a `422` status code.</br>
<br>Method: Delete</br>
<br>OperationID: repos/delete-file</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/contents/{path}</br>
