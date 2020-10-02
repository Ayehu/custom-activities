#     Zoom


Get Sharing/Recording Details of Meeting Participants

Retrieve the sharing and recording details of participants from live or past meetings. You can specify a monthly date range for the dashboard data using the `from` and `to` query parameters. The month should fall within the last six months.
**Scopes:** `dashboard:read:admin` 
**Prerequisites:** 
* Business or a higher plan.

Method: Get

OperationID: dashboardMeetingParticipantShare

EndPoint:

/metrics/meetings/{meetingId}/participants/sharing
