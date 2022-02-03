## OfficeUserDelete - Activity to delete a user in Azure AD for Office365.

##### DLL's to reference
System.Net.Http.dll


### One of the below fields needs to be provided to delete a user:
**userEmail**   - 		The user principal name (UPN) of the user.
                        The UPN is an Internet-style login name for the user based on the Internet standard
                        RFC 822. By convention, this should map to the user's email name. The general
                        format is alias@domain, where domain must be present in the tenant’s collection
                        of verified domains. This property is required when a user is created. The verified
                        domains for the tenant can be accessed from the verifiedDomains property of organization.                  
