<br>#     Zoom</br>
<br>Assign Phone Numbers</br>
<br>Assign available phone numbers to an [auto receptionist](https://support.zoom.us/hc/en-us/articles/360021121312-Managing-Auto-Receptionists-and-Interactive-Voice-Response-IVR-). The available numbers can be retrieved using the List Phone Numbers API with `type` query parameter set to "unassigned".

**Prerequisites:**
* Pro or higher account plan with Zoom Phone License
* Account owner or admin permissions
**Scopes:** `phone:write:admin` 

</br>
<br>Method: Post</br>
<br>OperationID: assignPhoneNumbersAutoReceptionist</br>
<br>EndPoint:</br>
<br>/phone/auto_receptionists/{autoReceptionistId}/phone_numbers</br>
<br>Usage: phone_numbers[]</br>
<br>[{
  "id": "%id%",
  "number": "%number%"
}]</br>
