
### HyperVRemoveVM - Activity to Deletes a virtual machine.

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

[Remove-VM](https://www.notion.so/insk/VM-Delete-HyperVRemoveVM-c572c070ffbd403a8167663f55565b1b#32286e7ac48b46beabc5475a7355c982)