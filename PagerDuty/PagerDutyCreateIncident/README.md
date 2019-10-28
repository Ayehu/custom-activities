Incident Creation - Activity to create a new incident in PagerDuty platform.

Remark:
1. Create an account in PagerDuty.
3. Create a team and add users there which will receive notifications.
4. Create a service.
5. Create an API User Token.

Mandatory fields when creating an incident :
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | User -> My Profile -> User Settings -> Create API User Token

ServiceID(string) - Get Service Id from | Configuration -> Services, open the service nad take id from URI (services/SERVICE_ID) 

From(string) - The email address of a valid user associated with the account making the request.
Title(string) - A succinct description of the nature, symptoms, cause, or effect of the incident.
Urgency(string) - The urgency of the incident. It can be high or low.
Details(string) - A succinct details of the nature, symptoms, cause, or effect of the incident. 
