<br>#     Github</br>
<br>Unlock a user repository</br>
<br>Unlocks a repository. You can lock repositories when you [start a user migration](https://developer.github.com/v3/migrations/users/#start-a-user-migration). Once the migration is complete you can unlock each repository to begin using it again or [delete the repository](https://developer.github.com/v3/repos/#delete-a-repository) if you no longer need the source data. Returns a status of `404 Not Found` if the repository is not locked.</br>
<br>Method: Delete</br>
<br>OperationID: migrations/unlock-repo-for-authenticated-user</br>
<br>EndPoint:</br>
<br>/user/migrations/{migration_id}/repos/{repo_name}/lock</br>
