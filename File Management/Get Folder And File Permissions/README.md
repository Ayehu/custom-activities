<h1>Get Folder And File Permissions</h1>
<br>
An activity to retrieve permission details on a single file or folder of a Windows host.  This activity performs its task via PowerShell Remote, and as a result there must be connectivity with this protocol to the target host.
<br><br>
<h3>Input:</h3>
<ul>
  <li><b>Host Name:</b> Target host to query for page file list.</li>
  <li><b>User Name:</b> Username with which to authenticate to target host.</li>
  <li><b>Password:</b> Username with which to authenticate to target host.</li>
  <li><b>PowerShell Port:</b> Port on which target host will accept a PowerShell Remote connection (default is <b>5985</b>).</li>
  <li><b>URI Type:</b> Protocol with which target host will accept a PowerShell Remote connection (default is <b>HTTP</b>).</li>
  <li><b>File or Folder Path:</b> The full path to the file or folder for which to retrieve permissions (e.g. <b>C:\MyFolder\</b> or <b>C:\MyFolder\MyFile.ext</b>).</li>
</ul>
<br>
<h3>Example:</h3>
<br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/File%20Management/Get%20Folder%20And%20File%20Permissions/screenshot1.png?raw=true">
<br><br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/File%20Management/Get%20Folder%20And%20File%20Permissions/screenshot2.png?raw=true">
