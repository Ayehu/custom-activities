#     Zoom


Get Zoom Room Location Profile 

Each location type of the [Zoom Rooms location hierarchy](https://support.zoom.us/hc/en-us/articles/115000342983-Zoom-Rooms-Location-Hierarchy) has a profile page that includes information such as name of the location, address, support email, etc. Use this API to retrieve information about a specific Zoom Rooms location type such as information about the city where the Zoom Rooms is located.

**Prerequisite:**
* Account owner or admin permission
* Zoom Rooms version 4.0 or higher
**Scopes:** `room:read:admin` 


Method: Get

OperationID: getZRLocationProfile

EndPoint:

/rooms/locations/{locationId}
