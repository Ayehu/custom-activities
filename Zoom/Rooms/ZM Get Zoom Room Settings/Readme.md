<br>#     Zoom</br>
<br>Get Zoom Room Settings</br>
<br>Get information on meeting or alert settings applied to a specific Zoom Room. By default, only **Meeting Settings** are returned. To view only **Alert Settings**, specify `alert` as the value of the `setting_type` query parameter.
**Prerequisites:**
* Zoom Room licenses
* Owner or Admin privileges on the Zoom Account.
**Scopes:** `room:read:admin` </br>
<br>Method: Get</br>
<br>OperationID: getZRSettings</br>
<br>EndPoint:</br>
<br>/rooms/{roomId}/settings</br>
