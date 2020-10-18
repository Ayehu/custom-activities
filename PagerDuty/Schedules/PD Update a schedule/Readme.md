<br>#     PagerDuty</br>
<br>Update a schedule</br>
<br>Update an existing on-call schedule.

A Schedule determines the time periods that users are On-Call.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#schedules)
</br>
<br>Method: Put</br>
<br>OperationID: updateSchedule</br>
<br>EndPoint:</br>
<br>/schedules/{id}</br>
<br>Usage: schedule_layers[]</br>
<br>{
  "id": "%schedule_layers_id%",
  "start": "%start%",
  "end": "%end%",
  "users": "[%users%]",
  "restrictions": "[%restrictions%]",
  "rotation_virtual_start": "%rotation_virtual_start%",
  "rotation_turn_length_seconds": "%rotation_turn_length_seconds%",
  "name": "%name%"
}</br>
