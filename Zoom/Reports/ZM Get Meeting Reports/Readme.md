#     Zoom


Get Meeting Reports

Retrieve [report](https://support.zoom.us/hc/en-us/articles/216378603-Meeting-Reporting) on a past meeting for a specified period of time. The time range for the report is limited to a month and the month should fall under the past six months.

Meetings will only be returned in the response if the meeting has two or more unique participants.  
**Scopes:** `report:read:admin`
 
**Prerequisites:**
* Pro or higher plan.

Method: Get

OperationID: reportMeetings

EndPoint:

/report/users/{userId}/meetings
