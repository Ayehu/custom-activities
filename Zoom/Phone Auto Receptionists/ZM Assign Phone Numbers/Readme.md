#     Zoom


Assign Phone Numbers

Assign available phone numbers to an [auto receptionist](https://support.zoom.us/hc/en-us/articles/360021121312-Managing-Auto-Receptionists-and-Interactive-Voice-Response-IVR-). The available numbers can be retrieved using the List Phone Numbers API with `type` query parameter set to "unassigned".

**Prerequisites:**
* Pro or higher account plan with Zoom Phone License
* Account owner or admin permissions
**Scopes:** `phone:write:admin` 



Method: Post

OperationID: assignPhoneNumbersAutoReceptionist

EndPoint:

/phone/auto_receptionists/{autoReceptionistId}/phone_numbers
