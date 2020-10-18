<br>#     Zoom</br>
<br>Change a Zoom Room's Location</br>
<br>An account owner of a Zoom account can establish a [Zoom Rooms Location Hierarchy](https://support.zoom.us/hc/en-us/articles/115000342983-Zoom-Rooms-Location-Hierarchy) to better organize Zoom Rooms spread accress various location. The location can be structured in a hierarchy with Country being the top-level location, followed by city, campus, building, and floor. Use this API to assign a new location for a Zoom Room. Note that the Zoom Room can be assigned only to the lowest level location available in the hierarchy.
**Prerequisite:**
* Account owner or admin permission
* Zoom Rooms version 4.0 or higher
**Scopes:** `room:write:admin` </br>
<br>Method: Put</br>
<br>OperationID: changeZRLocation</br>
<br>EndPoint:</br>
<br>/rooms/{roomId}/location</br>
