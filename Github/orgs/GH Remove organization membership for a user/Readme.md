<br>#     Github</br>
<br>Remove organization membership for a user</br>
<br>In order to remove a user's membership with an organization, the authenticated user must be an organization owner.

If the specified user is an active member of the organization, this will remove them from the organization. If the specified user has been invited to the organization, this will cancel their invitation. The specified user will receive an email notification in both cases.</br>
<br>Method: Delete</br>
<br>OperationID: orgs/remove-membership-for-user</br>
<br>EndPoint:</br>
<br>/orgs/{org}/memberships/{username}</br>
