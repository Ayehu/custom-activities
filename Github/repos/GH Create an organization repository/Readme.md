<br>#     Github</br>
<br>Create an organization repository</br>
<br>Creates a new repository in the specified organization. The authenticated user must be a member of the organization.

**OAuth scope requirements**

When using [OAuth](https://developer.github.com/apps/building-oauth-apps/understanding-scopes-for-oauth-apps/), authorizations must include:

*   `public_repo` scope or `repo` scope to create a public repository
*   `repo` scope to create a private repository</br>
<br>Method: Post</br>
<br>OperationID: repos/create-in-org</br>
<br>EndPoint:</br>
<br>/orgs/{org}/repos</br>
