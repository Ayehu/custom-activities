
### HyperVRenameVM - Activity to rename a virtual machine.

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
**Name** - Specifies the name of the virtual machine to be renamed.
**NewName** - Specifies the name to which the virtual machine is to be renamed.

### Powershell command document reference.

[Rename-VM](https://www.notion.so/insk/VM-Rename-1815ca527e4f47768bf11c95308b798e#39d62098bf2a48399cb2dffba54a6673)