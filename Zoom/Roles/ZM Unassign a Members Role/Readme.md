#     Zoom


Unassign a Member's Role

User [roles](https://support.zoom.us/hc/en-us/articles/115001078646-Role-Based-Access-Control) can have a set of permissions that allows access only to the pages a user needs to view or edit. Use this API to unassign a user's role.

**Scope:** `role:write:admin`
 
**Prerequisites:**
* A Pro or a higher plan.

Method: Delete

OperationID: roleMemberDelete

EndPoint:

/roles/{roleId}/members/{memberId}
