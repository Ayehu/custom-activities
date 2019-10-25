## AzureADCreateUser - Activity to create a new user in Azure AD for Office365.

Remark - The portal needs to be configured first. https://portal.azure.com
Under 'Azure Active Directory' add a new organization. Follow the steps to register the application.

##### DLL's to reference
Microsoft.Graph.dll
Microsoft.Graph.Auth.dll
Microsoft.Graph.Core.dll
Microsoft.Identity.Client.dll

##### Libraries to import
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;

You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret

These fields should be sent when calling the API.

### Mandatory fields when creating a user:
**UserPrincipalName** - The user principal name (UPN) of the user.
                        The UPN is an Internet-style login name for the user based on the Internet standard
                        RFC 822. By convention, this should map to the user's email name. The general
                        format is alias@domain, where domain must be present in the tenant’s collection
                        of verified domains. This property is required when a user is created. The verified
                        domains for the tenant can be accessed from the verifiedDomains property of organization.
                    
**GivenName** -         First Name of the user

**Surname** -           Last Name of the user

**DisplayName** -       The name displayed in the address book for the user.
                        This is usually the combination of the user's first name, middle initial and last name
                    
**MailNickname** -      The mail alias for the user

**AccountEnabled** -    Creates an Enabled/Disabled account

**PasswordProfile** -   Specifies the password profile for the user. The profile contains the user’s password.
                        The password in the profile must satisfy minimum requirements as specified by the passwordPolicies property
