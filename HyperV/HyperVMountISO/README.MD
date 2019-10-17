
### HyperVMountISO - Activity to Configures a virtual DVD drive.

**DLL's to reference**
Microsoft.Management.Automation.dll
**Libraries to import**
System;
System.Management.Automation;
Ayehu.Sdk.ActivityCreation.Interfaces;
Ayehu.Sdk.ActivityCreation.Extension;
System.Management.Automation.Runspaces;
System.Security;
System.Collections.Generic;
System.IO;
System.Data;

### Mandatory fields when creating a checkpoint.
**Host Name** - Specifies the Url or Ip address of Hyper-V server.
**User Name** - Specifies the username of windows account on Hyper-V server with permission to run powershell command.
**VM Name** - Specifies the name of the target virtual machine.
**Path** - Specifies the path to the ISO file or physical DVD drive that will serve as media for the virtual DVD drive.
**ControllerNumber** - Specifies the IDE controller of the DVD drives to be configured. If not specified, DVD drives attached to all controllers are configured.
**ControllerLocation** - Specifies the IDE controller location of the DVD drives to be configured. If not specified, DVD drives in all controller locations are configured.
### Powershell command document reference.

[Set-VMDvdDrive]https://www.notion.so/insk/VM-Mount-ISO-dd26ad818da242968a7859c8590c95ba#e3fa9318f26c4ce0964bc6b04a383644)