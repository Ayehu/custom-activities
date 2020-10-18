<br>#     Zoom</br>
<br>Delete a Scheduler</br>
<br>Delete a Scheduler.

Schedulers are users on whose behalf the current user (assistant) can schedule meetings for. By calling this API, the current user will no longer be a scheduling assistant of this scheduler. 

**Prerequisite**: Current user must be under the same account as the scheduler.
**Scopes**: `user:write:admin` `user:write`</br>
<br>Method: Delete</br>
<br>OperationID: userSchedulerDelete</br>
<br>EndPoint:</br>
<br>/users/{userId}/schedulers/{schedulerId}</br>
