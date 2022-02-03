<br>#     Github</br>
<br>List accounts for a plan</br>
<br>Returns user and organization accounts associated with the specified plan, including free plans. For per-seat pricing, you see the list of accounts that have purchased the plan, including the number of seats purchased. When someone submits a plan change that won't be processed until the end of their billing cycle, you will also see the upcoming pending change.

GitHub Apps must use a [JWT](https://developer.github.com/apps/building-github-apps/authenticating-with-github-apps/#authenticating-as-a-github-app) to access this endpoint. OAuth Apps must use [basic authentication](https://developer.github.com/v3/auth/#basic-authentication) with their client ID and client secret to access this endpoint.</br>
<br>Method: Get</br>
<br>OperationID: apps/list-accounts-for-plan</br>
<br>EndPoint:</br>
<br>/marketplace_listing/plans/{plan_id}/accounts</br>
