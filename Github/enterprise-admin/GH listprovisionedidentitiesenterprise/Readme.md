<br>#     Github</br>
<br>List SCIM provisioned identities for an enterprise</br>
<br>**Note:** The SCIM API endpoints for enterprise accounts are currently in beta and are subject to change.

Retrieves a paginated list of all provisioned enterprise members, including pending invitations.

When a user with a SAML-provisioned external identity leaves (or is removed from) an enterprise, the account's metadata is immediately removed. However, the returned list of user accounts might not always match the organization or enterprise member list you see on GitHub. This can happen in certain cases where an external identity associated with an organization will not match an organization member:
  - When a user with a SCIM-provisioned external identity is removed from an enterprise, the account's metadata is preserved to allow the user to re-join the organization in the future.
  - When inviting a user to join an organization, you can expect to see their external identity in the results before they accept the invitation, or if the invitation is cancelled (or never accepted).
  - When a user is invited over SCIM, an external identity is created that matches with the invitee's email address. However, this identity is only linked to a user account when the user accepts the invitation by going through SAML SSO.

The returned list of external identities can include an entry for a `null` user. These are unlinked SAML identities that are created when a user goes through the following Single Sign-On (SSO) process but does not sign in to their GitHub account after completing SSO:

1. The user is granted access by the IdP and is not a member of the GitHub enterprise.

1. The user attempts to access the GitHub enterprise and initiates the SAML SSO process, and is not currently signed in to their GitHub account.

1. After successfully authenticating with the SAML SSO IdP, the</br>
<br>Method: Get</br>
<br>OperationID: enterprise-admin/list-provisioned-identities-enterprise</br>
<br>EndPoint:</br>
<br>/scim/v2/enterprises/{enterprise}/Users</br>
