# Get Alert - Activity to get an alert of PagerDuty platform.

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in PagerDuty.
2. Create a team and add users there which will receive notifications.
3. Create a service.
4. Add an incident.
5. Create an API User Token.

Mandatory fields when creating an incident :<br />
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | User -> My Profile -> User Settings -> Create API User Token<br />

Incident Id(string) - Get Incident Id from | Incidents , open the service and take id from URI (incidents/INCIDENT_ID) <br />
Alert Id(string) - Get Alert Id from | Alerts , open the alert summary and take id from URI (alerts/ALERT_ID) <br />
[See more info in official documentation][https://support.pagerduty.com/docs/alerts]