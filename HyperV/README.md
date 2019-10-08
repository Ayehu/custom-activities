# HyperV Activities

#### Please config trustedhosts on both Ayehu Cloud Server and Target Hyper-V Host. You can run the following PowerShell command:
**set-item wsman:\localhost\Client\TrustedHosts -value * -force**

#### Please Copy System.Management.Automation.dll to the following folder: c:\Libs\. The dll is located on "C:\Program Files (x86)\Reference Assemblies\Microsoft\WindowsPowerShell\3.0\System.Management.Automation.dll"
 
**HyperVVLan** - Activity to configure the virtual LAN settings for Virtual Machine on Hyper-V.

**CheckpointVM** - Activity to Creates a checkpoint of a virtual machine.

**RestoreVMSnapshot** - Activity to Restores a virtual machine checkpoint.

**RemoveVMSnapshot** - Activity to Deletes a virtual machine checkpoint. 

