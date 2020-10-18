<br>#     PagerDuty</br>
<br>List audit records</br>
<br>List audit trail records matching provided query params or default criteria.

The returned records are sorted by the `execution_time` from newest to oldest.

See [`Cursor-based pagination`](https://developer.pagerduty.com/docs/rest-api-v2/pagination/) for instructions on how to paginate through the result set.

Only admins, account owners, or global API tokens on PagerDuty account [pricing plans](https://www.pagerduty.com/pricing) with the "Audit Trail" feature can access this endpoint.

For other role based access to audit records by resource ID, see the resource's API documentation.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#audit-record).

> ### Early Access
> This endpoint's interface is under development and subject to change. Do not use it in production systems.
> Your request must set an X-EARLY-ACCESS header with value `audit-early-access` to acknowledge this.
>
> Audit records for user and team resources started in August 2020 and records may be purged while the API is in early access.
</br>
<br>Method: Get</br>
<br>OperationID: listAuditRecords</br>
<br>EndPoint:</br>
<br>/audit/records</br>
