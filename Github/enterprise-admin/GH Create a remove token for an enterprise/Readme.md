<br>#     Github</br>
<br>Create a remove token for an enterprise</br>
<br>Returns a token that you can pass to the `config` script to remove a self-hosted runner from an enterprise. The token expires after one hour.

You must authenticate using an access token with the `admin:enterprise` scope to use this endpoint.

#### Example using remove token

To remove your self-hosted runner from an enterprise, replace `TOKEN` with the remove token provided by this
endpoint.

```
./config.sh remove --token TOKEN
```</br>
<br>Method: Post</br>
<br>OperationID: enterprise-admin/create-remove-token-for-enterprise</br>
<br>EndPoint:</br>
<br>/enterprises/{enterprise}/actions/runners/remove-token</br>
