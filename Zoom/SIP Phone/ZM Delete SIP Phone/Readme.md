#     Zoom


Delete SIP Phone

Zoomâ€™s Phone System Integration (PSI), also referred as SIP phones, enables an organization to leverage the Zoom client to complete a softphone registration to supported premise based PBX system. End users will have the ability to have softphone functionality within a single client while maintaining a comparable interface to Zoom Phone. Use this API to delete a specific SIP phone on a Zoom account.
**Prerequisites**:
* Currently only supported on Cisco and Avaya PBX systems. 
* User must enable SIP Phone Integration by contacting the [Sales](https://zoom.us/contactsales) team. **Scope:** `sip_phone:read:admin`
 

Method: Delete

OperationID: deleteSIPPhone

EndPoint:

/sip_phones/{phoneId}
