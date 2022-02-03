<br>#     PagerDuty</br>
<br>Delete a team</br>
<br>Remove an existing team. 

Succeeds only if the team has no associated Escalation Policies, Services, Schedules and Subteams. 

All associated unresovled incidents will be reassigned to another team (if specified) or will loose team association, thus becoming account-level (with visibility implications). 

Note that the incidents reassignment process is asynchronous and has no guarantee to complete before the API call return.

A team is a collection of Users and Escalation Policies that represent a group of people within an organization.

For more information see the [API Concepts Document](../../docs/CONCEPTS.md#teams)
</br>
<br>Method: Delete</br>
<br>OperationID: deleteTeam</br>
<br>EndPoint:</br>
<br>/teams/{id}</br>
