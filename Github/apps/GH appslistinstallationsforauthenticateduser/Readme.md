<br>#     Github</br>
<br>List app installations accessible to the user access token</br>
<br>Lists installations of your GitHub App that the authenticated user has explicit permission (`:read`, `:write`, or `:admin`) to access.

You must use a [user-to-server OAuth access token](https://developer.github.com/apps/building-github-apps/identifying-and-authorizing-users-for-github-apps/#identifying-users-on-your-site), created for a user who has authorized your GitHub App, to access this endpoint.

The authenticated user has explicit permission to access repositories they own, repositories where they are a collaborator, and repositories that they can access through an organization membership.

You can find the permissions for the installation under the `permissions` key.</br>
<br>Method: Get</br>
<br>OperationID: apps/list-installations-for-authenticated-user</br>
<br>EndPoint:</br>
<br>/user/installations</br>
