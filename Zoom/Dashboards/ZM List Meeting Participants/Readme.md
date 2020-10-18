<br>#     Zoom</br>
<br>List Meeting Participants</br>
<br>Get a list of participants from live or past meetings.
If you do not provide the `type` query parameter, the default value will be set to `live` and thus, you will only see metrics for participants in a live meeting, if any meeting is currently being conducted. To view metrics on past meeting participants, provide the appropriate value for `type`.  You can specify a monthly date range for the dashboard data using the `from` and `to` query parameters. The month should fall within the last six months.

**Scopes:** `dashboard_meetings:read:admin` 
**Prerequisites:** Business or a higher plan.</br>
<br>Method: Get</br>
<br>OperationID: dashboardMeetingParticipants</br>
<br>EndPoint:</br>
<br>/metrics/meetings/{meetingId}/participants</br>
