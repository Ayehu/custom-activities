<br>#     PagerDuty</br>
<br>Create an Event Rule</br>
<br>Create a new Event Rule.

Rulesets allow you to route events to an endpoint and create collections of Event Rules, which define sets of actions to take based on event content.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#rulesets)
</br>
<br>Method: Post</br>
<br>OperationID: createRulesetEventRule</br>
<br>EndPoint:</br>
<br>/rulesets/{id}/rules</br>
<br>Usage: subconditions[]</br>
<br>[{
  "operator": "%subconditions_operator%",
  "parameters": {
    "path": "%path%",
    "value": "%value%"
  }
}]</br>
<br>Usage: variables[]</br>
<br>[{
  "type": "%type%",
  "name": "%name%",
  "parameters": {
    "value": "%parameters_value%",
    "path": "%parameters_path%"
  }
}]</br>
