<br>#     Zoom</br>
<br>Subscribe to Plans</br>
<br>Subscribe plans for a Sub Account under a Master Account.  The plans can only be subscribed for an existing free Sub Account and the subscriptions charge for these plans should be paid by a Master Account. Zoom only assigns this privilege to trusted partners and only approved partners can use this API. Contact the [**ISV team**](https://zoom.us/plan/api) for more details.
**Scopes**: `billing:master`
 </br>
<br>Method: Post</br>
<br>OperationID: accountPlanCreate</br>
<br>EndPoint:</br>
<br>/accounts/{accountId}/plans</br>
<br>Usage: plan_large_meeting[]</br>
<br>[{
  "type": "%plan_large_meeting_type%",
  "hosts": "%plan_large_meeting_hosts%"
}]</br>
<br>Usage: plan_webinar[]</br>
<br>[{
  "type": "%plan_webinar_type%",
  "hosts": "%plan_webinar_hosts%"
}]</br>
<br>Usage: plan_calling[]</br>
<br>[{
  "type": "%plan_calling_type%",
  "hosts": "%plan_calling_hosts%"
}]</br>
<br>Usage: plan_number[]</br>
<br>[{
  "type": "%plan_number_type%",
  "hosts": "%plan_number_hosts%"
}]</br>
