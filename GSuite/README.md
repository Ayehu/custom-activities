# GSuite Activities

To run GSuite activities you need to:  
1. Set-up a new Service Account following this [tutorial](https://docs.bmc.com/docs/PATROL4GoogleCloudPlatform/10/creating-a-service-account-key-in-the-google-cloud-platform-project-799095477.html);  
2. Delegate domain-wide authority to your service account following this [tutorial](https://developers.google.com/admin-sdk/directory/v1/guides/delegation)  
3. And allow your gSuite account to give access to your Service Account access the users' data. Follow the same tutorial from item 2. The necessary scope is: https://www.googleapis.com/auth/admin.directory.group and https://www.googleapis.com/auth/admin.directory.user.  
