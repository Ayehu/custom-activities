<br>#     Github</br>
<br>Mark repository notifications as read</br>
<br>Marks all notifications in a repository as "read" removes them from the [default view on GitHub](https://github.com/notifications). If the number of notifications is too large to complete in one request, you will receive a `202 Accepted` status and GitHub will run an asynchronous process to mark notifications as "read." To check whether any "unread" notifications remain, you can use the [List repository notifications for the authenticated user](https://developer.github.com/v3/activity/notifications/#list-repository-notifications-for-the-authenticated-user) endpoint and pass the query parameter `all=false`.</br>
<br>Method: Put</br>
<br>OperationID: activity/mark-repo-notifications-as-read</br>
<br>EndPoint:</br>
<br>/repos/{owner}/{repo}/notifications</br>
