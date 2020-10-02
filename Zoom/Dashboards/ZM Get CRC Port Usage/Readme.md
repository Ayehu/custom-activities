#     Zoom


Get CRC Port Usage

A Cloud Room Connector allows H.323/SIP endpoints to connect to a Zoom meeting. 

Use this API to get the hour by hour CRC Port usage for a specified period of time. We will provide the report for a maximum of one month. For example, if "from" is set to "2017-08-05" and "to" is set to "2017-10-10", we will adjust "from" to "2017-09-10".
**Prerequisites:**
* Business, Education or API Plan.
* Room Connector must be enabled on the account.
**Scopes:** `dashboard_crc:read:admin` 

Method: Get

OperationID: dashboardCRC

EndPoint:

/metrics/crc
