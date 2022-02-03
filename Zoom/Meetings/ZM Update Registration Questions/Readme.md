<br>#     Zoom</br>
<br>Update Registration Questions</br>
<br>Update registration questions that will be displayed to users while [registering for a meeeting](https://support.zoom.us/hc/en-us/articles/211579443-Registration-for-Meetings).
**Scopes:** `meeting:write`, `meeting:write:admin`
 

</br>
<br>Method: Patch</br>
<br>OperationID: meetingRegistrantQuestionUpdate</br>
<br>EndPoint:</br>
<br>/meetings/{meetingId}/registrants/questions</br>
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
