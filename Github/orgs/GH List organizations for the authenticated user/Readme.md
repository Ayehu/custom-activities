<br>#     Github</br>
<br>List organizations for the authenticated user</br>
<br>List organizations for the authenticated user.

**OAuth scope requirements**

This only lists organizations that your authorization allows you to operate on in some way (e.g., you can list teams with `read:org` scope, you can publicize your organization membership with `user` scope, etc.). Therefore, this API requires at least `user` or `read:org` scope. OAuth requests with insufficient scope receive a `403 Forbidden` response.</br>
<br>Method: Get</br>
<br>OperationID: orgs/list-for-authenticated-user</br>
<br>EndPoint:</br>
<br>/user/orgs</br>
