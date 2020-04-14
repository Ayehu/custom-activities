## NetAppRemoveIgroupInitiator - Remove initiators from an initiator group.

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
**Vserver**				- Specifies the Vserver.  
**IgroupName**			- Specifies the initiator group from which you want to remove an initiator.  
**Force**				- Forcibly removes an initiator and any associated LUN maps.