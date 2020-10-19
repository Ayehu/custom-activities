<br>#     Github</br>
<br>Add a repository to an app installation</br>
<br>Add a single repository to an installation. The authenticated user must have admin access to the repository.

You must use a personal access token (which you can create via the [command line](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/) or the [OAuth Authorizations API](https://developer.github.com/v3/oauth_authorizations/#create-a-new-authorization)) or [Basic Authentication](https://developer.github.com/v3/auth/#basic-authentication) to access this endpoint.</br>
<br>Method: Put</br>
<br>OperationID: apps/add-repo-to-installation</br>
<br>EndPoint:</br>
<br>/user/installations/{installation_id}/repositories/{repository_id}</br>
