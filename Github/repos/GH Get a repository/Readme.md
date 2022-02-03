<br>#     Github</br>
<br>Get a repository</br>
<br>When you pass the `scarlet-witch-preview` media type, requests to get a repository will also return the repository's code of conduct if it can be detected from the repository's code of conduct file.

The `parent` and `source` objects are present when the repository is a fork. `parent` is the repository this repository was forked from, `source` is the ultimate source for the network.</br>
<br>Method: Get</br>
<br>OperationID: repos/get</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}</br>
