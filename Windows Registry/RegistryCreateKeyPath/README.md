<h1>Registry Create Key Path</h1>
<br>
This activity will create a new key path in Windows Registry.  This activity performs its tasks via PowerShell Remote, and as a result there must be connectivity with this protocol to the target host.
<br><br>
<h3>Input:</h3>
<ul>
  <li><b>Host Name:</b> Target host on which the Registry change should be made.</li>
  <li><b>User Name:</b> Username with which to authenticate to target host.</li>
  <li><b>Password:</b> Username with which to authenticate to target host.</li>
  <li><b>PowerShell Port:</b> Port on which target host will accept a PowerShell Remote connection (default is <b>5985</b>).</li>
  <li><b>URI Type:</b> Protocol with which target host will accept a PowerShell Remote connection (default is <b>HTTP</b>).</li>
  <li><b>Registry Key:</b> Base Registry key where change should be made.</li>
  <li><b>Path:</b> Full path to the new Registry key.</li>
</ul>
<br>
<h3>Example:</h3>
<br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/Windows%20Registry/RegistryCreateKeyPath/screenshot.png?raw=true">
