<br>#     PagerDuty</br>
<br>Delete a user</br>
<br>Remove an existing user.

Returns 400 if the user has assigned incidents unless your [pricing plan](https://www.pagerduty.com/pricing) has the `offboarding` feature and the account is [configured](https://support.pagerduty.com/docs/offboarding#section-additional-configurations) appropriately.

Note that the incidents reassignment process is asynchronous and has no guarantee to complete before the api call return.

[*Learn more about `offboarding` feature*](https://support.pagerduty.com/docs/offboarding).

Users are members of a PagerDuty account that have the ability to interact with Incidents and other data on the account.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#users)
</br>
<br>Method: Delete</br>
<br>OperationID: deleteUser</br>
<br>EndPoint:</br>
<br>/users/{id}</br>
