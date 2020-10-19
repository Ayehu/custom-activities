<br>#     Github</br>
<br>Get GitHub Actions billing for a user</br>
<br>Gets the summary of the free and paid GitHub Actions minutes used.

Paid minutes only apply to workflows in private repositories that use GitHub-hosted runners. Minutes used is listed for each GitHub-hosted runner operating system. Any job re-runs are also included in the usage. The usage does not include the multiplier for macOS and Windows runners and is not rounded up to the nearest whole minute. For more information, see "[Managing billing for GitHub Actions](https://help.github.com/github/setting-up-and-managing-billing-and-payments-on-github/managing-billing-for-github-actions)".

Access tokens must have the `user` scope.</br>
<br>Method: Get</br>
<br>OperationID: billing/get-github-actions-billing-user</br>
<br>EndPoint:</br>
<br>/users/{username}/settings/billing/actions</br>
