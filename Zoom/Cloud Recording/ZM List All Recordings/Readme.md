<br>#     Zoom</br>
<br>List All Recordings</br>
<br>When a user records a meeting by choosing the **Record to the Cloud** option, the video, audio, and chat text are recorded in the Zoom cloud. 

Use this API to list all [Cloud recordings](https://support.zoom.us/hc/en-us/articles/203741855-Cloud-Recording) of a user.
> To access a password protected cloud recording, add an "access_token" parameter to the download URL and provide [JWT](https://marketplace.zoom.us/docs/guides/getting-started/app-types/create-jwt-app) as the value of the "access_token".


**Scopes:** `recording:read:admin` `recording:read`  
 
**Prerequisites:** 
* Pro or a higher plan.
* Cloud Recording must be enabled on the user's account.</br>
<br>Method: Get</br>
<br>OperationID: recordingsList</br>
<br>EndPoint:</br>
<br>/users/{userId}/recordings</br>
