## NetAppMapLun - Map a LUN to an initiator group.

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
**Vserver**				- Specifies the Vserver that contains the LUN you want to map.  
**Path**				- Specifies the path of the LUN that you want to map. Examples of correct LUN paths are /vol/vol1/lun1 and /vol/vol1/qtree1/lun1.  
**LunId**				- Specifies the LUN ID for the mapping.  
**Igroup**				- Specifies the igroup that you want to map.  