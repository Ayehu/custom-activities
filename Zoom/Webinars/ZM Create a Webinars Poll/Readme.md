<br>#     Zoom</br>
<br>Create a Webinar's Poll</br>
<br>Create a [poll](https://support.zoom.us/hc/en-us/articles/203749865-Polling-for-Webinars) for a webinar.
**Scopes:** `webinar:write:admin` `webinar:write`
 

</br>
<br>Method: Post</br>
<br>OperationID: webinarPollCreate</br>
<br>EndPoint:</br>
<br>/webinars/{webinarId}/polls</br>
<br>Usage: questions[]</br>
<br>[{
  "name": "%name%",
  "type": "%type%"
}]</br>
