<br>#     Zoom</br>
<br>Update a Group Member</br>
<br>If a user is a member in multiple groups, you can [set a primary group](https://support.zoom.us/hc/en-us/articles/204519819-Group-Management-#h_d07c7dcd-4fd8-485a-b5fe-a322e8d21c09) for the user. The group member will use the primary group's settings by default. However, if settings are locked in other groups, those settings will continue to be locked for that user. By default, the primary group is the first group that user is added to.
Use this API to perform either of the following tasks:
* Simultaneously remove a member from one group and move the member to a different group.
* Set a primary group for the user
**Prerequisites:** 
* Pro or higher account **Scopes:** `group:write:admin`
</br>
<br>Method: Patch</br>
<br>OperationID: updateAGroupMember</br>
<br>EndPoint:</br>
<br>/groups/{groupId}/members/{memberId}</br>
