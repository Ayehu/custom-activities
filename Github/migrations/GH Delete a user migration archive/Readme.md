<br>#     Github</br>
<br>Delete a user migration archive</br>
<br>Deletes a previous migration archive. Downloadable migration archives are automatically deleted after seven days. Migration metadata, which is returned in the [List user migrations](https://developer.github.com/v3/migrations/users/#list-user-migrations) and [Get a user migration status](https://developer.github.com/v3/migrations/users/#get-a-user-migration-status) endpoints, will continue to be available even after an archive is deleted.</br>
<br>Method: Delete</br>
<br>OperationID: migrations/delete-archive-for-authenticated-user</br>
<br>EndPoint:</br>
<br>/user/migrations/{migration_id}/archive</br>
