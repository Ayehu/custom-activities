<br>#     PagerDuty</br>
<br>Get aggregated service data</br>
<br>Provides aggregated metrics for incidents aggregated into units of time by service.

Example metrics include Seconds to Resolve, Seconds to Engage, Snoozed Seconds, and Sleep Hour Interruptions. Some metric definitions can be found in our [Knowledge Base](https://support.pagerduty.com/docs/pagerduty-analytics).
Data can be aggregated by day, week or month in addition to by service, or provided just as a collection of aggregates for each service in the dataset for the entire period.  If a unit is provided, each row in the returned dataset will include a 'range_start' timestamp.


> ### Early Access
> This endpoint is in Early Access and may change at any time. You must pass in the X-EARLY-ACCESS header to access it.

> A `team_ids` or `service_ids` filter is required for [user-level API keys](https://support.pagerduty.com/docs/using-the-api#section-generating-a-personal-rest-api-key) or keys generated through an OAuth flow. Account-level API keys do not have this requirement.
</br>
<br>Method: Post</br>
<br>OperationID: getAnalyticsMetricsIncidentsService</br>
<br>EndPoint:</br>
<br>/analytics/metrics/incidents/services</br>
