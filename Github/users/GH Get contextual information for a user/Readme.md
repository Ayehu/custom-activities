<br>#     Github</br>
<br>Get contextual information for a user</br>
<br>Provides hovercard information when authenticated through basic auth or OAuth with the `repo` scope. You can find out more about someone in relation to their pull requests, issues, repositories, and organizations.

The `subject_type` and `subject_id` parameters provide context for the person's hovercard, which returns more information than without the parameters. For example, if you wanted to find out more about `octocat` who owns the `Spoon-Knife` repository via cURL, it would look like this:

```shell
 curl -u username:token
  https://api.github.com/users/octocat/hovercard?subject_type=repositorysubject_id=1300192
```</br>
<br>Method: Get</br>
<br>OperationID: users/get-context-for-user</br>
<br>EndPoint:</br>
<br>/users/{username}/hovercard</br>
