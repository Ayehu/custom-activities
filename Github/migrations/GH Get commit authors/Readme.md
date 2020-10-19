<br>#     Github</br>
<br>Get commit authors</br>
<br>Each type of source control system represents authors in a different way. For example, a Git commit author has a display name and an email address, but a Subversion commit author just has a username. The GitHub Importer will make the author information valid, but the author might not be correct. For example, it will change the bare Subversion username `hubot` into something like `hubot `.

This endpoint and the [Map a commit author](https://developer.github.com/v3/migrations/source_imports/#map-a-commit-author) endpoint allow you to provide correct Git author information.</br>
<br>Method: Get</br>
<br>OperationID: migrations/get-commit-authors</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/import/authors</br>
