<br>#     Github</br>
<br>Create a registration token for an organization</br>
<br>Returns a token that you can pass to the `config` script. The token expires after one hour.

You must authenticate using an access token with the `admin:org` scope to use this endpoint.

#### Example using registration token

Configure your self-hosted runner, replacing `TOKEN` with the registration token provided by this endpoint.

```
./config.sh --url https://github.com/octo-org --token TOKEN
```</br>
<br>Method: Post</br>
<br>OperationID: actions/create-registration-token-for-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/runners/registration-token</br>
