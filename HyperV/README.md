# HyperV Activities

#### Please config trustedhosts on both Ayehu Cloud Server and Target Hyper-V Host. You can run the following PowerShell command:
**set-item wsman:\localhost\Client\TrustedHosts -value * -force**

#### Please Copy System.Management.Automation.dll to the following folder: c:\Libs\. The dll is located on "C:\Program Files (x86)\Reference Assemblies\Microsoft\WindowsPowerShell\3.0\System.Management.Automation.dll"
 
#### Please Copy Microsoft.HyperV.Powershell.dll to the following folder: c:\Libs\. The dll is located on "C:\Windows\Microsoft.NET\assembly\GAC_MSIL\Microsoft.HyperV.PowerShell\v4.0_10.0.0.0__31bf3856ad364e35\"

**HyperVVLan** - Activity to configure the virtual LAN settings for Virtual Machine on Hyper-V.

**CheckpointVM** - Activity to create a checkpoint of a virtual machine.

**RestoreVMSnapshot** - Activity to restore a virtual machine checkpoint.

**RemoveVMSnapshot** - Activity to delete a virtual machine checkpoint. 

**HyperVRemoveVM** - Activity to delete a virtual machine.

**HyperVModifyCPU** - Activity to configures settings for the virtual processors of a virtual machine. 

**HyperVMountISO** - Activity to configure a virtual DVD drive.

**HyperVMigrateStorage** - Moves the storage of a virtual machine.

**HyperVRemoveDisk** -Deletes a hard disk drive from a virtual machine.

**HyperVVMPowerState** - Activity to get the power state of a virtual machine from one Hyper-V hosts.

**HyperVShutdownVM** - Activity to shut down a virtual machine.

**HyperVRenameVM** - Activity to rename a virtual machine.

**HyperVExportVM** - Activity to export a virtual machine to disk.

**HyperVExportVMSnapshot** - Activity to export a virtual machine checkpoint to disk.

**HyperVCopyFileToVM** - Activity to copy a file to a virtual machine.

**HyperVGetVMMemory** - Activity to get the memory of a virtual machine or snapshot.
