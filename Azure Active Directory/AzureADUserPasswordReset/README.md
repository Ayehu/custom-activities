
## AzureADUserPasswordReset - Activity to reset user password in Azure AD.

##### DLL's to reference
System.Net.Http.dll </br>

You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret

These fields should be sent when calling the API.

**Access token**      - Access token

**user ID**	    - User ID that identifies the account (Required) 	                    

**New password**		- New password. It must be a strong password.  At least 8 to 64 characters. It requires 3 out of 4 of lowercase, uppercase, numbers, or symbols.

**Important!** - To be able to change the password, the AzureAD application needs to be part of the group 'Password administrators' under Azure Active Directory -> Roles and administrators.
