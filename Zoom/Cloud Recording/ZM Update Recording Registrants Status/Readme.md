<br>#     Zoom</br>
<br>Update Recording Registrant's Status</br>
<br>A registrant can either be approved or denied from viewing the [on-demand](https://support.zoom.us/hc/en-us/articles/360000488283-On-demand-Recordings) recording. 
Use this API to update a registrant's status.

**Scopes:** `recording:write:admin`, `recording:write`
 
</br>
<br>Method: Put</br>
<br>OperationID: meetingRecordingRegistrantStatus</br>
<br>EndPoint:</br>
<br>/meetings/{meetingId}/recordings/registrants/status</br>
<br>Usage: registrants[]</br>
<br>[{
  "id": "%id%"
}]</br>
