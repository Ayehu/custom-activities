#     Zoom


Change Call Queue Manager

A call queue manager has the privileges to maanage the call queue's voicemail inbox and recordings, change all call queue settings and call queue policy settings. Use this API to to set another phone user as the [call queue manager](https://support.zoom.us/hc/en-us/articles/360021524831-Managing-Call-Queues#h_db06854b-e6a3-4afe-ba15-baf58f31f90c).
**Prerequisites:**
* Pro or higher account plan.
* Account owner or admin permissions
* Zoom Phone license
**Scopes:** `phone:write:admin` 




Method: Put

OperationID: changeCallQueueManager

EndPoint:

/phone/call_queues/{callQueueId}/manager
