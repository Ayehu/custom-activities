<br>#     Github</br>
<br>Unsuspend an app installation</br>
<br>**Note:** Suspending a GitHub App installation is currently in beta and subject to change. Before you can suspend a GitHub App, the app owner must enable suspending installations for the app by opting-in to the beta. For more information, see "[Suspending a GitHub App installation](https://developer.github.com/apps/managing-github-apps/suspending-a-github-app-installation/)."

Removes a GitHub App installation suspension.

To unsuspend a GitHub App, you must be an account owner or have admin permissions in the repository or organization where the app is installed and suspended.

You must use a [JWT](https://developer.github.com/apps/building-github-apps/authenticating-with-github-apps/#authenticating-as-a-github-app) to access this endpoint.</br>
<br>Method: Delete</br>
<br>OperationID: apps/unsuspend-installation</br>
<br>EndPoint:</br>
<br>/app/installations/{installation_id}/suspended</br>
