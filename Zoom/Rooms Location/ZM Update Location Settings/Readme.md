<br>#     Zoom</br>
<br>Update Location Settings</br>
<br>Update information on either meeting or alert settings applied to Zoom Rooms located in a specific location. To update **Alert Settings**, specify `alert` as the value of the `setting_type` query parameter. Similarly, to update **Meeting Settings**, specify `meeting` as the value of the `setting_type` query parameter.
**Prerequisites:**
* Zoom Room licenses
* Owner or Admin privileges on the Zoom Account.
**Scopes:** `room:write:admin` </br>
<br>Method: Patch</br>
<br>OperationID: updateZRLocationSettings</br>
<br>EndPoint:</br>
<br>/rooms/locations/{locationId}/settings</br>
