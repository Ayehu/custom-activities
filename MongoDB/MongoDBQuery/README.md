# MongoDBQuery - Activity that performs a database query on MongoDB Server.

### Namespaces to import:

using Ayehu.Sdk.ActivityCreation.Extension;<br/>
using Ayehu.Sdk.ActivityCreation.Interfaces;<br/>
using MongoDB.Bson;<br/>
using MongoDB.Bson.IO;<br/>
using MongoDB.Driver;<br/>
using Newtonsoft.Json.Linq;<br/>
using System;<br/>
using System.Data;<br/>
using System.Linq;<br/>

### Below fields needs to be provided to execute an query:

**Server** - URL or IP address of MongoDB instance. You don't need to specify a port, the activity will find all available MongoDB clusters by itself.

**Use DNS Seedlist** - use a connection string prefix of mongodb+srv:// rather than the standard mongodb://. For more details visit [MongoDB Connection String URI](https://docs.mongodb.com/manual/reference/connection-string/#dns-seedlist-connection-format)

**Username and Password** - for the database user.

**Database Name** - to specify the name of the database.

**JSON Query** - JSON text of the query for the db.runCommand() method. For example:

```javascript
{ find: "houses", filter: { beds: { $gt: 5 } } }
```