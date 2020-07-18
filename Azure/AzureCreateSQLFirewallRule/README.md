## AzureCreateSQLFirewallRule - Creates a new SQL server Firewall Rule.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
Microsoft.Azure.Management.Compute.Fluent.dll
Microsoft.Azure.Management.Fluent.dll
Microsoft.Azure.Management.ResourceManager.Fluent.dll
Microsoft.Azure.Management.Network.Fluent.dll
Microsoft.Azure.Management.Sql.Fluent.dll
Microsoft.Rest.ClientRuntime.dll
Microsoft.Rest.ClientRuntime.Azure.dll
System.Net.Http.dll
Newtonsoft.Json.dll

##### Libraries to import
Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret
SubscriptionId

### Mandatory fields to add firewall rules
**sqlServerName** - SQL server to apply the rule

**firewallRuleName** - Rule name

**ipAddress** - IP address to apply
