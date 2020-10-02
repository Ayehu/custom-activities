#     Zoom


Get Location Settings 

Get information on meeting or alert settings applied to Zoom Rooms located in a specific location. By default, only **Meeting Settings** are returned. To view only **Alert Settings**, specify `alert` as the value of the `setting_type` query parameter.
**Prerequisites:**
* Zoom Room licenses
* Owner or Admin privileges on the Zoom Account.
**Scopes:** `room:read:admin` 

Method: Get

OperationID: getZRLocationSettings

EndPoint:

/rooms/locations/{locationId}/settings
