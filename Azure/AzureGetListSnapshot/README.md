GET LIST SNAPSHOT ACTIVITIES

GET LIST INFORMATION OF SNAPSHOT ON AZURE.

This Activities requires Microsoft.IdentityModel.Clients.ActiveDirectory.dll, System.Net.Http.dll, Newtonsoft.Json.dll

OUTPUT Success/Failure	

DOCUMENT: https://docs.microsoft.com/en-us/rest/api/compute/snapshots/list

MANDATORY FIELDS WHEN GET LIST SNAPSHOT:

a. TenantID: How to get: Bellow

b. ClientID: How to get: Bellow

c. ClientSecret: How to get: Bellow

d. SubscriptionID: How to get: Bellow

-------------------------------------------

How to find information of required fields to GET LIST Snapshot on Azure?

-- Answer:
 
1. TenantID, ClientID, ClientSecret: In the start interface after logging into Azure click: Azure Active Directory -> App registrations -> New registration (If not) -> (Name of registrations). 
After performing the above steps you will see Application (client) ID, Directory (tenant) ID, Object ID.
Inside (Name of registration) select: Certificates & secrets -> New client secret to get ClientSecret.

2. SubscriptionID: If you do not have "Resource Group", please create an item in the Resource Group section in the interface. Clicking on the newly created item will display the SubscriptionID.
