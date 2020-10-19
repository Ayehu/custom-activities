<br>#     Github</br>
<br>Search labels</br>
<br>Find labels in a repository with names or descriptions that match search keywords. Returns up to 100 results [per page](https://developer.github.com/v3/#pagination).

When searching for labels, you can get text match metadata for the label **name** and **description** fields when you pass the `text-match` media type. For more details about how to receive highlighted search results, see [Text match metadata](https://developer.github.com/v3/search/#text-match-metadata).

For example, if you want to find labels in the `linguist` repository that match `bug`, `defect`, or `enhancement`. Your query might look like this:

`q=bug+defect+enhancementrepository_id=64778136`

The labels that best match the query appear first in the search results.</br>
<br>Method: Get</br>
<br>OperationID: search/labels</br>
<br>EndPoint:</br>
<br>/search/labels</br>
