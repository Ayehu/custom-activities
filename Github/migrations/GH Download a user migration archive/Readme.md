<br>#     Github</br>
<br>Download a user migration archive</br>
<br>Fetches the URL to download the migration archive as a `tar.gz` file. Depending on the resources your repository uses, the migration archive can contain JSON files with data for these objects:

*   attachments
*   bases
*   commit\_comments
*   issue\_comments
*   issue\_events
*   issues
*   milestones
*   organizations
*   projects
*   protected\_branches
*   pull\_request\_reviews
*   pull\_requests
*   releases
*   repositories
*   review\_comments
*   schema
*   users

The archive will also contain an `attachments` directory that includes all attachment files uploaded to GitHub.com and a `repositories` directory that contains the repository's Git data.</br>
<br>Method: Get</br>
<br>OperationID: migrations/get-archive-for-authenticated-user</br>
<br>EndPoint:</br>
<br>/user/migrations/{migration_id}/archive</br>
