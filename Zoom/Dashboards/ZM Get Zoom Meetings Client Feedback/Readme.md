<br>#     Zoom</br>
<br>Get Zoom Meetings Client Feedback</br>
<br>Retrieve detailed information on a [Zoom meetings client feedback](https://support.zoom.us/hc/en-us/articles/115005855266-End-of-Meeting-Feedback-Survey#h_e30d552b-6d8e-4e0a-a588-9ca8180c4dbf).  You can specify a monthly date range for the dashboard data using the `from` and `to` query parameters. The month should fall within the last six months.

**Prerequisites:**
* Business or higher account
* [Feedback to Zoom](https://support.zoom.us/hc/en-us/articles/115005838023) enabled.

**Scope:** `dashboard_home:read:admin` 

`</br>
<br>Method: Get</br>
<br>OperationID: dashboardClientFeedbackDetail</br>
<br>EndPoint:</br>
<br>/metrics/client/feedback/{feedbackId}</br>
