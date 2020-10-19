<br>#     Github</br>
<br>Test the push repository webhook</br>
<br>This will trigger the hook with the latest push to the current repository if the hook is subscribed to `push` events. If the hook is not subscribed to `push` events, the server will respond with 204 but no test POST will be generated.

**Note**: Previously `/repos/:owner/:repo/hooks/:hook_id/test`</br>
<br>Method: Post</br>
<br>OperationID: repos/test-push-webhook</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/hooks/{hook_id}/tests</br>
