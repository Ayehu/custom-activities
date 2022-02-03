<br>#     Github</br>
<br>Download an artifact</br>
<br>Gets a redirect URL to download an archive for a repository. This URL expires after 1 minute. Look for `Location:` in
the response header to find the URL for the download. The `:archive_format` must be `zip`. Anyone with read access to
the repository can use this endpoint. If the repository is private you must use an access token with the `repo` scope.
GitHub Apps must have the `actions:read` permission to use this endpoint.</br>
<br>Method: Get</br>
<br>OperationID: actions/download-artifact</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/artifacts/{artifact_id}/{archive_format}</br>
