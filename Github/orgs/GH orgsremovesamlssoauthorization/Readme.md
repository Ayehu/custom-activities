<br>#     Github</br>
<br>Remove a SAML SSO authorization for an organization</br>
<br>Listing and deleting credential authorizations is available to organizations with GitHub Enterprise Cloud. For more information, see [GitHub's products](https://help.github.com/github/getting-started-with-github/githubs-products).

An authenticated organization owner with the `admin:org` scope can remove a credential authorization for an organization that uses SAML SSO. Once you remove someone's credential authorization, they will need to create a new personal access token or SSH key and authorize it for the organization they want to access.</br>
<br>Method: Delete</br>
<br>OperationID: orgs/remove-saml-sso-authorization</br>
<br>EndPoint:</br>
<br>/orgs/{org}/credential-authorizations/{credential_id}</br>
