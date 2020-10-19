<br>#     Github</br>
<br>List pending organization invitations</br>
<br>The return hash contains a `role` field which refers to the Organization Invitation role and will be one of the following values: `direct_member`, `admin`, `billing_manager`, `hiring_manager`, or `reinstate`. If the invitee is not a GitHub member, the `login` field in the return hash will be `null`.</br>
<br>Method: Get</br>
<br>OperationID: orgs/list-pending-invitations</br>
<br>EndPoint:</br>
<br>/orgs/{org}/invitations</br>
