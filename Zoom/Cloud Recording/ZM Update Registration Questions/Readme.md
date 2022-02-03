<br>#     Zoom</br>
<br>Update Registration Questions</br>
<br>For [on-demand](https://support.zoom.us/hc/en-us/articles/360000488283-On-demand-Recordings) meeting recordings, you can include fields with questions that will be shown to registrants when they register to view the recording.

Use this API to update registration questions that are to be answered by users while registering to view a recording.
**Scopes:** `recording:write:admin`, `recording:write` 
</br>
<br>Method: Patch</br>
<br>OperationID: recordingRegistrantQuestionUpdate</br>
<br>EndPoint:</br>
<br>/meetings/{meetingId}/recordings/registrants/questions</br>
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
