<br>#     Github</br>
<br>Get an organization migration status</br>
<br>Fetches the status of a migration.

The `state` of a migration can be one of the following values:

*   `pending`, which means the migration hasn't started yet.
*   `exporting`, which means the migration is in progress.
*   `exported`, which means the migration finished successfully.
*   `failed`, which means the migration failed.</br>
<br>Method: Get</br>
<br>OperationID: migrations/get-status-for-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/migrations/{migration_id}</br>
