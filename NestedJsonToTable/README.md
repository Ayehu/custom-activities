### Assemblies to reference

using Ayehu.Sdk.ActivityCreation.Interfaces;<br>
using Ayehu.Sdk.ActivityCreation.Extension;<br>
using Newtonsoft.Json.Linq;<br>
using Newtonsoft.Json;<br>
using System.Collections.Generic;<br>
using System.Data;<br>
using System.Text;<br>
using System.IO;<br>
using System.Linq;<br>
using System;<br>

### DLLs to reference

System.dll<br>
System.XML.dll<br>
System.Data.dll<br>
Newtonsoft.Json.dll<br>

### Input fields

<b>JSON Variable:</b> The variable containing the JSON-formatted text.

### Example

Consider the following JSON body:
<br>
<pre>{
   "sys_created_by": "Resolve_IT",
   "knowledge": "false",
   "order": "98234",
   "cmdb_ci": {
      "link": "https://mindtreedemosvs1.service-now.com/api/now/table/cmdb_ci/46a7a696a9fe198100d5064bdc21cd56",
      "value": "46a7a696a9fe198100d5064bdc21cd56"
   }
}</pre>
