<br>#     Github</br>
<br>Download a repository archive (tar)</br>
<br>Gets a redirect URL to download a tar archive for a repository. If you omit `:ref`, the repository’s default branch (usually
`master`) will be used. Please make sure your HTTP framework is configured to follow redirects or you will need to use
the `Location` header to make a second `GET` request.
**Note**: For private repositories, these links are temporary and expire after five minutes.</br>
<br>Method: Get</br>
<br>OperationID: repos/download-tarball-archive</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/tarball/{ref}</br>
