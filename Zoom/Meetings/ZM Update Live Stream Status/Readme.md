#     Zoom


Update Live Stream Status

Zoom allows users to [live stream a meeting](https://support.zoom.us/hc/en-us/articles/115001777826-Live-Streaming-Meetings-or-Webinars-Using-a-Custom-Service) to a custom platform. Use this API to update the status of a meeting's live stream.
**Prerequisites:**
* Meeting host must have a Pro license.
**Scopes:** `meeting:write:admin` `meeting:write`  



Method: Patch

OperationID: meetingLiveStreamStatusUpdate

EndPoint:

/meetings/{meetingId}/livestream/status
