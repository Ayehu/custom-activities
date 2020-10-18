<br>#     Zoom</br>
<br>Delete User</br>
<br>Deleting a user permanently removes them and their data from Zoom. They will be able to create a new Zoom account with the same email address if they have access to it. An account owner or an account admin can transfer meetings, webinars and cloud recordings to another Zoom user before deleting, but if not transferred, they will be permanently deleted.

By default, this API disassociates (unlinks) a user from the associated account. The disassociation will give them their own basic, free Zoom account. It will not be associated with your account, and they will be able to purchase their own licenses. You can transfer the user's data (meetings, webinars and cloud recordings) to another user before disassociation. To permanently delete a user, specify "delete" as the value of the `action` query parameter.
**Scopes:** `user:write:admin` `user:write`
 </br>
<br>Method: Delete</br>
<br>OperationID: userDelete</br>
<br>EndPoint:</br>
<br>/users/{userId}</br>
