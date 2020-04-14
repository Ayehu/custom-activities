## NetAppCloneVolume - Clone Volume in NetApp.

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
**Vserver**				- VServer (SVM)  which contains the volume  
**Volume**				- Volume name of the new cloned volume  

### Optional fields:

**Parent Volume**		- If source is a volume, indicate volume name  
**Parent Snapshot**		- If source is a snapshot, indicate snapshot name  
