DELETE SNAPSHOT ACTIVITIES

DELETE A SNAPSHOT ON AZURE.

This Activities requires Microsoft.IdentityModel.Clients.ActiveDirectory.dll, System.Net.Http.dll

OUTPUT Success/Failure

DOCUMENT: https://docs.microsoft.com/en-us/rest/api/compute/snapshots/delete

MANDATORY FIELDS WHEN DELETE A SNAPSHOT:

a. TenantID: How to get: Bellow

b. ClientID: How to get: Bellow

c. ClientSecret: How to get: Bellow

d. Resource Group Name: Name of item Resource Group in FAVORITES

e. SubscriptionID: How to get: Bellow

f. Snapshot Name: Name of snapshot optional.

-------------------------------------------

How to find information of required fields to delete a Snapshot on Azure?

-- Answer:
 
1. TenantID, ClientID, ClientSecret: In the start interface after logging into Azure click: Azure Active Directory -> App registrations -> New registration (If not) -> (Name of registrations). 
After performing the above steps you will see Application (client) ID, Directory (tenant) ID, Object ID.
Inside (Name of registration) select: Certificates & secrets -> New client secret to get ClientSecret.

2. SubscriptionID: If you do not have "Resource Group", please create an item in the Resource Group section in the interface. Clicking on the newly created item will display the SubscriptionID.
