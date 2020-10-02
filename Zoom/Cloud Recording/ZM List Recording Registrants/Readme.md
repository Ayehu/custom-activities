#     Zoom


List Recording Registrants

Cloud Recordings of past Zoom Meetings can be made [on-demand](https://support.zoom.us/hc/en-us/articles/360000488283-On-demand-Recordings). Users should be [registered](https://marketplace.zoom.us/docs/api-reference/zoom-api/cloud-recording/meetingrecordingregistrantcreate) to view these recordings.

Use this API to list registrants of **On-demand Cloud Recordings** of a past meeting.
**Scopes:** `recording:read:admin`, `recording:read`.
 


Method: Get

OperationID: meetingRecordingRegistrants

EndPoint:

/meetings/{meetingId}/recordings/registrants
