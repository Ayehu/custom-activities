#     Zoom


Update a Group's Settings

Update settings for a [group](https://support.zoom.us/hc/en-us/articles/204519819-Group-Management-).Note: The `force_pmi_jbh_password` field under meeting settings is planned to be deprecated on September 22, 2019. This field will be replaced by another field that will provide the same functionality.
**Prerequisite**: Pro, Business, or Education account 
**Scopes**: `group:write:admin`
 

Method: Patch

OperationID: updateGroupSettings

EndPoint:

/groups/{groupId}/settings
