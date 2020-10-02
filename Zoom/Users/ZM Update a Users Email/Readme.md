#     Zoom


Update a User's Email

Change a user's [email address](https://support.zoom.us/hc/en-us/articles/201362563-How-Do-I-Change-the-Email-on-My-Account-) on a Zoom account that has managed domain set up.If the Zoom Account in which the user belongs, has multiple [managed domains](https://support.zoom.us/hc/en-us/articles/203395207-What-is-Managed-Domain-), the email to be updated must match one of the managed domains.
**Scopes:** `user:write:admin` `user:write`

**Prerequisite:**
* Managed domain must be enabled in the account.
* The new email address should not already exist in Zoom.

Method: Put

OperationID: userEmailUpdate

EndPoint:

/users/{userId}/email
