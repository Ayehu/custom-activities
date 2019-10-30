# Get Incident - Activity to get an incident of PagerDuty platform.

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in PagerDuty.
3. Create a team and add users there which will receive notifications.
4. Create a service.
5. Add an incident.
5. Create an API User Token.

Mandatory fields when creating an incident :<br />
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | User -> My Profile -> User Settings -> Create API User Token<br />

Incident Id(string) - Get Incident Id from | Incidents , open the service and take id from URI (incidents/INCIDENT_ID) <br />
Alert Id(string) - Get Alert Id from | Alerts , open the alert and take id from URI (alerts/ALERT_ID) <br />