# Update Alert - Activity to update an alert in PagerDuty platform.

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in PagerDuty.
2. Create a team and add users there which will receive notifications.
3. Create a service.
4. Create an API User Token.

Mandatory fields when update an alert :<br />
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | User -> My Profile -> User Settings -> Create API User Token<br />
From(string) - The email address of a valid user associated with the account making the request.<br />
IncidentID(string) - Get Incident ID from | Incidents -> open the Incident and take id from URI (Incidents/INCIDENT_ID) <br />
Alert Id(string) - Get Alert Id from | Alerts , open the alert and take id from URI (alerts/ALERT_ID) <br />
Resolve(boolean) - Is alert resolved?<br />

Optional fields : <br />
Assosiated Incident Id(string) - Incident id which alert should be associated to.
[See more info in official documentation][https://support.pagerduty.com/docs/alerts]