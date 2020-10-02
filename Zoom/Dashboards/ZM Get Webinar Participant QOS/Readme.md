#     Zoom


Get Webinar Participant QOS

Retrieve details on the quality of service that participants from live or past webinars recieved.This data indicates the connection quality for sending/receiving video, audio, and shared content. If nothing is being sent or received at that time, no information will be shown in the fields.
**Scopes:** `dashboard:read:admin` 
**Prerequisites:** 
* Business, Education or API Plan with Zoom Rooms set up.


Method: Get

OperationID: dashboardWebinarParticipantQOS

EndPoint:

/metrics/webinars/{webinarId}/participants/{participantId}/qos
