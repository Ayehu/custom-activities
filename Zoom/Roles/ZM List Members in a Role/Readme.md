#     Zoom


List Members in a Role

User [roles](https://support.zoom.us/hc/en-us/articles/115001078646-Role-Based-Access-Control) can have a set of permissions that allows access only to the pages a user needs to view or edit. Use this API to list all the members that are assigned a specific role.

**Scope:** `role:read:admin`
 **Prerequisites:**
* A Pro or a higher plan.

Method: Get

OperationID: roleMembers

EndPoint:

/roles/{roleId}/members
