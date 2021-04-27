
## AzureADGroupMemberRemove - Activity to remove a member from Azure AD security group.

##### DLL's to reference
System.Net.Http.dll<br/>


You'd need to store the API specific information from the portal.<br/>
ApplicationId<br/>
TenantId<br/>
Secret<br/>

These fields should be sent when calling the API.

### The below fields needs to be provided to remove a member from group:
**UserId**       - The Group ID to remove the member

**UserId**				- Member to remove from the group (It's either User Id or Role Id)
