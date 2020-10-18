<br>#     Zoom</br>
<br>List Past Meeting's Poll Results</br>
<br>[Polls](https://support.zoom.us/hc/en-us/articles/213756303-Polling-for-Meetings) allow the meeting host to survey attendees. Use this API to list poll results of a meeting.

**Scopes**: `meeting:read:admin`, `meeting:read` 
**Prerequisites**:
* Host user type must be **Pro**.
* Meeting must be a scheduled meeting. Instant meetings do not have polling features enabled.</br>
<br>Method: Get</br>
<br>OperationID: listPastMeetingPolls</br>
<br>EndPoint:</br>
<br>/past_meetings/{meetingId}/polls</br>
