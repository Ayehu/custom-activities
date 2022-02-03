<br>#     Zoom</br>
<br>Cancel  Additional Plans</br>
<br>[Cancel additional plan](https://support.zoom.us/hc/en-us/articles/203634215-How-Do-I-Cancel-My-Subscription-) of a Sub Account. The cancellation does not provide refund for the current subscription. The service remains active for the current session.
 Only a Master Account can use this API to cancel the addon plans for a Sub Account whose billing charges are paid by the Master Account. Zoom only assigns this privilege to trusted partners and only approved partners can use this API. Contact the [**ISV team**](https://zoom.us/plan/api) for more details.

**Prerequisites:**
* Pro or a higher plan with Master Account option enabled.
* The Sub Account must be a paid account.
**Scope:** `billing:master`
 </br>
<br>Method: Patch</br>
<br>OperationID: accountPlanAddonCancel</br>
<br>EndPoint:</br>
<br>/accounts/{accountId}/plans/addons/status</br>
