<br>#     Zoom</br>
<br>Add an Additional Plan</br>
<br>Add an additional plan for a Sub Account.   Only a Master Account can use this API to subscribe addon plans for a Sub Account whose billing charges are paid by the Master Account. Zoom only assigns this privilege to trusted partners and only approved partners can use this API. Contact the [**ISV team**](https://zoom.us/plan/api) for more details.
**Prerequisites:**
* Pro or a higher plan with Master Account enabled.
* The Sub Account must be a paid account. The billing charges for the Sub Account must be paid by the Master Account.
**Scopes**: `billing:master`
 </br>
<br>Method: Post</br>
<br>OperationID: accountPlanAddonCreate</br>
<br>EndPoint:</br>
<br>/accounts/{accountId}/plans/addons</br>
