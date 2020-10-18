<br>#     Zoom</br>
<br>List Meeting Polls</br>
<br>Polls allow the meeting host to survey attendees. Use this API to list [polls](https://support.zoom.us/hc/en-us/articles/213756303-Polling-for-Meetings) of a meeting.

**Scopes**: `meeting:read:admin` `meeting:read`
 
**Prerequisites**:
* Host user type must be **Pro**.
* Meeting must be a scheduled meeting. Instant meetings do not have polling features enabled.</br>
<br>Method: Get</br>
<br>OperationID: meetingPolls</br>
<br>EndPoint:</br>
<br>/meetings/{meetingId}/polls</br>
