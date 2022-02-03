<br>#     Zoom</br>
<br>Change the Assigned Parent Location</br>
<br>An account owner of a Zoom account can establish a [Zoom Rooms Location Hierarchy](https://support.zoom.us/hc/en-us/articles/115000342983-Zoom-Rooms-Location-Hierarchy) to better organize Zoom Rooms spread accross various location. The location can be structured in a hierarchy with Country being the top-level location, followed by city, campus, building, and floor. The location in the lower level in the hierarchy is considered as a child of the location that is a level above in the hierarchy. Use this API to change the parent location of a child location.  For instance, if the location hierarchy is structured in a way where there are two campuses (Campus 1, and Campus 2) in a City and Campus 1 consists of a building named Building 1 with a floor where Zoom Rooms are located, and you would like to rearrange the structure so that Building 1 along with its child locations (floor and Zoom Rooms) are relocated directly under Campus 2 instead of Campus 1, you must provide the location ID of Building 1 in the path parameter of this request and the location ID of Campus 2 as the value of `parent_location_id` in the  request body.
**Prerequisite:**
* Account owner or admin permission
* Zoom Rooms version 4.0 or higher
**Scopes:** `room:write:admin` /n</br>
<br>Method: Put</br>
<br>OperationID: changeParentLocation</br>
<br>EndPoint:</br>
<br>/rooms/locations/{locationId}/location</br>
