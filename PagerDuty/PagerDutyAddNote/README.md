# Add Note - Activity to add a note to an incident in PagerDuty platform.

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in PagerDuty.
2. Create a team and add users there which will receive notifications.
3. Create a service.
4. Create an API User Token.

Mandatory fields when sending an alert :<br />
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | User -> My Profile -> User Settings -> Create API User Token<br />
Incident Id(string) - Get Incident Id from | Incidents , open the service and take id from URI (incidents/INCIDENT_ID) <br />
From(string) - The email address of a valid user associated with the account making the request<br />
Note(string) - The note to be added to the specific incident<br />

[See more info in official documentation][https://api-reference.pagerduty.com/#!/Incidents/post_incidents_id_notes]
