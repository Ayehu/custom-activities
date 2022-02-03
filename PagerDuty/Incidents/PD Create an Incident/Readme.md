<br>#     PagerDuty</br>
<br>Create an Incident</br>
<br>Create an incident synchronously without a corresponding event from a monitoring service.

An incident represents a problem or an issue that needs to be addressed and resolved.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#incidents)
</br>
<br>Method: Post</br>
<br>OperationID: createIncident</br>
<br>EndPoint:</br>
<br>/incidents</br>
<br>Usage: assignments[]</br>
<br>[{
  "assignee": {
    "id": "%assignee_id%",
    "type": "%assignee_type%"
  }
}]</br>
