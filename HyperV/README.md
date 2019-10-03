# HyperV Activities

### Please config trustedhosts on both Ayehu Cloud Server and Target Hyper-V Host. You can run the following PowerShell command:
**set-item wsman:\localhost\Client\TrustedHosts -value * -force**


**CheckpointVM** - Activity to Creates a checkpoint of a virtual machine.

**RestoreVMSnapshot** - Activity to Restores a virtual machine checkpoint.

**RemoveVMSnapshot** - Activity to Deletes a virtual machine checkpoint. 

**EnableSCVMHost** - Activity to Restores a virtual machine host in maintenance mode to full service.

**DisableSCVMHost** - Activity to place a virtual machine host into maintenance mode. 
