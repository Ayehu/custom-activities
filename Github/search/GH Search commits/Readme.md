<br>#     Github</br>
<br>Search commits</br>
<br>Find commits via various criteria on the default branch (usually `master`). This method returns up to 100 results [per page](https://developer.github.com/v3/#pagination).

When searching for commits, you can get text match metadata for the **message** field when you provide the `text-match` media type. For more details about how to receive highlighted search results, see [Text match
metadata](https://developer.github.com/v3/search/#text-match-metadata).

For example, if you want to find commits related to CSS in the [octocat/Spoon-Knife](https://github.com/octocat/Spoon-Knife) repository. Your query would look something like this:

`q=repo:octocat/Spoon-Knife+css`</br>
<br>Method: Get</br>
<br>OperationID: search/commits</br>
<br>EndPoint:</br>
<br>/search/commits</br>
