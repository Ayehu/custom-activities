## NetAppAddIgroupInitiator - Add initiators to an initiator group.

##### DLL's to reference
NetApp.dll  

You can find the dll at this repository in the NetApp folder.  

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;  

### Mandatory fields:

**IP**					- IP  
**Username**			- Username to access API  
**Password**			- Password to acces API  
**Vserver**				- VServer (SVM)  which contains the Igroup  
**IgroupName**			- Specifies the initiator group to which you want to add a new initiator  
**Initiator**			- Specifies the initiator that you want to add. You can specify the WWPN, IQN, or alias of the initiator  
**Force**				- Force add