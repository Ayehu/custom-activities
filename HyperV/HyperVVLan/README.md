### HyperVVLan - Activity to configure the virtual LAN settings for Virtual Machine on Hyper-V

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
[System.IO](http://system.io/);
System.Data;

### Mandatory fields when configing virtual network adapter.

**Host Name** - Specifies the Url or Ip address of Hyper-V server.

User Name - Specifies the username of windows account on Hyper-V server with permission to run powershell command.

Password - Specifies the password of windows account.

VM Name - Specifies the name of virtual machine which contains the target virtual network adapter.

VLanMode - Specifies the traffic mode of virtual network adapter: Access, Trunk, Private VLAN (isolated, community, or promiscuous), and untagged. 

Primary VlanId - Specifies the primary virtual LAN identifier for a virtual network adapter in Community, Isolated, or Promiscuous mode.

Vlan Id List - Specifies a list of virtual LANs allowed on a virtual machine network adapter.

VlanId 2 - Specifies the secondary virtual LAN identifier for a virtual network adapter in Community or Isolated mode.

Vlan IdList 2- Specifies a list of private virtual LAN secondary virtual LANs on a virtual machine network adapter

### Powershell command document reference.

[Set-VMNetworkAdapterVlan](https://docs.microsoft.com/en-us/powershell/module/hyper-v/set-vmnetworkadaptervlan?view=win10-ps)