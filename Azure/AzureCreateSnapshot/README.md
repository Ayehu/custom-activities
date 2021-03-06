CREATE SNAPSHOT ACTIVITIES

CREATE A SNAPSHOT ON AZURE.

This Activities requires Microsoft.IdentityModel.Clients.ActiveDirectory.dll, System.Net.Http.dll

OUTPUT Success/Failure

DOCUMENT: https://docs.microsoft.com/en-us/rest/api/compute/snapshots/createorupdate

MANDATORY FIELDS WHEN CREATE A SNAPSHOT:

a. TenantID: How to get: Bellow

b. ClientID: How to get: Bellow

c. ClientSecret: How to get: Bellow

d. Body: Read this document part Requests Body.

f. Resource Group Name: Name of item Resource Group in FAVORITES

e. SubscriptionID: How to get: Bellow

g. Snapshot Name: Name of snapshot optional.

-------------------------------------------

How to find information of required fields to CREATE a Snapshot on Azure?

-- Answer:
 
1. TenantID, ClientID, ClientSecret: In the start interface after logging into Azure click: Azure Active Directory -> App registrations -> New registration (If not) -> (Name of registrations). 
After performing the above steps you will see Application (client) ID, Directory (tenant) ID, Object ID.
Inside (Name of registration) select: Certificates & secrets -> New client secret to get ClientSecret.

2. SubscriptionID: If you do not have "Resource Group", please create an item in the Resource Group section in the interface. Clicking on the newly created item will display the SubscriptionID.

---------------------------------------
JSON Body Sample:

![image](https://user-images.githubusercontent.com/58769447/111696706-4b248800-883d-11eb-8349-3b115d48fb82.png)
{
  "location": "East US",
  "properties": {
    "creationData": {
      "createOption": "Copy",
      "sourceResourceId": "/subscriptions/df4f6097-8fe7-4ff6-a847-7deec5a659d9/resourceGroups/ProfessionalServices/providers/Microsoft.Compute/disks/testjack",
    }
  }
}
