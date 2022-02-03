<br>#     Github</br>
<br>Create a remove token for a repository</br>
<br>Returns a token that you can pass to remove a self-hosted runner from a repository. The token expires after one hour.
You must authenticate using an access token with the `repo` scope to use this endpoint.

#### Example using remove token
 
To remove your self-hosted runner from a repository, replace TOKEN with the remove token provided by this endpoint.

```
./config.sh remove --token TOKEN
```</br>
<br>Method: Post</br>
<br>OperationID: actions/create-remove-token-for-repo</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/runners/remove-token</br>
