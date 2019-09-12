GET FILE ACTIVITIES

DOWNLOAD A FILE FROM AMAZON S3.

This Activities requires AWSSDK.Core.dll, AWSSDK.S3.dll.
https://aws.amazon.com/sdk-for-net/?nc1=h_ls

Output Success/Failure

MANDATORY FIELDS WHEN DOWNLOAD A FILE:

a. Access Key: How to get: Bellow
b. Secrey Key: How to get: Bellow
c. Bucket: Bucket is the directory that you want to get the file when download.
d. File Path: File Path is the address of the file to download on your device.
e. Key: Name of file in Bucket.

-------------------------------------------

How to find AWS Access Key and Secret Access Key?

-- Answer:
 
In order for MigrationWiz to access your Amazon Web Services (AWS) account automatically, the Access Key and the Secret Access Key are required. The Access Key and the Secret Access Key are not your standard user name and password, but are special tokens that allow our services to communicate with your AWS account by making secure REST or Query protocol requests to the AWS service API.

To find your Access Key and Secret Access Key:

1. Log in to your AWS Management Console.
2. Click on your user name at the top right of the page.
3. Click on the Security Credentials link from the drop-down menu.
4. Find the Access Credentials section, and copy the latest Access Key ID.
5. Click on the Show link in the same row, and copy the Secret Access Key.
