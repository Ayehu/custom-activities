<br>#     PagerDuty</br>
<br>Get raw data - multiple incidents</br>
<br>Provides enriched incident data and metrics for multiple incidents.

Example metrics include Seconds to Resolve, Seconds to Engage, Snoozed Seconds, and Sleep Hour Interruptions. Some metric definitions can be found in our [Knowledge Base](https://support.pagerduty.com/docs/pagerduty-analytics).


> ### Early Access
> This endpoint is in Early Access and may change at any time. You must pass in the X-EARLY-ACCESS header to access it.

> A `team_ids` or `service_ids` filter is required for [user-level API keys](https://support.pagerduty.com/docs/using-the-api#section-generating-a-personal-rest-api-key) or keys generated through an OAuth flow. Account-level API keys do not have this requirement.
</br>
<br>Method: Post</br>
<br>OperationID: getAnalyticsIncidents</br>
<br>EndPoint:</br>
<br>/analytics/raw/incidents</br>
