<br>#     Github</br>
<br>Set a thread subscription</br>
<br>If you are watching a repository, you receive notifications for all threads by default. Use this endpoint to ignore future notifications for threads until you comment on the thread or get an **@mention**.

You can also use this endpoint to subscribe to threads that you are currently not receiving notifications for or to subscribed to threads that you have previously ignored.

Unsubscribing from a conversation in a repository that you are not watching is functionally equivalent to the [Delete a thread subscription](https://developer.github.com/v3/activity/notifications/#delete-a-thread-subscription) endpoint.</br>
<br>Method: Put</br>
<br>OperationID: activity/set-thread-subscription</br>
<br>EndPoint:</br>
<br>/notifications/threads/{thread_id}/subscription</br>
