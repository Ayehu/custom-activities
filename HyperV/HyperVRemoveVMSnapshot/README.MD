
### RemoveVMSnapshot - Activity to Deletes a virtual machine checkpoint. 
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
**Checkpoint Name** - Specifies the name of the checkpoint to be deleted.
**Include Child** - Specifies that the checkpoint's children are to be deleted along with the checkpoint.
**As Job** - Specifies to run the cmdlet as a background job.

### Powershell command document reference.

[Remove-VMSnapshot](https://docs.microsoft.com/en-us/powershell/module/hyper-v/remove-vmsnapshot?view=win10-ps)