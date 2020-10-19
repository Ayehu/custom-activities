<br>#     Github</br>
<br>Create a registration token for an enterprise</br>
<br>Returns a token that you can pass to the `config` script. The token expires after one hour.

You must authenticate using an access token with the `admin:enterprise` scope to use this endpoint.

#### Example using registration token

Configure your self-hosted runner, replacing `TOKEN` with the registration token provided by this endpoint.

```
./config.sh --url https://github.com/enterpises/octo-enterprise --token TOKEN
```</br>
<br>Method: Post</br>
<br>OperationID: enterprise-admin/create-registration-token-for-enterprise</br>
<br>EndPoint:</br>
<br>/enterprises/{enterprise}/actions/runners/registration-token</br>
