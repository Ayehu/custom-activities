<br>#     Zoom</br>
<br>Get Role Information</br>
<br>Each Zoom user automatically has a role which can either be owner, administrator, or a member. Account Owners and users with edit privileges for Role management can add customized roles with a list of privileges.

Use this API to get information including specific privileges assigned to a [role](https://support.zoom.us/hc/en-us/articles/115001078646-Role-Based-Access-Control).
**Pre-requisite:**
* A Pro or higher plan.
* For role management and updates, you must be the Account Owner or user with role management permissions.

**Scopes:** `role:read:admin`
 </br>
<br>Method: Get</br>
<br>OperationID: getRoleInformation</br>
<br>EndPoint:</br>
<br>/roles/{roleId}</br>
