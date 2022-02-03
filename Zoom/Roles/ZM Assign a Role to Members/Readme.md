<br>#     Zoom</br>
<br>Assign a Role to Members</br>
<br>User [roles](https://support.zoom.us/hc/en-us/articles/115001078646-Role-Based-Access-Control) can have a set of permissions that allows access only to the pages a user needs to view or edit. Use this API to [assign a role](https://support.zoom.us/hc/en-us/articles/115001078646-Role-Based-Access-Control#h_748b6fd8-5057-4cf4-bbfd-787909c09db0) to members.

**Scopes:** `role:write:admin`
 
**Prerequisites:**
* A Pro or a higher plan.</br>
<br>Method: Post</br>
<br>OperationID: AddRoleMembers</br>
<br>EndPoint:</br>
<br>/roles/{roleId}/members</br>
<br>Usage: members[]</br>
<br>[{
  "id": "%id%",
  "email": "%email%"
}]</br>
