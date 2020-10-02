#     Zoom


Get Webinar Tracking Sources

[Webinar Registration Tracking Sources](https://support.zoom.us/hc/en-us/articles/360000315683-Webinar-Registration-Source-Tracking) allow you to see where your registrants are coming from if you share the webinar registration page in multiple platforms. You can then use the source tracking to see the number of registrants generated from each platform. Use this API to list information on all the tracking sources of a Webinar.
**Scopes:** `webinar:read:admin`, `webinar:read`
 
**Prerequisites**:
* [Webinar license](https://zoom.us/webinar).
* Registration must be required for the Webinar.


Method: Get

OperationID: getTrackingSources

EndPoint:

/webinars/{webinarId}/tracking_sources
