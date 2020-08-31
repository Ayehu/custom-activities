# LMAcknowledgeAlert - Activity that acknowledge alert by id.

### Namespaces to import:

using Ayehu.Sdk.ActivityCreation.Extension;<br/>
using Ayehu.Sdk.ActivityCreation.Interfaces;<br/>
using Newtonsoft.Json.Linq;<br/>
using System;<br/>
using System.IO;<br/>
using System.Net;<br/>
using System.Text;<br/>

### Below fields needs to be provided to execute an activity:

**Account Name** - your account name. This is usually part of the URL, for example: `https://myaccount.logicmonitor.com` - in this case **myaccount** your account name.

**Access Id** and **Access Key** - API tokens to be used for API calls. More details: https://www.logicmonitor.com/support/settings/users-and-roles/api-tokens

**Alert Id** - the alert id in LogicMonitor, which is needed to acknowledge.

**Comment** - the acknowledge comment.