#     Zoom


List Devices

List all the [desk phone devices](https://support.zoom.us/hc/en-us/articles/360021119092) that are configured with Zoom Phone on an account. To view devices that have not yet been assigned to a user, set the value of the `type` query parameter as `unassigned` and to view devices that have been assigned, set the value as `assigned`.
**Scopes:** `phone:read:admin`
 
**Prerequisites:**
* Pro or a higher account with Zoom Phone license
* Account owner or admin permissions


Method: Get

OperationID: listPhoneDevices

EndPoint:

/phone/devices
