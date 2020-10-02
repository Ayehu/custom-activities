#     Zoom


Get a User

A Zoom account can have one or more users. Use this API to view information of a specific user on a Zoom account.
**Scopes:** `user:read:admin` `user:read`
 
 Note: If a user's status is pending, only `id` and `created_at` fields will be returned. The value of `created_at` will be the time at which the API call was made until the user activates their account.

Method: Get
OperationID: user

EndPoint:
/users/{userId}
