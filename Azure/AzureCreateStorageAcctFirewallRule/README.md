## AzureCreateStorageAcctFirewallRule - Creates a new StorageAccount Firewall rule.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
Microsoft.Azure.Management.Compute.Fluent.dll
Microsoft.Azure.Management.Fluent.dll
Microsoft.Azure.Management.ResourceManager.Fluent.dll
Microsoft.Azure.Management.Network.Fluent.dll
Microsoft.Azure.Management.Sql.Fluent.dll
Microsoft.Rest.ClientRuntime.dll
Microsoft.Rest.ClientRuntime.Azure.dll
Microsoft.Azure.Management.Storage.Fluent.dll
System.Net.Http.dll
Newtonsoft.Json.dll

##### Libraries to import
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Fluent;

You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret
SubscriptionId

### Mandatory fields when FirewallRule

**storageAccountName** - The name of the the account to apply the rule

**ipAddress** - The IP Address to allow access. Important: It has to be a public IP addresses only, not private/internal. Only IPV4 address is allowed
