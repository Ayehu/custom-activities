<br>#     Github</br>
<br>Revoke an installation access token</br>
<br>Revokes the installation token you're using to authenticate as an installation and access this endpoint.

Once an installation token is revoked, the token is invalidated and cannot be used. Other endpoints that require the revoked installation token must have a new installation token to work. You can create a new token using the "[Create an installation access token for an app](https://developer.github.com/v3/apps/#create-an-installation-access-token-for-an-app)" endpoint.

You must use an [installation access token](https://developer.github.com/apps/building-github-apps/authenticating-with-github-apps/#authenticating-as-an-installation) to access this endpoint.</br>
<br>Method: Delete</br>
<br>OperationID: apps/revoke-installation-access-token</br>
<br>EndPoint:</br>
<br>/installation/token</br>
