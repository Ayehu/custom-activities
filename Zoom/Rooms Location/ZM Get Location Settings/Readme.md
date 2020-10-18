<br>#     Zoom</br>
<br>Get Location Settings </br>
<br>Get information on meeting or alert settings applied to Zoom Rooms located in a specific location. By default, only **Meeting Settings** are returned. To view only **Alert Settings**, specify `alert` as the value of the `setting_type` query parameter.
**Prerequisites:**
* Zoom Room licenses
* Owner or Admin privileges on the Zoom Account.
**Scopes:** `room:read:admin` </br>
<br>Method: Get</br>
<br>OperationID: getZRLocationSettings</br>
<br>EndPoint:</br>
<br>/rooms/locations/{locationId}/settings</br>
