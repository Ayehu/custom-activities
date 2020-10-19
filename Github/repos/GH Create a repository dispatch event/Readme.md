<br>#     Github</br>
<br>Create a repository dispatch event</br>
<br>You can use this endpoint to trigger a webhook event called `repository_dispatch` when you want activity that happens outside of GitHub to trigger a GitHub Actions workflow or GitHub App webhook. You must configure your GitHub Actions workflow or GitHub App to run when the `repository_dispatch` event occurs. For an example `repository_dispatch` webhook payload, see "[RepositoryDispatchEvent](https://developer.github.com/webhooks/event-payloads/#repository_dispatch)."

The `client_payload` parameter is available for any extra information that your workflow might need. This parameter is a JSON payload that will be passed on when the webhook event is dispatched. For example, the `client_payload` can include a message that a user would like to send using a GitHub Actions workflow. Or the `client_payload` can be used as a test to debug your workflow. For a test example, see the [input example](https://developer.github.com/v3/repos/#example-4).

To give you write access to the repository, you must use a personal access token with the `repo` scope. For more information, see "[Creating a personal access token for the command line](https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line)" in the GitHub Help documentation.

This input example shows how you can use the `client_payload` as a test to debug your workflow.</br>
<br>Method: Post</br>
<br>OperationID: repos/create-dispatch-event</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/dispatches</br>
