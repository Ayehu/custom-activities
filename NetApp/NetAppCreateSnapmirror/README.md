## NetAppCreateSnapmirror - Create Snapmirror in NetApp.

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
**SourceVserver**		- Specifies the source Vserver of the SnapMirror relationship.  
**SourceVolume**		- Specifies the source volume of the SnapMirror relationship.  
**SourceCluster**		- Specifies the source cluster of the SnapMirror relationship.  
**DestinationVServer**	- Specifies the destination Vserver of the SnapMirror relationship.  
**DestinationVolume**	- Specifies the destination volume of the SnapMirror relationship.