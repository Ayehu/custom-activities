BOX GET FILE ACTIVITIES

DOWNLOAD FILE IN BOX.

This Activities requires Box.V2.dll
https://www.nuget.org/packages/Box.V2/3.19.0

BOX DELETE FILE – OUTPUT 
Success/Failure

MANDATORY FIELDS WHEN DOWNLOAD A FILE:

a. File ID: ID of the File on the Box.
b. File Path: The address contains the file on your device after downloading it.
c. User ID: ID of the User on the Box. 
d. Client ID: Credentials for using OAuth 2.0.
e. Client Secret: Credentials for using OAuth 2.0.
f. ENTERPRISE_ID: is App Info, ID of the Enterprise in "Update general information about your app." section.
g. JWT Password Key: RSA keypair to sign and authenticate the JWT request made by your app or upload your own public key.
h. JWT Public Key ID: RSA keypair to sign and authenticate the JWT request made by your app or upload your own public key.
i. Private Key: RSA keypair to sign and authenticate the JWT request made by your app or upload your own public key.

-------------------------------------------

How to get information of FIELDS?

-- Answer:
 
+ Sign In to Your Account: https://account.box.com/login?redirect_url=%2Fdevelopers%2Fservices
+ Click to your app:
Inside the "General" category there are information such as: User ID, Enterprise ID
Inside the "Configuration" category -> Find "App Settings" there are information such as: Client ID, Client Secret, JWT Password Key, JWT Public Key ID, Private Key.
