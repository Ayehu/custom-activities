<br>#     PagerDuty</br>
<br>Manage incidents</br>
<br>Acknowledge, resolve, escalate or reassign one or more incidents.

An incident represents a problem or an issue that needs to be addressed and resolved.

A maximum of 500 incidents may be updated at a time. If more than this number of incidents are given, the API will respond with status 413 (Request Entity Too Large).

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#incidents)
</br>
<br>Method: Put</br>
<br>OperationID: updateIncidents</br>
<br>EndPoint:</br>
<br>/incidents</br>
<br>Usage: incidents[]</br>
<br>{
  "id": "%id%",
  "type": "%type%",
  "status": "%status%",
  "resolution": "%resolution%",
  "title": "%title%",
  "priority": {
    "id": "%priority_id%",
    "type": "%priority_type%"
  },
  "escalation_level": "%escalation_level%",
  "assignments": "[%assignments%]",
  "escalation_policy": {
    "id": "%escalation_policy_id%",
    "type": "%escalation_policy_type%"
  },
  "conference_bridge": {
    "conference_number": "%conference_number%",
    "conference_url": "%conference_url%"
  }
}</br>
