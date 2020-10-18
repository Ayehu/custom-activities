<br>#     PagerDuty</br>
<br>Add a user to a team</br>
<br>Add a user to a team. Attempting to add a user with the `read_only_user` role will return a 400 error.

A team is a collection of Users and Escalation Policies that represent a group of people within an organization.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#teams)
</br>
<br>Method: Put</br>
<br>OperationID: updateTeamUser</br>
<br>EndPoint:</br>
<br>/teams/{id}/users/{user_id}</br>
