<br>#     Github</br>
<br>Create a registration token for a repository</br>
<br>Returns a token that you can pass to the `config` script. The token expires after one hour. You must authenticate
using an access token with the `repo` scope to use this endpoint.

#### Example using registration token
 
Configure your self-hosted runner, replacing `TOKEN` with the registration token provided by this endpoint.

```
./config.sh --url https://github.com/octo-org/octo-repo-artifacts --token TOKEN
```</br>
<br>Method: Post</br>
<br>OperationID: actions/create-registration-token-for-repo</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/runners/registration-token</br>
