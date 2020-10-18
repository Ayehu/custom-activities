<br>#     Zoom</br>
<br>Add a Webinar Registrant</br>
<br>Zoom users with a [Webinar Plan](https://zoom.us/webinar) have access to creating and managing Webinars. Webinar allows a host to broadcast a Zoom meeting to up to 10,000 attendees. Scheduling a [Webinar with registration](https://support.zoom.us/hc/en-us/articles/204619915-Scheduling-a-Webinar-with-Registration) requires your registrants to complete a brief form before receiving the link to join the Webinar.Use this API to create and submit the registration of a user for a webinar.
**Scopes:** `webinar:write:admin` `webinar:write`
 
**Prerequisites:**
* Pro or higher plan with a Webinar Add-on.</br>
<br>Method: Post</br>
<br>OperationID: webinarRegistrantCreate</br>
<br>EndPoint:</br>
<br>/webinars/{webinarId}/registrants</br>
<br>Usage: custom_questions[]</br>
<br>[{
  "title": "%title%",
  "value": "%value%"
}]</br>
