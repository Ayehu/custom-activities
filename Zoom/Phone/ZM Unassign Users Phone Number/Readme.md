<br>#     Zoom</br>
<br>Unassign User's Phone Number</br>
<br>Unassign [phone number](https://support.zoom.us/hc/en-us/articles/360020808292-Managing-Phone-Numbers#h_38ba8b01-26e3-4b1b-a9b5-0717c00a7ca6) of a Zoom phone user. 

After assigning a phone number, you can remove it if you don't want it to be assigned to anyone.

**Scopes**: `phone:write` `phone:write:admin` 
**Prerequisite:** 
1. Business or Enterprise account
2. A Zoom Phone license
3. User must have been previously assigned a Zoom Phone number.</br>
<br>Method: Delete</br>
<br>OperationID: UnassignPhoneNumber</br>
<br>EndPoint:</br>
<br>/phone/users/{userId}/phone_numbers/{phoneNumberId}</br>
