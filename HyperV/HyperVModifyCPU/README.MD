
### HyperVModifyCPU - Configures settings for the virtual processors of a virtual machine. Settings are applied uniformly to all virtual processors belonging to the virtual machine.

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
**Count** - Specifies the number of virtual processors for the virtual machine.
**Maximum** - Specifies the maximum percentage of resources available to the virtual machine processor to be configured. Allowed values range from 0 to 100.
**Reserve** - Specifies the percentage of processor resources to be reserved for this virtual machine. Allowed values range from 0 to 100.
**RelativeWeight** - Specifies the priority for allocating the physical computer's processing power to this virtual machine relative to others. Allowed values range from 1 to 10000.
**ResourcePoolName** - Specifies
**ResourcePoolName** - Specifies the name of the processor resource pool to be used.


### Powershell command document reference.

[Set-VMProcessor](https://www.notion.so/insk/VM-Modify-CPU-d683aa10552c4316b230d93303a49ad1#683293a0189a413e83726332967869da)