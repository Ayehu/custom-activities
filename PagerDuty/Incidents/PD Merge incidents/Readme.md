<br>#     PagerDuty</br>
<br>Merge incidents</br>
<br>Merge a list of source incidents into this incident.

An incident represents a problem or an issue that needs to be addressed and resolved.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#incidents)
</br>
<br>Method: Put</br>
<br>OperationID: mergeIncidents</br>
<br>EndPoint:</br>
<br>/incidents/{id}/merge</br>
<br>Usage: source_incidents[]</br>
<br>[{
  "id": "%source_incidents_id%",
  "type": "%type%"
}]</br>
