<br>#     Github</br>
<br>Rerequest a check suite</br>
<br>Triggers GitHub to rerequest an existing check suite, without pushing new code to a repository. This endpoint will trigger the [`check_suite` webhook](https://developer.github.com/webhooks/event-payloads/#check_suite) event with the action `rerequested`. When a check suite is `rerequested`, its `status` is reset to `queued` and the `conclusion` is cleared.

To rerequest a check suite, your GitHub App must have the `checks:read` permission on a private repository or pull access to a public repository.</br>
<br>Method: Post</br>
<br>OperationID: checks/rerequest-suite</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/check-suites/{check_suite_id}/rerequest</br>
