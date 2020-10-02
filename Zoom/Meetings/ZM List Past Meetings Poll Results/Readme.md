#     Zoom


List Past Meeting's Poll Results

[Polls](https://support.zoom.us/hc/en-us/articles/213756303-Polling-for-Meetings) allow the meeting host to survey attendees. Use this API to list poll results of a meeting.

**Scopes**: `meeting:read:admin`, `meeting:read` 
**Prerequisites**:
* Host user type must be **Pro**.
* Meeting must be a scheduled meeting. Instant meetings do not have polling features enabled.

Method: Get

OperationID: listPastMeetingPolls

EndPoint:

/past_meetings/{meetingId}/polls
