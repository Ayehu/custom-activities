<br>#     PagerDuty</br>
<br>Get aggregated incident data</br>
<br>Provides aggregated enriched metrics for incidents.

The provided metrics are aggregated by day, week, month using the aggregate_unit parameter, or for the entire period if no aggregate_unit is provided.


> ### Early Access
> This endpoint is in Early Access and may change at any time. You must pass in the X-EARLY-ACCESS header to access it.

> A `team_ids` or `service_ids` filter is required for [user-level API keys](https://support.pagerduty.com/docs/using-the-api#section-generating-a-personal-rest-api-key) or keys generated through an OAuth flow. Account-level API keys do not have this requirement.
</br>
<br>Method: Post</br>
<br>OperationID: getAnalyticsMetricsIncidentsAll</br>
<br>EndPoint:</br>
<br>/analytics/metrics/incidents/all</br>
