## NetAppDeleteIgroup - Delete an existing initiator group.

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
**IgroupName**			- Specifies the initiator group that you want to delete  
**Force**				- Deletes an initiator group and all associated LUN maps