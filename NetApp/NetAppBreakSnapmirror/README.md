## NetAppBreakSnapmirror - Make SnapMirror destination writable.

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
**DestinationVserver**	- Specifies the destination Vserver of the SnapMirror relationship.  
**DestinationVolume**	- Specifies the destination volume of the SnapMirror relationship.  