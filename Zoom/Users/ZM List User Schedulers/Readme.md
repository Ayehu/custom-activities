#     Zoom


List User Schedulers

List all the schedulers of a user. Schedulers in this context are the users for whom the current user can schedule meetings for.

For instance, if the current user (i.e., the user whose userId was passed in the path parameter of this API call) is user A, the response of this API will contain a list of user(s), for whom user A can schedule and manage meetings. User A is the assistant of these users and thus has scheduling privilege for these user(s). 

**Prerequisites**:
* Current user must be under the same account as the scheduler.
**Scopes**: `user:read:admin` `user:read`
 

Method: Get

OperationID: userSchedulers

EndPoint:

/users/{userId}/schedulers
