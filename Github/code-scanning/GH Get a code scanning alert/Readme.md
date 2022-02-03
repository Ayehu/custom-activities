<br>#     Github</br>
<br>Get a code scanning alert</br>
<br>Gets a single code scanning alert. You must use an access token with the `security_events` scope to use this endpoint. GitHub Apps must have the `security_events` read permission to use this endpoint.

The security `alert_number` is found at the end of the security alert's URL. For example, the security alert ID for `https://github.com/Octo-org/octo-repo/security/code-scanning/88` is `88`.</br>
<br>Method: Get</br>
<br>OperationID: code-scanning/get-alert</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/code-scanning/alerts/{alert_number}</br>
