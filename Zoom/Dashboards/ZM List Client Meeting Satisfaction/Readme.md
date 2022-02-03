<br>#     Zoom</br>
<br>List Client Meeting Satisfaction </br>
<br>If the [End of Meeting Feedback Survey](https://support.zoom.us/hc/en-us/articles/115005855266) option is enabled, attendees will be prompted with a survey window where they can tap either the **Thumbs Up** or **Thumbs Down** button that indicates their Zoom meeting experience. With this API, you can get information on the attendees' meeting satisfaction. Specify a monthly date range for the query using the from and to query parameters. The month should fall within the last six months.

To get information on the survey results with negative experiences (indicated by **Thumbs Down**), use the [Get Zoom Meetings Client Feedback API](https://marketplace.zoom.us/docs/api-reference/zoom-api/dashboards/dashboardclientfeedbackdetail).
**Scopes:** `dashboard:read:admin` </br>
<br>Method: Get</br>
<br>OperationID: listMeetingSatisfaction</br>
<br>EndPoint:</br>
<br>/metrics/client/satisfaction</br>
