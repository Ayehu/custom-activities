#     Zoom


Update Zoom Room Settings

Update either meeting or alert settings applied to a specific Zoom Room. To update **Alert Settings**, specify `alert` as the value of the `setting_type` query parameter. To update **Meeting Settings**, specify `meeting` as the value of the `setting_type` query parameter.
**Prerequisites:**
* Zoom Room licenses
* Owner or Admin privileges on the Zoom Account.
**Scopes:** `room:write:admin` 

Method: Patch

OperationID: updateZRSettings

EndPoint:

/rooms/{roomId}/settings
