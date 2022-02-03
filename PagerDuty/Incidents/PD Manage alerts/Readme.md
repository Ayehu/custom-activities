<br>#     PagerDuty</br>
<br>Manage alerts</br>
<br>Resolve multiple alerts or associate them with different incidents.

An incident represents a problem or an issue that needs to be addressed and resolved. An alert represents a digital signal that was emitted to PagerDuty by the monitoring systems that detected or identified the issue.

A maximum of 500 alerts may be updated at a time. If more than this number of alerts are given, the API will respond with status 413 (Request Entity Too Large).

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#incidents)
</br>
<br>Method: Put</br>
<br>OperationID: updateIncidentAlerts</br>
<br>EndPoint:</br>
<br>/incidents/{id}/alerts</br>
<br>Usage: alerts[]</br>
<br>[{
  "type": "%type%",
  "status": "%status%"
}]</br>
