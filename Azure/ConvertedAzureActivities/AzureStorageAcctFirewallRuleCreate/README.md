## AzureStorageAcctFirewallRuleCreate - Creates a new StorageAccount Firewall rule.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
System.Net.Http.dll
Newtonsoft.Json.dll

### Mandatory fields when adding a Firewall rule 

**subscriptionId**		- The azure portal subscription Id

**ipAddress**		    - IP Address to allow.

**storageName**			- The name of the StorageAccount.

**resourceGroupName**   - The portal resource StorageAccount is assigned to.

**api_version**			- Version of the API