<br>#     PagerDuty</br>
<br>Update a service</br>
<br>Update an existing service.

A service may represent an application, component, or team you wish to open incidents against.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#services)
</br>
<br>Method: Put</br>
<br>OperationID: updateService</br>
<br>EndPoint:</br>
<br>/services/{id}</br>
<br>Usage: scheduled_actions[]</br>
<br>[{
  "type": "%scheduled_actions_type%",
  "at": {
    "type": "%at_type%",
    "name": "%at_name%"
  },
  "to_urgency": "%to_urgency%"
}]</br>
