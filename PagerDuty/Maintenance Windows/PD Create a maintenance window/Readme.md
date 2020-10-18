<br>#     PagerDuty</br>
<br>Create a maintenance window</br>
<br>Create a new maintenance window for the specified services. No new incidents will be created for a service that is in maintenance.

A Maintenance Window is used to temporarily disable one or more Services for a set period of time.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#maintenance-windows)
</br>
<br>Method: Post</br>
<br>OperationID: createMaintenanceWindow</br>
<br>EndPoint:</br>
<br>/maintenance_windows</br>
<br>Usage: services[]</br>
<br>[{
  "id": "%id%",
  "type": "%services_type%"
}]</br>
