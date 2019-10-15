
### HyperVMigrateStorage - Moves the storage of a virtual machine.

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
**DestinationStoragePath** - Specifies a destination storage path to which all virtual machine storage is to be moved.

### Powershell command document reference.

[Move-VMStorage]https://www.notion.so/insk/Migrate-Storage-0ecb21379dc84234aa132fb942e22b4f#94b779c136d949d281eef6f0d323ca00