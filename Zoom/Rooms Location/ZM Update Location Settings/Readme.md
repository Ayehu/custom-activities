#     Zoom


Update Location Settings

Update information on either meeting or alert settings applied to Zoom Rooms located in a specific location. To update **Alert Settings**, specify `alert` as the value of the `setting_type` query parameter. Similarly, to update **Meeting Settings**, specify `meeting` as the value of the `setting_type` query parameter.
**Prerequisites:**
* Zoom Room licenses
* Owner or Admin privileges on the Zoom Account.
**Scopes:** `room:write:admin` 

Method: Patch

OperationID: updateZRLocationSettings

EndPoint:

/rooms/locations/{locationId}/settings
