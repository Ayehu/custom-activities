#     Zoom


Delete a Meeting Poll

Polls allow the meeting host to survey attendees. Use this API to delete a meeting [poll](https://support.zoom.us/hc/en-us/articles/213756303-Polling-for-Meetings).
**Scopes**: `meeting:write:admin` `meeting:write`
 
**Prerequisites**:
* Host user type must be **Pro**.
* Polling feature should be enabled in the host's account.
* Meeting must be a scheduled meeting. Instant meetings do not have polling features enabled.

Method: Delete

OperationID: meetingPollDelete

EndPoint:

/meetings/{meetingId}/polls/{pollId}
