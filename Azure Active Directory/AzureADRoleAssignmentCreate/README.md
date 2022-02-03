## AzureADCreateRoleAssignment - Add Role assignment for an Group or an AD user.


##### DLL's to reference
System.Net.Http.dll </br>
Newtonsoft.Json.dll </br>


##### Libraries to import
using System;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using Ayehu.Sdk.ActivityCreation.Helpers;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;


You'd need to store the API specific information from the portal.

ApplicationId
TenantId
Secret

### The below fields needs to be provided to apply license:

**Access token**      - Access token

**Object name** - The name of a security group or an ActiveDirectory user email. </br>

**Role Id** - Template Id of AD role.</br>
