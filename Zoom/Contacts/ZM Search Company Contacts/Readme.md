#     Zoom


Search Company Contacts

A user under an organization's Zoom account has internal users listed under Company Contacts in the Zoom Client. Use this API to search users that are in the company contacts of a Zoom account. Using the `search_key` query parameter, provide either first name, last name or the email address of the user that you would like to search for. Optionally, set `query_presence_status` to `true` in order to include the presence status of a contact. 

**Scopes:** `contact:read:admin`, `contact:read`
 

Method: Get

OperationID: searchCompanyContacts

EndPoint:

/contacts
