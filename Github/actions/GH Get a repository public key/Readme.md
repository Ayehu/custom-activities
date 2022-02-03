<br>#     Github</br>
<br>Get a repository public key</br>
<br>Gets your public key, which you need to encrypt secrets. You need to encrypt a secret before you can create or update secrets. Anyone with read access to the repository can use this endpoint. If the repository is private you must use an access token with the `repo` scope. GitHub Apps must have the `secrets` repository permission to use this endpoint.</br>
<br>Method: Get</br>
<br>OperationID: actions/get-repo-public-key</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/secrets/public-key</br>
