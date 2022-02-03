<br>#     Github</br>
<br>Update repository preferences for check suites</br>
<br>Changes the default automatic flow when creating check suites. By default, a check suite is automatically created each time code is pushed to a repository. When you disable the automatic creation of check suites, you can manually [Create a check suite](https://developer.github.com/v3/checks/suites/#create-a-check-suite). You must have admin permissions in the repository to set preferences for check suites.</br>
<br>Method: Patch</br>
<br>OperationID: checks/set-suites-preferences</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/check-suites/preferences</br>
<br>Usage: auto_trigger_checks[]</br>
<br>[{
  "app_id": "%app_id%",
  "setting": "%setting%"
}]</br>
