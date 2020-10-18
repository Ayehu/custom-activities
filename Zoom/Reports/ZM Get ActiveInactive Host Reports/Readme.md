<br>#     Zoom</br>
<br>Get Active/Inactive Host Reports</br>
<br>A user is considered to be an active host during the month specified in the "from" and "to" range, if the user has hosted at least one meeting during this period. If the user didn't host any meetings during this period, the user is considered to be inactive.The Active Hosts report displays a list of meetings, participants, and meeting minutes for a specific time range, up to one month. The month should fall within the last six months.The Inactive Hosts report pulls a list of users who were not active during a specific period of time. 
Use this API to retrieve an active or inactive host report for a specified period of time. The time range for the report is limited to a month and the month should fall under the past six months. You can specify the type of report and date range using the query parameters.
**Scopes:** `report:read:admin`
 
**Prerequisites:**
* Pro or higher plan.</br>
<br>Method: Get</br>
<br>OperationID: reportUsers</br>
<br>EndPoint:</br>
<br>/report/users</br>
