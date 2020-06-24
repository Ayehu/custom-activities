BOX GET FILE ACTIVITIES
<br><br>
DOWNLOAD FILE IN BOX.
<br><br>
This Activities requires Box.V2.dll
<br>
https://www.nuget.org/packages/Box.V2/3.19.0
<br><br>
BOX DELETE FILE – OUTPUT
<br>
Success/Failure
<br><br>
MANDATORY FIELDS WHEN DOWNLOAD A FILE:
<br><br>
a. File ID: ID of the File on the Box.
<br>
b. File Path: The address contains the file on your device after downloading it.
<br>
c. User ID: ID of the User on the Box. 
<br>
d. Client ID: Credentials for using OAuth 2.0.
<br>
e. Client Secret: Credentials for using OAuth 2.0.
<br>
f. ENTERPRISE_ID: is App Info, ID of the Enterprise in "Update general information about your app." section.
<br>
g. JWT Password Key: RSA keypair to sign and authenticate the JWT request made by your app or upload your own public key.
<br>
h. JWT Public Key ID: RSA keypair to sign and authenticate the JWT request made by your app or upload your own public key.
<br>
i. Private Key: RSA keypair to sign and authenticate the JWT request made by your app or upload your own public key.
<br><br>
-------------------------------------------
<br><br>
How to get information of FIELDS?
<br><br>
-- Answer:
 <br><br>
+ Sign In to Your Account: https://account.box.com/login?redirect_url=%2Fdevelopers%2Fservices
<br>
+ Click to your app:
<br>
Inside the "General" category there are information such as: User ID, Enterprise ID
<br>
Inside the "Configuration" category -> Find "App Settings" there are information such as: Client ID, Client Secret, JWT Password Key, JWT Public Key ID, Private Key.
