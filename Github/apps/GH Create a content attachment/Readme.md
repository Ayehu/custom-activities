<br>#     Github</br>
<br>Create a content attachment</br>
<br>Creates an attachment under a content reference URL in the body or comment of an issue or pull request. Use the `id` of the content reference from the [`content_reference` event](https://developer.github.com/webhooks/event-payloads/#content_reference) to create an attachment.

The app must create a content attachment within six hours of the content reference URL being posted. See "[Using content attachments](https://developer.github.com/apps/using-content-attachments/)" for details about content attachments.

You must use an [installation access token](https://developer.github.com/apps/building-github-apps/authenticating-with-github-apps/#authenticating-as-an-installation) to access this endpoint.</br>
<br>Method: Post</br>
<br>OperationID: apps/create-content-attachment</br>
<br>EndPoint:</br>
<br>/content_references/{content_reference_id}/attachments</br>
