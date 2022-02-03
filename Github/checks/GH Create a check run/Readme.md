<br>#     Github</br>
<br>Create a check run</br>
<br>**Note:** The Checks API only looks for pushes in the repository where the check suite or check run were created. Pushes to a branch in a forked repository are not detected and return an empty `pull_requests` array.

Creates a new check run for a specific commit in a repository. Your GitHub App must have the `checks:write` permission to create check runs.

In a check suite, GitHub limits the number of check runs with the same name to 1000. Once these check runs exceed 1000, GitHub will start to automatically delete older check runs.</br>
<br>Method: Post</br>
<br>OperationID: checks/create</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/check-runs</br>
<br>Usage: annotations[]</br>
<br>[{
  "path": "%path%",
  "start_line": "%start_line%",
  "end_line": "%end_line%",
  "start_column": "%start_column%",
  "end_column": "%end_column%",
  "annotation_level": "%annotation_level%",
  "message": "%message%",
  "title": "%annotations_title%",
  "raw_details": "%raw_details%"
}]</br>
<br>Usage: images[]</br>
<br>[{
  "alt": "%alt%",
  "image_url": "%image_url%",
  "caption": "%caption%"
}]</br>
<br>Usage: actions[]</br>
<br>[{
  "label": "%label%",
  "description": "%description%",
  "identifier": "%identifier%"
}]</br>
