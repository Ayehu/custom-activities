#     Zoom


Delete User Schedulers

Delete all of a user's schedulers. Schedulers are users on whose behalf the current user (assistant) can schedule meetings for. By calling this API, the current user will no longer be a scheduling assistant of any user. 

**Prerequisite**: Current user (assistant) must be under the same account as the scheduler.
**Scopes**: `user:write:admin` `user:write`

Method: Delete

OperationID: userSchedulersDelete

EndPoint:

/users/{userId}/schedulers
