# Google Cloud Activities

Activities repository to Google Cloud Platform.  

To run Google Cloud activities you need to set-up a new Service Account at https://cloud.google.com. Check this [tutorial](https://docs.bmc.com/docs/PATROL4GoogleCloudPlatform/10/creating-a-service-account-key-in-the-google-cloud-platform-project-799095477.html).  

All necessary DLLs can be found in the DLL.zip file in the root directory.

Note that the "Private Key" field in each activity must be formatted as follows:
<pre>
-----BEGIN PRIVATE KEY-----
MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC4Af06sZrAVY8x
...............................................................
...............................................................
...............................................................
...............................................................
PpY0OdsZso48XG98qT4j89VBfV0cFMVKpED7mfz3YC8w+LA1vy4HZfYd97bW6CX+
HMQtA68pP+IIqzqH0n4vBJU=
-----END PRIVATE KEY-----
</pre>
