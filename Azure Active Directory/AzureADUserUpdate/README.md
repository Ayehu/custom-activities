## AzureADUpdateUser - Activity to update a user in Azure AD.

##### DLL's to reference

System.Net.Http.dll </br>


You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret


### The below fields needs to be provided to apply license:

**Access token**      - Access token

**userEmail**	    - User email that identifies the account (Required) 	                    

**firstName**		- User FirstName to update (Not required)

**lastName**		- User LastName to update (Not required)

**password**		- New password. (Not required). It must be a strong password.  At least 8 to 64 characters. It requires 3 out of 4 of lowercase, uppercase, numbers, or symbols.

**Important!** - To be able to change the password, the AzureAD application needs to be part of the group 'Password administrators' under Azure Active Directory -> Roles and administrators.
