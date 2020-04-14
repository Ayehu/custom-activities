## NetAppResyncSnapmirror - Start a resynchronize operation in NetApp.

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
**DestinationVolume**	- Specifies the destination volume of the SnapMirror relationship.  
**DestinationVserver**	- Specifies the destination Vserver of the SnapMirror relationship.  