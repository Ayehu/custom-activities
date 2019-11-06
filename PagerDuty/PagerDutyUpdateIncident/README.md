# Incident Update - Activity to update a incident in PagerDuty platform.

Remark:

1. Create an account in PagerDuty.
3. Create a team and add users there which will receive notifications.
4. Create a service.
5. Create an API User Token.

Mandatory fields when update an incident :<br />
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | User -> My Profile -> User Settings -> Create API User Token<br />
From(string) - The email address of a valid user associated with the account making the request.<br />

IncidentID(string) - Get Incident ID from | Incidents -> open the Incident and take id from URI (Incidents/INCIDENT_ID) <br />
Type(string) - The incident type.Can be incident or incident_reference.<br />
Status(string) - The new status of the incident.Can be resolved or acknowledged.<br />
