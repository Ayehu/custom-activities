<br>#     Zoom</br>
<br>Create a Recording Registrant</br>
<br>Cloud Recordings of past Zoom Meetings can be made [on-demand](https://support.zoom.us/hc/en-us/articles/360000488283-On-demand-Recordings). Users should be [registered](https://marketplace.zoom.us/docs/api-reference/zoom-api/cloud-recording/meetingrecordingregistrantcreate) to view these recordings.

Use this API to register a user to gain access to **On-demand Cloud Recordings** of a past meeting.
**Scopes:** `recording:write:admin`, `recording:write`.
 

</br>
<br>Method: Post</br>
<br>OperationID: meetingRecordingRegistrantCreate</br>
<br>EndPoint:</br>
<br>/meetings/{meetingId}/recordings/registrants</br>
<br>Usage: custom_questions[]</br>
<br>[{
  "title": "%title%",
  "value": "%value%"
}]</br>
