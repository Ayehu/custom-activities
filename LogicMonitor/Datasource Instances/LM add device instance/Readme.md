<br>#     LogicMonitor</br>
<br>add device instance </br>
<br>LM add device instance</br>
<br>Method: Post</br>
<br>OperationID: addDeviceDatasourceInstance</br>
<br>EndPoint:</br>
<br>/device/devices/{deviceId}/devicedatasources/{hdsId}/instances</br>
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
