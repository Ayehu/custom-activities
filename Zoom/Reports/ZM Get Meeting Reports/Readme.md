<br>#     Zoom</br>
<br>Get Meeting Reports</br>
<br>Retrieve [report](https://support.zoom.us/hc/en-us/articles/216378603-Meeting-Reporting) on a past meeting for a specified period of time. The time range for the report is limited to a month and the month should fall under the past six months.

Meetings will only be returned in the response if the meeting has two or more unique participants.  
**Scopes:** `report:read:admin`
 
**Prerequisites:**
* Pro or higher plan.</br>
<br>Method: Get</br>
<br>OperationID: reportMeetings</br>
<br>EndPoint:</br>
<br>/report/users/{userId}/meetings</br>
