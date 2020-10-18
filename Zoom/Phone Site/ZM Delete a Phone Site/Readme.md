<br>#     Zoom</br>
<br>Delete a Phone Site</br>
<br>Sites allow you to organize Zoom Phone users in your organization. Use this API to delete a specific [site](https://support.zoom.us/hc/en-us/articles/360020809672) in a Zoom account. To delete a site, in the query parameter, you must provide the Site ID of another site where the assets of current site (users, numbers and phones) can be transferred to.  You cannot use this API to delete the main site.

**Prerequisites:** 
* Account must have a Pro or a higher plan with Zoom Phone license. 
* [Multiple Sites](https://support.zoom.us/hc/en-us/articles/360020809672-Managing-Multiple-Sites) must be enabled.
**Scope:** `phone:write:admin`
 

</br>
<br>Method: Delete</br>
<br>OperationID: deletePhoneSite</br>
<br>EndPoint:</br>
<br>/phone/sites/{siteId}</br>
