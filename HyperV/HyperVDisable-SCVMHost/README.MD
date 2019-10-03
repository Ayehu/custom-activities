
### DisableSCVMHost - Activity to place a virtual machine host into maintenance mode. 
**This activity can change the status of a virtual machine host managed by System Center Virtual Machine Manager, it can not use for any standalone Hyper-V Host**
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
**Within Cluster ** - Indicates that all virtual machines currently deployed on a host that is a member of a host cluster will be migrated to another host in the same host cluster if that host is placed into maintenance mode.
**PROTipID** - Specifies the ID of the Performance and Resource Optimization tip (PRO tip) that triggered this action. This parameter lets you audit PRO tips.
**JobVariable** - Specifies that job progress is tracked and stored in the variable named by this parameter.
**Run Async** - Indicates that the job runs asynchronously so that control returns to the command shell immediately.

### Powershell command document reference.

[Disable-SCVMHost](https://docs.microsoft.com/en-us/powershell/module/virtualmachinemanager/disable-scvmhost?view=systemcenter-ps-2019)