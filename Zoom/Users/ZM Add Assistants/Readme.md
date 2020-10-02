#     Zoom


Add Assistants

Assistants are the users to whom the current user has assigned [scheduling privilege](https://support.zoom.us/hc/en-us/articles/201362803-Scheduling-Privilege). These assistants can schedule meeting on behalf of the current user as well as manage and act as an alternative host for all meetings if the admin has enabled [Co-host option](https://zoom.us/account/setting) on the account.Use this API to assign assistants to a user.  In the request body, provide either the User ID or the email address of the user.
**Prerequisite**: 
* The user as well as the assistant must have Licensed or an On-prem license.
* Assistants must be under the current user's account.
**Scopes**: `user:write:admin` `user:write`

 

Method: Post

OperationID: userAssistantCreate

EndPoint:

/users/{userId}/assistants
