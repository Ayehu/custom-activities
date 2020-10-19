<br>#     Github</br>
<br>Get a reference</br>
<br>Returns a single reference from your Git database. The `:ref` in the URL must be formatted as `heads/` for branches and `tags/` for tags. If the `:ref` doesn't match an existing ref, a `404` is returned.

**Note:** You need to explicitly [request a pull request](https://developer.github.com/v3/pulls/#get-a-pull-request) to trigger a test merge commit, which checks the mergeability of pull requests. For more information, see "[Checking mergeability of pull requests](https://developer.github.com/v3/git/#checking-mergeability-of-pull-requests)".</br>
<br>Method: Get</br>
<br>OperationID: git/get-ref</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/git/ref/{ref}</br>
