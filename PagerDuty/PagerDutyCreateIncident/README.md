# Incident Creation - Activity to create a new incident in PagerDuty platform.

Remark:
1. Create an account in PagerDuty.
2. Create a team and add users there which will receive notifications.
3. Create a service.
4. Create an API User Token.

Mandatory fields when creating an incident :<br />
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | User -> My Profile -> User Settings -> Create API User Token<br />

ServiceID(string) - Get Service Id from | Configuration -> Services, open the service nad take id from URI (services/SERVICE_ID) <br />

From(string) - The email address of a valid user associated with the account making the request.<br />
Title(string) - A succinct description of the nature, symptoms, cause, or effect of the incident.<br />
Urgency(string) - The urgency of the incident. It can be high or low.<br />
Details(string) - A succinct details of the nature, symptoms, cause, or effect of the incident. <br />
