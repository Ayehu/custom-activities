## AzureSQLFirewallRuleCreate - Create a firewall rule for an Azure SQL server.

Remark - The portal needs to be configured first. https://portal.azure.com

##### DLL's to reference
System.Net.Http.dll

### Mandatory fields when adding a Firewall rule 

**subscriptionId**		- The azure portal subscription Id

**firewallRuleName**	- The name of the firewall rule.

**ipAddress**		    - IP Address to allow.

**serverName**			- The name of the SQL Server.

**resourceGroupName**   - The portal resource SQL Server is assigned to.

**api_version**			- Version of the API