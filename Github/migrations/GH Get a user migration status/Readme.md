<br>#     Github</br>
<br>Get a user migration status</br>
<br>Fetches a single user migration. The response includes the `state` of the migration, which can be one of the following values:

*   `pending` - the migration hasn't started yet.
*   `exporting` - the migration is in progress.
*   `exported` - the migration finished successfully.
*   `failed` - the migration failed.

Once the migration has been `exported` you can [download the migration archive](https://developer.github.com/v3/migrations/users/#download-a-user-migration-archive).</br>
<br>Method: Get</br>
<br>OperationID: migrations/get-status-for-authenticated-user</br>
<br>EndPoint:</br>
<br>/user/migrations/{migration_id}</br>
