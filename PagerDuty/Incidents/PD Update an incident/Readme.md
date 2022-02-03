<br>#     PagerDuty</br>
<br>Update an incident</br>
<br>Acknowledge, resolve, escalate or reassign an incident.

An incident represents a problem or an issue that needs to be addressed and resolved.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#incidents)
</br>
<br>Method: Put</br>
<br>OperationID: updateIncident</br>
<br>EndPoint:</br>
<br>/incidents/{id}</br>
<br>Usage: assignments[]</br>
<br>[{
  "assignee": {
    "id": "%assignee_id%",
    "type": "%assignee_type%"
  }
}]</br>
