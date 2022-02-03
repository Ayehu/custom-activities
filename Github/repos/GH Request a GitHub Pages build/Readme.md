<br>#     Github</br>
<br>Request a GitHub Pages build</br>
<br>You can request that your site be built from the latest revision on the default branch. This has the same effect as pushing a commit to your default branch, but does not require an additional commit. Manually triggering page builds can be helpful when diagnosing build warnings and failures.

Build requests are limited to one concurrent build per repository and one concurrent build per requester. If you request a build while another is still in progress, the second request will be queued until the first completes.</br>
<br>Method: Post</br>
<br>OperationID: repos/request-pages-build</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/pages/builds</br>
