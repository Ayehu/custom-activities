
### HyperVRemoveDisk -Deletes a hard disk drive from a virtual machine.

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
**VMHardDiskDrive** - Specifies the virtual hard disk drive to be deleted.
**ControllerLocation(C Location)** - Specifies the number of the location on the controller at which the virtual hard disk drive is to be deleted. If not specified, the number of the first available location on the controller is used.
**ControllerNumber(C Number)** - Specifies the number of the controller from which the virtual hard disk drive is to be deleted. If not specified, the first controller on which the specified ControllerLocation is available is used.
### Powershell command document reference.
**ControllerType** - Specifies the type of the controller where the virtual hard disk is to be deleted. Allowed values are IDE and SCSI.

[Remove-VMHardDiskDrive]https://www.notion.so/insk/VM-Delete-Disk-Remove-VMHardDiskDrive-10b84d89cda74dabb01263dd0680c5f4#2a3e8060ac8f40859b4ff7d7064ad0d9