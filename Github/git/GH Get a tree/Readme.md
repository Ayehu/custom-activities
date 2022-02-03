<br>#     Github</br>
<br>Get a tree</br>
<br>Returns a single tree using the SHA1 value for that tree.

If `truncated` is `true` in the response then the number of items in the `tree` array exceeded our maximum limit. If you need to fetch more items, use the non-recursive method of fetching trees, and fetch one sub-tree at a time.</br>
<br>Method: Get</br>
<br>OperationID: git/get-tree</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/git/trees/{tree_sha}</br>
