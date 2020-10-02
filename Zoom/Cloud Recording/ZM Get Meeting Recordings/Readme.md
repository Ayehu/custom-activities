#     Zoom


Get Meeting Recordings

Get all the [recordings](https://support.zoom.us/hc/en-us/articles/203741855-Cloud-Recording#h_7420acb5-1897-4061-87b4-5b76e99c03b4) from a meeting. The recording files can be downloaded via the `download_url` property listed in the response.

> To access a password protected cloud recording, add an "access_token" parameter to the download URL and provide [JWT](https://marketplace.zoom.us/docs/guides/getting-started/app-types/create-jwt-app) as the value of the "access_token".


**Scopes:** `recording:read:admin` `recording:read`
 



Method: Get

OperationID: recordingGet

EndPoint:

/meetings/{meetingId}/recordings
