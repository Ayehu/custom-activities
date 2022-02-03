<br>#     Zoom</br>
<br>Assign Phone Number to User </br>
<br>Assign a [phone number](https://support.zoom.us/hc/en-us/articles/360020808292-Managing-Phone-Numbers) to a user who has already enabled Zoom Phone. 

**Scopes**: `phone:write` `phone:write:admin` 
**Prerequisite:** 
1. Business or Enterprise account
2. A Zoom Phone license</br>
<br>Method: Post</br>
<br>OperationID: assignPhoneNumber</br>
<br>EndPoint:</br>
<br>/phone/users/{userId}/phone_numbers</br>
<br>Usage: phone_numbers[]</br>
<br>[{
  "id": "%id%",
  "number": "%number%"
}]</br>
