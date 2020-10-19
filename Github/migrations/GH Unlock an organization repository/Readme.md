<br>#     Github</br>
<br>Unlock an organization repository</br>
<br>Unlocks a repository that was locked for migration. You should unlock each migrated repository and [delete them](https://developer.github.com/v3/repos/#delete-a-repository) when the migration is complete and you no longer need the source data.</br>
<br>Method: Delete</br>
<br>OperationID: migrations/unlock-repo-for-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/migrations/{migration_id}/repos/{repo_name}/lock</br>
