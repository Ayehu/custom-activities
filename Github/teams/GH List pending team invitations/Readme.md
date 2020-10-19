<br>#     Github</br>
<br>List pending team invitations</br>
<br>The return hash contains a `role` field which refers to the Organization Invitation role and will be one of the following values: `direct_member`, `admin`, `billing_manager`, `hiring_manager`, or `reinstate`. If the invitee is not a GitHub member, the `login` field in the return hash will be `null`.

**Note:** You can also specify a team by `org_id` and `team_id` using the route `GET /organizations/{org_id}/team/{team_id}/invitations`.</br>
<br>Method: Get</br>
<br>OperationID: teams/list-pending-invitations-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/teams/{team_slug}/invitations</br>
