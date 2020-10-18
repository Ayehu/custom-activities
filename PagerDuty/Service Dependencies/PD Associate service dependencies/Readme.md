<br>#     PagerDuty</br>
<br>Associate service dependencies</br>
<br>Create new dependencies between two services.

Business services model capabilities that span multiple technical services and that may be owned by several different teams.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#business-services)
</br>
<br>Method: Post</br>
<br>OperationID: createServiceDependency</br>
<br>EndPoint:</br>
<br>/service_dependencies/associate</br>
<br>Usage: relationships[]</br>
<br>[{
  "supporting_service": {
    "id": "%id%",
    "type": "%type%"
  },
  "dependent_service": {
    "id": "%dependent_service_id%",
    "type": "%dependent_service_type%"
  }
}]</br>
