<br>#     Github</br>
<br>Create a repository using a template</br>
<br>Creates a new repository using a repository template. Use the `template_owner` and `template_repo` route parameters to specify the repository to use as the template. The authenticated user must own or be a member of an organization that owns the repository. To check if a repository is available to use as a template, get the repository's information using the [Get a repository](https://developer.github.com/v3/repos/#get-a-repository) endpoint and check that the `is_template` key is `true`.

**OAuth scope requirements**

When using [OAuth](https://developer.github.com/apps/building-oauth-apps/understanding-scopes-for-oauth-apps/), authorizations must include:

*   `public_repo` scope or `repo` scope to create a public repository
*   `repo` scope to create a private repository</br>
<br>Method: Post</br>
<br>OperationID: repos/create-using-template</br>
<br>EndPoint:</br>
<br>/repos/{template_owner}/{template_repo}/generate</br>
