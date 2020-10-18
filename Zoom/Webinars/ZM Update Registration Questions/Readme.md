<br>#     Zoom</br>
<br>Update Registration Questions</br>
<br>Scheduling a [Webinar with registration](https://support.zoom.us/hc/en-us/articles/204619915-Scheduling-a-Webinar-with-Registration) requires your registrants to complete a brief form with fields and questions before they can receive the link to join the Webinar.Use this API to update registration questions and fields of a scheduled Webinar that are to be answered by users while registering for a Webinar.
**Prerequisites:**  
* Pro or higher plan with a Webinar Add-on.
* Registration option for Webinar should be set as required to use this API. 
**Scopes:** `webinar:write:admin` `webinar:write`
 

</br>
<br>Method: Patch</br>
<br>OperationID: webinarRegistrantQuestionUpdate</br>
<br>EndPoint:</br>
<br>/webinars/{webinarId}/registrants/questions</br>
<br>Usage: questions[]</br>
<br>[{
  "field_name": "%field_name%",
  "required": "%required%"
}]</br>
<br>Usage: custom_questions[]</br>
<br>[{
  "title": "%title%",
  "type": "%type%",
  "required": "%custom_questions_required%"
}]</br>
