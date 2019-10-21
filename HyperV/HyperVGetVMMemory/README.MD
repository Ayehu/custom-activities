
### HyperVGetVMMemory - Activity to get the memory of a virtual machine or snapshot.

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
**Name** - Specifies the name of the target virtual machine.
**IsSnapshot** - Specifies the snapshot whose memory is to be retrieved.
### Powershell command document reference.

[Get-VMMemory](https://docs.microsoft.com/en-us/powershell/module/hyper-v/get-vmmemory?view=win10-ps)