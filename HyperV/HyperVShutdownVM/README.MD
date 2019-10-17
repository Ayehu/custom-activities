
### HyperVShutdownVM - Activity to shut down a virtual machine.
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
**VM Name** - Specifies the name of the target virtual machine.
**As Job** - Specifies to run the cmdlet as a background job.

### Powershell command document reference.

[Stop-VM](https://www.notion.so/insk/VM-Shutdown-4ddde2a4769a44aebc4680cbb515a5e7#50cfaa909d8649b78fff5c3f7ab5d118)