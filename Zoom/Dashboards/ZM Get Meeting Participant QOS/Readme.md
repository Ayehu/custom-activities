#     Zoom


Get Meeting Participant QOS

Retrieve the quality of service for participants from live or past meetings. This data indicates the connection quality for sending/receiving video, audio, and shared content. If nothing is being sent or received at that time, no information will be shown in the fields. 
**Scopes:** `dashboard:read:admin` 

Method: Get

OperationID: dashboardMeetingParticipantQOS

EndPoint:

/metrics/meetings/{meetingId}/participants/{participantId}/qos
