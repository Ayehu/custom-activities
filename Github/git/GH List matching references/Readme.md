<br>#     Github</br>
<br>List matching references</br>
<br>Returns an array of references from your Git database that match the supplied name. The `:ref` in the URL must be formatted as `heads/` for branches and `tags/` for tags. If the `:ref` doesn't exist in the repository, but existing refs start with `:ref`, they will be returned as an array.

When you use this endpoint without providing a `:ref`, it will return an array of all the references from your Git database, including notes and stashes if they exist on the server. Anything in the namespace is returned, not just `heads` and `tags`.

**Note:** You need to explicitly [request a pull request](https://developer.github.com/v3/pulls/#get-a-pull-request) to trigger a test merge commit, which checks the mergeability of pull requests. For more information, see "[Checking mergeability of pull requests](https://developer.github.com/v3/git/#checking-mergeability-of-pull-requests)".

If you request matching references for a branch named `feature` but the branch `feature` doesn't exist, the response can still include other matching head refs that start with the word `feature`, such as `featureA` and `featureB`.</br>
<br>Method: Get</br>
<br>OperationID: git/list-matching-refs</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/git/matching-refs/{ref}</br>
