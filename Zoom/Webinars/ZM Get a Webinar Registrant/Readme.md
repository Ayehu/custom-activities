#     Zoom


Get a Webinar Registrant

Zoom users with a [Webinar Plan](https://zoom.us/webinar) have access to creating and managing Webinars. Webinar allows a host to broadcast a Zoom meeting to up to 10,000 attendees. Scheduling a [Webinar with registration](https://support.zoom.us/hc/en-us/articles/204619915-Scheduling-a-Webinar-with-Registration) requires your registrants to complete a brief form before receiving the link to join the Webinar.Use this API to get details on a specific user who has registered for the Webinar.
**Scopes:** `webinar:read:admin` `webinar:read`
 
**Prerequisites:**
* The account must have a Webinar plan.

Method: Get

OperationID: webinarRegistrantGet

EndPoint:

/webinars/{webinarId}/registrants/{registrantId}
