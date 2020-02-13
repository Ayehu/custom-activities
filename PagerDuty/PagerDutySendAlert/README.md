# Send Alert - Activity to send an alert in PagerDuty platform.

Dependencies:
1. Newtonsoft.Json

Remark:
1. Create an account in PagerDuty.
2. Create a team and add users there which will receive notifications.
3. Create a service.
4. Create an API User Token.

Mandatory fields when sending an alert :<br />
Routing key(string) - This is the 32 character Integration Key for an integration on a service or on a global ruleset<br />
Summary(string) - A brief text summary of the event, used to generate the summaries/titles of any associated alerts. The maximum permitted length of this property is 1024 characters<br />
Source(string) - The unique location of the affected system, preferably a hostname or FQDN<br />
Severity(string) - The perceived severity of the status the event is describing with respect to the affected system. This can be critical, error, warning or info<br />
Component(string) - Component of the source machine that is responsible for the event, for example mysql or eth0<br />
Class(string) - The class/type of the event, for example ping failure or cpu load<br />

[See more info in official documentation][https://v2.developer.pagerduty.com/docs/send-an-event-events-api-v2]