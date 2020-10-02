#     Zoom


Create a Meeting Poll

Polls allow the meeting host to survey attendees. Use this API to create a [poll](https://support.zoom.us/hc/en-us/articles/213756303-Polling-for-Meetings) for a meeting.

**Scopes**: `meeting:write:admin` `meeting:write`
 

**Prerequisites**:
* Host user type must be **Pro**.
* Polling feature should be enabled in the host's account.
* Meeting must be a scheduled meeting. Instant meetings do not have polling features enabled.

Method: Post

OperationID: meetingPollCreate

EndPoint:

/meetings/{meetingId}/polls
