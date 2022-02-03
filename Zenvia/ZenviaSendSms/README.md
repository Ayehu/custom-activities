All input fields are either self-explanatory or explained in the root README file (<a href="https://github.com/fabricio-ssilva-capgemini/custom-activities/blob/master/Zenvia/ZenviaSendSms/README.md">https://github.com/fabricio-ssilva-capgemini/custom-activities/blob/master/Zenvia/ZenviaSendSms/README.md</a>).
<br><br>
See below for an example of the activity's configuration:
<br><br>
<img src="https://github.com/fabricio-ssilva-capgemini/custom-activities/blob/master/Zenvia/ZenviaSendSms/Sample.png?raw=true">
<br>
<b>Parameters</b>:
<br>
<b>Endpoint URL:</b> https://api-rest.zenvia.com/services/send-sms, it is the oficial endpoint to the API, DO NOT CHANGE.
<br>
<b>Username</b>:
<br>
<b>Password</b>: 
<br>
<b>From (Optional):</b> An initial text to message, It is used to pass a remetent name
<br>
<b>To</b>: The phone number, pattern Country code + Area + phone number, only digits. Example: 5521991103472
<br>
<b>Schedule (Optional):</b> The SMS can be scheduled, use the pattern 2020-12-12T19:00:00.
<br>
<b>Message:</b> 
<br>
<b>id (Optional):</b> The unique number to identify the message into Zenvia system, the id is recorded for 1 or 2 days, only one message can use the id. An error is returned if duplicate id exist.
<br>
<b>aggregateid (Optional):</b> The unique number to group messages
<br>
<b>Flashsms:</b> Check in this flag to send a flash message.
<br>
<b>Callback Options:</b> Used to use the callback function, see the documentation.
<br>
<br>

To more information access https://zenviasms.docs.apiary.io/
