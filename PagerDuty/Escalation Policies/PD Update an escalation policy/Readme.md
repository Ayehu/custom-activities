<br>#     PagerDuty</br>
<br>Update an escalation policy</br>
<br>Updates an existing escalation policy and rules.

Escalation policies define which user should be alerted at which time.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#escalation-policies)
</br>
<br>Method: Put</br>
<br>OperationID: updateEscalationPolicy</br>
<br>EndPoint:</br>
<br>/escalation_policies/{id}</br>
<br>Usage: escalation_rules[]</br>
<br>{
  "escalation_delay_in_minutes": "%escalation_delay_in_minutes%",
  "targets": "[%targets%]"
}</br>
<br>Usage: services[]</br>
<br>[{
  "id": "%services_id%",
  "type": "%services_type%"
}]</br>
<br>Usage: teams[]</br>
<br>[{
  "id": "%teams_id%",
  "type": "%teams_type%"
}]</br>
