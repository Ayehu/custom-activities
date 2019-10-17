
### HyperVVMPowerState - Activity to get the power state of a virtual machine from one Hyper-V hosts.

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

### Powershell command document reference.

[Get-VM](https://www.notion.so/insk/VM-Power-State-c99416a50de3436f9a07a3484d194ea9#e69105b557054264ae55d5ed93e295da)