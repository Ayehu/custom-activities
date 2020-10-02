#     Zoom


Recover Meeting Recordings

Zoom allows users to recover recordings from trash for up to 30 days from the deletion date. Use this API to recover all deleted [Cloud Recordings](https://support.zoom.us/hc/en-us/articles/203741855-Cloud-Recording) of a specific meeting.
**Scopes**: `recording:write:admin` `recording:write`
 
**Prerequisites**:
* A Pro user with Cloud Recording enabled.

Method: Put

OperationID: recordingStatusUpdate

EndPoint:

/meetings/{meetingId}/recordings/status
