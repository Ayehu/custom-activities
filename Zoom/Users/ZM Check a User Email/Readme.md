<br>#     Zoom</br>
<br>Check a User Email</br>
<br>Verify if a user's email is registered with Zoom.
 Note: Starting November 17, 2019, the behavior of this API will change so that you will be able to successfully check to see if a user is a registered Zoom user only if the user is within your account. If you provide an email address of a user who is not in your account, the value of "existed_email" parameter will be "false" irrespective of whether or not the user is registered with Zoom. 

**Scopes:** `user:read:admin` `user:read`
 
</br>
<br>Method: Get</br>
<br>OperationID: userEmail</br>
<br>EndPoint:</br>
<br>/users/email</br>
