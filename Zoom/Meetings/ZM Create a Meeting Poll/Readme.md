<br>#     Zoom</br>
<br>Create a Meeting Poll</br>
<br>Polls allow the meeting host to survey attendees. Use this API to create a [poll](https://support.zoom.us/hc/en-us/articles/213756303-Polling-for-Meetings) for a meeting.

**Scopes**: `meeting:write:admin` `meeting:write`
 

**Prerequisites**:
* Host user type must be **Pro**.
* Polling feature should be enabled in the host's account.
* Meeting must be a scheduled meeting. Instant meetings do not have polling features enabled.</br>
<br>Method: Post</br>
<br>OperationID: meetingPollCreate</br>
<br>EndPoint:</br>
<br>/meetings/{meetingId}/polls</br>
<br>Usage: questions[]</br>
<br>[{
  "name": "%name%",
  "type": "%type%"
}]</br>
