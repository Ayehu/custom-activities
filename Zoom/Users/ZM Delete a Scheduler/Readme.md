#     Zoom


Delete a Scheduler

Delete a Scheduler.

Schedulers are users on whose behalf the current user (assistant) can schedule meetings for. By calling this API, the current user will no longer be a scheduling assistant of this scheduler. 

**Prerequisite**: Current user must be under the same account as the scheduler.
**Scopes**: `user:write:admin` `user:write`

Method: Delete

OperationID: userSchedulerDelete

EndPoint:

/users/{userId}/schedulers/{schedulerId}
