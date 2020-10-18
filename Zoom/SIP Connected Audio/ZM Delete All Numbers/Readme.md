<br>#     Zoom</br>
<br>Delete All Numbers</br>
<br>With SIP-connected audio, Zoom establishes a SIP trunk (a network connection specifically designed to make and deliver phone calls) over a direct and private connection between the customerâ€™s network and the Zoom cloud. Meeting participants that dial into a meeting or have the meeting call them, and are On-Net from the perspective of the customers' IP telephony network, will be connected over this trunk rather than over the PSTN. Use this API to delete all internal numbers assigned to a Sub Account.
**Prerequisites:**

* Pro or a higher account with SIP Connected Audio plan enabled.
* The account must be a Master Account
**Scopes:** `sip_trunk:master` </br>
<br>Method: Delete</br>
<br>OperationID: deleteAllSipNumbers</br>
<br>EndPoint:</br>
<br>/accounts/{accountId}/sip_trunk/numbers</br>
