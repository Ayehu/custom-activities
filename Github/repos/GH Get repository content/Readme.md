<br>#     Github</br>
<br>Get repository content</br>
<br>Gets the contents of a file or directory in a repository. Specify the file path or directory in `:path`. If you omit
`:path`, you will receive the contents of all files in the repository.

Files and symlinks support [a custom media type](https://developer.github.com/v3/repos/contents/#custom-media-types) for
retrieving the raw content or rendered HTML (when supported). All content types support [a custom media
type](https://developer.github.com/v3/repos/contents/#custom-media-types) to ensure the content is returned in a consistent
object format.

**Note**:
*   To get a repository's contents recursively, you can [recursively get the tree](https://developer.github.com/v3/git/trees/).
*   This API has an upper limit of 1,000 files for a directory. If you need to retrieve more files, use the [Git Trees
API](https://developer.github.com/v3/git/trees/#get-a-tree).
*   This API supports files up to 1 megabyte in size.

#### If the content is a directory
The response will be an array of objects, one object for each item in the directory.
When listing the contents of a directory, submodules have their "type" specified as "file". Logically, the value
_should_ be "submodule". This behavior exists in API v3 [for backwards compatibility purposes](https://git.io/v1YCW).
In the next major version of the API, the type will be returned as "submodule".

#### If the content is a symlink 
If the requested `:path` points to a symlink, and the symlink's target is a normal file in the repository, then the
API responds with the content of the file (in the format shown in the example. Otherwise, the API responds with an object 
describing the symlink itself.

#### If the content is a submodule
The `submodule_git_url` identifies the location of the submodule repository, and the `sha` identifies</br>
<br>Method: Get</br>
<br>OperationID: repos/get-content</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/contents/{path}</br>
