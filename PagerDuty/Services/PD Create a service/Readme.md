<br>#     PagerDuty</br>
<br>Create a service</br>
<br>Create a new service.

If `status` is included in the request, it must have a value of `active` when creating a new service. If a different status is required, make a second request to update the service.

A service may represent an application, component, or team you wish to open incidents against.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#services)
</br>
<br>Method: Post</br>
<br>OperationID: createService</br>
<br>EndPoint:</br>
<br>/services</br>
<br>Usage: scheduled_actions[]</br>
<br>[{
  "type": "%scheduled_actions_type%",
  "at": {
    "type": "%at_type%",
    "name": "%at_name%"
  },
  "to_urgency": "%to_urgency%"
}]</br>
