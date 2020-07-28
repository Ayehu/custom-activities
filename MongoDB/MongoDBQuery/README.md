# MongoDBQuery - Activity that performs a database query on MongoDB Server.

### Namespaces to import:

using Ayehu.Sdk.ActivityCreation.Extension;<br/>
using Ayehu.Sdk.ActivityCreation.Interfaces;<br/>
using MongoDB.Bson;<br/>
using MongoDB.Bson.Serialization;<br/>
using MongoDB.Driver;<br/>
using System;<br/>
using System.Collections.Generic;<br/>
using System.Data;<br/>

### Below fields needs to be provided to execute an query:

**Server** - URL or IP address of MongoDB instance. You don't need to specify a port, the activity will find all available MongoDB clusters by itself.

**Username and Password** - for the database user.

**Database Name** - to specify the name of the database.

**Collection Name** - to specify the database collection.

**JSON Query** - JSON text of the query for the find() method. For example:

```javascript
{ status: "A", qty: { $lt: 30 } }
```