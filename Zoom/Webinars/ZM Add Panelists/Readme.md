<br>#     Zoom</br>
<br>Add Panelists</br>
<br>Panelists in a Webinar can view and send video, screen share, annotate, etc and do much more compared to attendees in a webinar.Use this API to [add panelists](https://support.zoom.us/hc/en-us/articles/115005657826-Inviting-Panelists-to-a-Webinar#h_7550d59e-23f5-4703-9e22-e76bded1ed70) to a scheduled webinar.
**Scopes:** `webinar:write:admin` `webinar:write` 


**Prerequisites:**
* Pro or a higher plan with [Webinar Add-on](https://zoom.us/webinar). </br>
<br>Method: Post</br>
<br>OperationID: webinarPanelistCreate</br>
<br>EndPoint:</br>
<br>/webinars/{webinarId}/panelists</br>
<br>Usage: panelists[]</br>
<br>[{
  "name": "%name%",
  "email": "%email%"
}]</br>
