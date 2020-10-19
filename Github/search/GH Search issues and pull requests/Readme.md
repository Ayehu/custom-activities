<br>#     Github</br>
<br>Search issues and pull requests</br>
<br>Find issues by state and keyword. This method returns up to 100 results [per page](https://developer.github.com/v3/#pagination).

When searching for issues, you can get text match metadata for the issue **title**, issue **body**, and issue **comment body** fields when you pass the `text-match` media type. For more details about how to receive highlighted
search results, see [Text match metadata](https://developer.github.com/v3/search/#text-match-metadata).

For example, if you want to find the oldest unresolved Python bugs on Windows. Your query might look something like this.

`q=windows+label:bug+language:python+state:opensort=createdorder=asc`

This query searches for the keyword `windows`, within any open issue that is labeled as `bug`. The search runs across repositories whose primary language is Python. The results are sorted by creation date in ascending order, whick means the oldest issues appear first in the search results.</br>
<br>Method: Get</br>
<br>OperationID: search/issues-and-pull-requests</br>
<br>EndPoint:</br>
<br>/search/issues</br>
