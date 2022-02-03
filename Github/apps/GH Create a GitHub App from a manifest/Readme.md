<br>#     Github</br>
<br>Create a GitHub App from a manifest</br>
<br>Use this endpoint to complete the handshake necessary when implementing the [GitHub App Manifest flow](https://developer.github.com/apps/building-github-apps/creating-github-apps-from-a-manifest/). When you create a GitHub App with the manifest flow, you receive a temporary `code` used to retrieve the GitHub App's `id`, `pem` (private key), and `webhook_secret`.</br>
<br>Method: Post</br>
<br>OperationID: apps/create-from-manifest</br>
<br>EndPoint:</br>
<br>/app-manifests/{code}/conversions</br>
