## NetAppResizeVolume - Resize Volume in NetApp.

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
**Volume**				- Volume name to be resized  
**NewSizeMb**			- New volume size  
