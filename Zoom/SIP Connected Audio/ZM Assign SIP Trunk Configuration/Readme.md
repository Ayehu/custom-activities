#     Zoom


Assign SIP Trunk Configuration

With SIP-connected audio, Zoom establishes a SIP trunk (a network connection specifically designed to make and deliver phone calls) over a direct and private connection between the customerâ€™s network and the Zoom cloud. Meeting participants that dial into a meeting or have the meeting call them, and are On-Net from the perspective of the customers' IP telephony network, will be connected over this trunk rather than over the PSTN.  Using this API, a Master Account owner can copy the SIP Connected Audio configurations applied on the Master Account and enable those configurations on a Sub Account. The owner can also disable the configuration in the Sub Account where it was previously enabled. 
**Prerequisites:**
* Pro or a higher account with SIP Connected Audio plan enabled.
* Master Account Owner
**Scopes:** `sip_trunk:master` 


Method: Patch

OperationID: assignSIPConfig

EndPoint:

/accounts/{accountId}/sip_trunk/settings
