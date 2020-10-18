<br>#     Zoom</br>
<br>List Meeting Participants QOS</br>
<br>Get a list of meeting participants from live or past meetings along with the quality of service they recieve during the meeting such as connection quality for sending/receiving video, audio, and shared content.If you do not provide the `type` query parameter, the default value will be set to `live` and thus, you will only see metrics for participants in a live meeting, if any meeting is currently being conducted. To view metrics on past meeting participants, provide the appropriate value for `type`.  You can specify a monthly date range for the dashboard data using the `from` and `to` query parameters. The month should fall within the last six months.
**Scopes:** `dashboard_meetings:read:admin` 
**Prerequisites:** 
* Business or a higher plan.</br>
<br>Method: Get</br>
<br>OperationID: dashboardMeetingParticipantsQOS</br>
<br>EndPoint:</br>
<br>/metrics/meetings/{meetingId}/participants/qos</br>
