
### HyperVExportVM - Activity to export a virtual machine to disk.
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
**Password** - Specifies the password of windows account.
**Name** - Specifies the name of the virtual machine to be exported.
**Path** - Specifies the path to the folder into which the virtual machine is to be exported.
**As Job** - Specifies to run the cmdlet as a background job.

### Powershell command document reference.

[Export-VM](https://docs.microsoft.com/en-us/powershell/module/hyper-v/export-vm?view=win10-ps)