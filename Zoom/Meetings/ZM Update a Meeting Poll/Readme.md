<br>#     Zoom</br>
<br>Update a Meeting Poll</br>
<br>Polls allow the meeting host to survey attendees. Use this API to update information of a specific meeting [poll](https://support.zoom.us/hc/en-us/articles/213756303-Polling-for-Meetings)
**Scopes**: `meeting:write:admin` `meeting:write`
 

</br>
<br>Method: Put</br>
<br>OperationID: meetingPollUpdate</br>
<br>EndPoint:</br>
<br>/meetings/{meetingId}/polls/{pollId}</br>
<br>Usage: questions[]</br>
<br>[{
  "name": "%name%",
  "type": "%type%"
}]</br>
