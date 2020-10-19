<br>#     Github</br>
<br>List repository contributors</br>
<br>Lists contributors to the specified repository and sorts them by the number of commits per contributor in descending order. This endpoint may return information that is a few hours old because the GitHub REST API v3 caches contributor data to improve performance.

GitHub identifies contributors by author email address. This endpoint groups contribution counts by GitHub user, which includes all associated email addresses. To improve performance, only the first 500 author email addresses in the repository link to GitHub users. The rest will appear as anonymous contributors without associated GitHub user information.</br>
<br>Method: Get</br>
<br>OperationID: repos/list-contributors</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/contributors</br>
