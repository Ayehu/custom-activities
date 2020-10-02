#     Zoom


Update Registration Questions

Scheduling a [Webinar with registration](https://support.zoom.us/hc/en-us/articles/204619915-Scheduling-a-Webinar-with-Registration) requires your registrants to complete a brief form with fields and questions before they can receive the link to join the Webinar.Use this API to update registration questions and fields of a scheduled Webinar that are to be answered by users while registering for a Webinar.
**Prerequisites:**  
* Pro or higher plan with a Webinar Add-on.
* Registration option for Webinar should be set as required to use this API. 
**Scopes:** `webinar:write:admin` `webinar:write`
 



Method: Patch

OperationID: webinarRegistrantQuestionUpdate

EndPoint:

/webinars/{webinarId}/registrants/questions
