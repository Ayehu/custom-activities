<h1>HCVPutCredentials</h1>
<h3>Stores credentials from a HashiCorp Vault.</h3>

<h3>Libraries to Import</h3>
using Ayehu.Sdk.ActivityCreation.Interfaces;<br>
using Ayehu.Sdk.ActivityCreation.Extension;<br>
using Newtonsoft.Json.Linq;<br>
using Newtonsoft.Json;<br>
using System.Data;<br>
using System.Text;<br>
using System.IO;<br>
using System.Net;<br>
using System.Web;<br>
using System;<br>


<h3>DLLs to Reference</h3>
System.Net.dll<br>
Newtonsoft.JSON.dll<br>

<h3>Input Fields</h3>
<b>Server Hostname:</b> The hostname, IP address, or FQDN of the HashiCorp Vault server (e.g. "35.166.33.91", "vault.mycompany.com", etc.)<br>
<b>Protocol:</b> Option to use either HTTP or HTTPS depending on your certificate settings on your Vault server.<br>
<b>API Token:</b> API token used for authentication with the Vault.<br>
<b>Secret Name:</b> Secret name to be stored <br>
<b>Item Name:</b> Item name to be stored <br>
<b>Key1:</b> The Key to be stored, example values are username, password etc. <br>
<b>Value1</b> The Value to be stored, example values <br>
<b>Key2:</b> The Key to be stored, example values are username, password etc. <br>
<b>Value2</b> The Value to be stored, example values <br>

<h3>Output:</h3>
Returns string value "Success", if there are any errors it throws an expections
