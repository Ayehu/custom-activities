<br>#     PagerDuty</br>
<br>Delete an override</br>
<br>Remove an override. 

You cannot remove a past override. 

If the override start time is before the current time, but the end time is after the current time, the override will be truncated to the current time. 

If the override is truncated, the status code will be 200 OK, as opposed to a 204 No Content for a successful delete.

A Schedule determines the time periods that users are On-Call.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#schedules)
</br>
<br>Method: Delete</br>
<br>OperationID: deleteScheduleOverride</br>
<br>EndPoint:</br>
<br>/schedules/{id}/overrides/{override_id}</br>
