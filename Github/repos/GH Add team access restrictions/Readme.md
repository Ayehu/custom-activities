<br>#     Github</br>
<br>Add team access restrictions</br>
<br>Protected branches are available in public repositories with GitHub Free and GitHub Free for organizations, and in public and private repositories with GitHub Pro, GitHub Team, GitHub Enterprise Cloud, and GitHub Enterprise Server. For more information, see [GitHub's products](https://help.github.com/github/getting-started-with-github/githubs-products) in the GitHub Help documentation.

Grants the specified teams push access for this branch. You can also give push access to child teams.

| Type    | Description                                                                                                                                |
| ------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| `array` | The teams that can have push access. Use the team's `slug`. **Note**: The list of users, apps, and teams in total is limited to 100 items. |</br>
<br>Method: Post</br>
<br>OperationID: repos/add-team-access-restrictions</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/branches/{branch}/protection/restrictions/teams</br>
