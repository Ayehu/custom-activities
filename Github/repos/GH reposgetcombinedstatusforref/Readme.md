<br>#     Github</br>
<br>Get the combined status for a specific reference</br>
<br>Users with pull access in a repository can access a combined view of commit statuses for a given ref. The ref can be a SHA, a branch name, or a tag name.

The most recent status for each context is returned, up to 100. This field [paginates](https://developer.github.com/v3/#pagination) if there are over 100 contexts.

Additionally, a combined `state` is returned. The `state` is one of:

*   **failure** if any of the contexts report as `error` or `failure`
*   **pending** if there are no statuses or a context is `pending`
*   **success** if the latest status for all contexts is `success`</br>
<br>Method: Get</br>
<br>OperationID: repos/get-combined-status-for-ref</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/commits/{ref}/status</br>
