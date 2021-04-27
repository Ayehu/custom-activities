
## AzureADGroupMemberAdd - Activity to add a member to Azure AD security group.

##### DLL's to reference
System.Net.Http.dll </br>


You'd need to store the API specific information from the portal. </br>
ApplicationId </br>
TenantId </br>
Secret

These fields should be sent when calling the API.

### The below fields needs to be provided to add a group member: 

**Access token**      - Access token

**GroupId**           - The ID of the group to add the member.

**UserId**			- User's ID to add to the group
