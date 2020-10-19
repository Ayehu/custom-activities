<br>#     Github</br>
<br>Update pull request review protection</br>
<br>Protected branches are available in public repositories with GitHub Free and GitHub Free for organizations, and in public and private repositories with GitHub Pro, GitHub Team, GitHub Enterprise Cloud, and GitHub Enterprise Server. For more information, see [GitHub's products](https://help.github.com/github/getting-started-with-github/githubs-products) in the GitHub Help documentation.

Updating pull request review enforcement requires admin or owner permissions to the repository and branch protection to be enabled.

**Note**: Passing new arrays of `users` and `teams` replaces their previous values.</br>
<br>Method: Patch</br>
<br>OperationID: repos/update-pull-request-review-protection</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/branches/{branch}/protection/required_pull_request_reviews</br>
