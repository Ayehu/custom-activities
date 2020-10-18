<br>#     LogicMonitor</br>
<br>update device instance</br>
<br>LM update device instance</br>
<br>Method: Patch</br>
<br>OperationID: patchDeviceDatasourceInstanceById</br>
<br>EndPoint:</br>
<br>/device/devices/{deviceId}/devicedatasources/{hdsId}/instances/{id}</br>
<br>Usage: autoProperties[]</br>
<br>[{
  "name": "%name%",
  "value": "%value%"
}]</br>
<br>Usage: customProperties[]</br>
<br>[{
  "name": "%customProperties_name%",
  "value": "%customProperties_value%"
}]</br>
<br>Usage: systemProperties[]</br>
<br>[{
  "name": "%systemProperties_name%",
  "value": "%systemProperties_value%"
}]</br>
