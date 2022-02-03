<br>#     Zoom</br>
<br>Create a Meeting</br>
<br>[Create a meeting](https://support.zoom.us/hc/en-us/articles/201362413-Scheduling-meetings) for a user. This API has a daily rate limit of 100 requests per day. Therefore, only 100 **Create a Meeting** API requests are permitted within a 24 hour window for a user.

The start_url of a meeting is a URL using which a host or an alternative host can start a meeting. The expiration time for the start_url field is two hours for all regular users. 
	
For users created using the custCreate option via the [Create Users](https://marketplace.zoom.us/docs/api-reference/zoom-api/users/usercreate) API, the expiration time of the start_url field is 90 days.
	
For security reasons, the recommended way to retrieve the updated value for the start_url field programmatically (after expiry) is by calling the [Retrieve a Meeting API](https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meeting) and referring to the value of the start_url field in the response.
Scopes: `meeting:write:admin` `meeting:write`</br>
<br>Method: Post</br>
<br>OperationID: meetingCreate</br>
<br>EndPoint:</br>
<br>/users/{userId}/meetings</br>
<br>Usage: tracking_fields[]</br>
<br>[{
  "field": "%field%",
  "value": "%value%"
}]</br>
