<br>#     Zoom</br>
<br>Get Zoom Room Account Settings</br>
<br>Get details on Account Settings of a Zoom Room. With this API, you can view either the **Account Meeting Settings** or the **Alert Settings** (Client Alert Settings and Notfication Settings) of the Zoom Rooms account. By default, only **Account Meeting Settings** are returned. To view only **Alert Settings**, specify `alert` as the value of the `setting_type` query parameter.
**Prerequisites:**
* Zoom Room licenses
* Owner or Admin privileges on the Zoom Account.
**Scopes:** `room:read:admin` 
</br>
<br>Method: Get</br>
<br>OperationID: getZRAccountSettings</br>
<br>EndPoint:</br>
<br>/rooms/account_settings</br>
