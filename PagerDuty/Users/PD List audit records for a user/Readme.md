<br>#     PagerDuty</br>
<br>List audit records for a user</br>
<br>The response will include audit records with changes that are made to the identified user not changes made by the identified user.


The returned records are sorted by the `execution_time` from newest to oldest.

See [`Cursor-based pagination`](https://developer.pagerduty.com/docs/rest-api-v2/pagination/) for instructions on how to paginate through the result set.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#audit-record).


> ### Early Access
> This endpoint's interface is under development and subject to change. Do not use it in production systems.
> Your request must set an X-EARLY-ACCESS header with value `audit-early-access` to acknowledge this.
>
> Audit records for user and team resources started in August 2020 and records may be purged while the API is in early access.
</br>
<br>Method: Get</br>
<br>OperationID: listUsersAuditRecords</br>
<br>EndPoint:</br>
<br>/users/{id}/audit/records</br>
