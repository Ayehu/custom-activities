
### HyperVCopyFileToVM - Activity to copiy a file to a virtual machine.
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
Microsoft.HyperV.Powershell;

### Mandatory fields when creating a checkpoint.
**Host Name** - Specifies the Url or Ip address of Hyper-V server.
**User Name** - Specifies the username of windows account on Hyper-V server with permission to run powershell command.
**Password** - Specifies the password of windows account.
**Name** - Specifies an array of virtual machine objects by name. The cmdlet copies files to the virtual machines you specify.
**SourcePath** - Specifies a path. The cmdlet copies the file from the source path.
**DestinationPath** - Specifies a path. The cmdlet copies the file to the destination path.
**CreateFullPath** - Indicates that when the cmdlet copies a file, it creates folders if the folder does not already exist.
**As Job** - Specifies to run the cmdlet as a background job.

### Powershell command document reference.

[Copy-VMFile](https://docs.microsoft.com/en-us/powershell/module/hyper-v/copy-vmfile?view=win10-ps)