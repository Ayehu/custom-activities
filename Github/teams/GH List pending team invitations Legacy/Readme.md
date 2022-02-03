<br>#     Github</br>
<br>List pending team invitations (Legacy)</br>
<br>**Deprecation Notice:** This endpoint route is deprecated and will be removed from the Teams API. We recommend migrating your existing code to use the new [`List pending team invitations`](https://developer.github.com/v3/teams/members/#list-pending-team-invitations) endpoint.

The return hash contains a `role` field which refers to the Organization Invitation role and will be one of the following values: `direct_member`, `admin`, `billing_manager`, `hiring_manager`, or `reinstate`. If the invitee is not a GitHub member, the `login` field in the return hash will be `null`.</br>
<br>Method: Get</br>
<br>OperationID: teams/list-pending-invitations-legacy</br>
<br>EndPoint:</br>
<br>/teams/{team_id}/invitations</br>
