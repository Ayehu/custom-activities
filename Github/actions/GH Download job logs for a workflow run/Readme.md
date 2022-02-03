<br>#     Github</br>
<br>Download job logs for a workflow run</br>
<br>Gets a redirect URL to download a plain text file of logs for a workflow job. This link expires after 1 minute. Look
for `Location:` in the response header to find the URL for the download. Anyone with read access to the repository can
use this endpoint. If the repository is private you must use an access token with the `repo` scope. GitHub Apps must
have the `actions:read` permission to use this endpoint.</br>
<br>Method: Get</br>
<br>OperationID: actions/download-job-logs-for-workflow-run</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/actions/jobs/{job_id}/logs</br>
