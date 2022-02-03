<br>#     Github</br>
<br>Create a remove token for an organization</br>
<br>Returns a token that you can pass to the `config` script to remove a self-hosted runner from an organization. The token expires after one hour.

You must authenticate using an access token with the `admin:org` scope to use this endpoint.

#### Example using remove token

To remove your self-hosted runner from an organization, replace `TOKEN` with the remove token provided by this
endpoint.

```
./config.sh remove --token TOKEN
```</br>
<br>Method: Post</br>
<br>OperationID: actions/create-remove-token-for-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/actions/runners/remove-token</br>
