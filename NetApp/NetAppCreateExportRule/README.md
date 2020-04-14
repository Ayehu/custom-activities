## NetAppCreateExportRule - Create Export Policy Rule in NetApp.

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
**Vserver**				- VServer (SVM)  which contains the rule  
**ClientMatch**			- List of Client Match IPs, IP Addresses, Netgroups, or Domains  
**RoRule**				- specifies the security type for read-only access to volumes that use the export rule  
**RwRule**				- specifies the security type for read-write access to volumes that use the export rule  
**SuperuserRule**		- specifies a security type for superuser access to files  