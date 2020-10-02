#     Zoom


Delete a Role

Each Zoom user automatically has a role which can either be owner, administrator, or a member. Account Owners and users with edit privileges for Role management can add customized roles with a list.

Use this API to delete a role.
**Pre-requisite:**
* A Pro or higher plan.
* For role management and updates, you must be the Account Owner or user with role management permissions.

**Scopes:** `role:write:admin`
 

Method: Delete

OperationID: deleteRole

EndPoint:

/roles/{roleId}
