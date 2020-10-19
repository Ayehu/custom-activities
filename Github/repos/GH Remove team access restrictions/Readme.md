<br>#     Github</br>
<br>Remove team access restrictions</br>
<br>Protected branches are available in public repositories with GitHub Free and GitHub Free for organizations, and in public and private repositories with GitHub Pro, GitHub Team, GitHub Enterprise Cloud, and GitHub Enterprise Server. For more information, see [GitHub's products](https://help.github.com/github/getting-started-with-github/githubs-products) in the GitHub Help documentation.

Removes the ability of a team to push to this branch. You can also remove push access for child teams.

| Type    | Description                                                                                                                                         |
| ------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| `array` | Teams that should no longer have push access. Use the team's `slug`. **Note**: The list of users, apps, and teams in total is limited to 100 items. |</br>
<br>Method: Delete</br>
<br>OperationID: repos/remove-team-access-restrictions</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/branches/{branch}/protection/restrictions/teams</br>
