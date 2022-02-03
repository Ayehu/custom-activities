<br>#     Github</br>
<br>Create a tree</br>
<br>The tree creation API accepts nested entries. If you specify both a tree and a nested path modifying that tree, this endpoint will overwrite the contents of the tree with the new path contents, and create a new tree structure.

If you use this endpoint to add, delete, or modify the file contents in a tree, you will need to commit the tree and then update a branch to point to the commit. For more information see "[Create a commit](https://developer.github.com/v3/git/commits/#create-a-commit)" and "[Update a reference](https://developer.github.com/v3/git/refs/#update-a-reference)."</br>
<br>Method: Post</br>
<br>OperationID: git/create-tree</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/git/trees</br>
<br>Usage: tree[]</br>
<br>[{
  "path": "%path%",
  "mode": "%mode%",
  "type": "%type%",
  "sha": "%sha%",
  "content": "%content%"
}]</br>
