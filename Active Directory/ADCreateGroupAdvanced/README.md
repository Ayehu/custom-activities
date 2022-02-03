# ADCreateGroupAdvanced - an activity that creates groups in AD.

### Namespaces to import:

Imports Ayehu.Sdk.ActivityCreation.Interfaces<br/>
Imports Ayehu.Sdk.ActivityCreation.Extension<br/>
Imports System.Text<br/>
Imports System.DirectoryServices<br/>
Imports System.IO<br/>
Imports System<br/>
Imports System.Data<br/>
Imports Microsoft.VisualBasic<br/>
Imports System.Net<br/>

### To create a group, you must provide the fields below:

**Path** - AD group path (e.g. "\Users")

**Description** - Description of the group.

**Notes** - Additional notes on the group.

**Scope** - Global or Universal group.

**Type** - Security or Distribution group.

**Group Name** - Name for new group.

**Owner Dist. Name** - Distinguished name of group owner (e.g. "CN=John Smith,CN=Users,DC=mydomain,DC=com")

**Hostname** - Domain controller hostname.

**Username** - AD username.

**Password** - AD password.

**Port** - AD LDAP port.
