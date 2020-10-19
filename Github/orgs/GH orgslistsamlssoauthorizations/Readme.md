<br>#     Github</br>
<br>List SAML SSO authorizations for an organization</br>
<br>Listing and deleting credential authorizations is available to organizations with GitHub Enterprise Cloud. For more information, see [GitHub's products](https://help.github.com/github/getting-started-with-github/githubs-products).

An authenticated organization owner with the `read:org` scope can list all credential authorizations for an organization that uses SAML single sign-on (SSO). The credentials are either personal access tokens or SSH keys that organization members have authorized for the organization. For more information, see [About authentication with SAML single sign-on](https://help.github.com/en/articles/about-authentication-with-saml-single-sign-on).</br>
<br>Method: Get</br>
<br>OperationID: orgs/list-saml-sso-authorizations</br>
<br>EndPoint:</br>
<br>/orgs/{org}/credential-authorizations</br>
