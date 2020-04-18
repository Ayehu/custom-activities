## NetAppCreateIgroup - Add initiators to an initiator group.

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
**Vserver**				- VServer (SVM)  which will contains the Igroup  
**IgroupName**			- Specifies the name of the new initiator group.  
**OsType**				- Specifies the operating system type for the new initiator group.  
**IgroupType**			- Specifies if the initiator group protocol is fcp, iscsi, or mixed.