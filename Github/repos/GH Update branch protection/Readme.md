<br>#     Github</br>
<br>Update branch protection</br>
<br>Protected branches are available in public repositories with GitHub Free and GitHub Free for organizations, and in public and private repositories with GitHub Pro, GitHub Team, GitHub Enterprise Cloud, and GitHub Enterprise Server. For more information, see [GitHub's products](https://help.github.com/github/getting-started-with-github/githubs-products) in the GitHub Help documentation.

Protecting a branch requires admin or owner permissions to the repository.

**Note**: Passing new arrays of `users` and `teams` replaces their previous values.

**Note**: The list of users, apps, and teams in total is limited to 100 items.</br>
<br>Method: Put</br>
<br>OperationID: repos/update-branch-protection</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/branches/{branch}/protection</br>
