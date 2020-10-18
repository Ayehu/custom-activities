<br>#     PagerDuty</br>
<br>Create a schedule</br>
<br>Create a new on-call schedule.

A Schedule determines the time periods that users are On-Call.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#schedules)
</br>
<br>Method: Post</br>
<br>OperationID: createSchedule</br>
<br>EndPoint:</br>
<br>/schedules</br>
<br>Usage: schedule_layers[]</br>
<br>{
  "id": "%id%",
  "start": "%start%",
  "end": "%end%",
  "users": "[%users%]",
  "restrictions": "[%restrictions%]",
  "rotation_virtual_start": "%rotation_virtual_start%",
  "rotation_turn_length_seconds": "%rotation_turn_length_seconds%",
  "name": "%name%"
}</br>
