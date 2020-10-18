<br>#     Zoom</br>
<br>Update Role Information</br>
<br>Each Zoom user automatically has a [role](https://support.zoom.us/hc/en-us/articles/115001078646-Role-Based-Access-Control) which can either be owner, administrator, or a member. Account Owners and users with edit privileges for Role management can add customized roles with a list.

Use this API to change the privileges, name and description of a specific role.
**Pre-requisite:**
* A Pro or higher plan.
* For role management and updates, you must be the Account Owner or user with role management permissions.**Scopes:** `role:write:admin`
 </br>
<br>Method: Patch</br>
<br>OperationID: updateRole</br>
<br>EndPoint:</br>
<br>/roles/{roleId}</br>
