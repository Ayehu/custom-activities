<br>#     PagerDuty</br>
<br>List audit records for an escalation policy</br>
<br>The returned records are sorted by the `execution_time` from newest to oldest.

See [`Cursor-based pagination`](https://developer.pagerduty.com/docs/rest-api-v2/pagination/) for instructions on how to paginate through the result set.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#audit-record).

> ### Early Access
> This endpoint's interface is under development and subject to change. Do not use it in production systems.
> Your request must set an X-EARLY-ACCESS header with value `audit-early-access` to acknowledge this.
>
> Audit records for escalation policies resource started in August 2020 and records may be purged while the API is in early access.
</br>
<br>Method: Get</br>
<br>OperationID: listEscalationPolicyAuditRecords</br>
<br>EndPoint:</br>
<br>/escalation_policies/{id}/audit/records</br>
