<h1>Find Files By Size</h1>
<br>
Retrieve list of files on a Windows host using size as a filter.  For example:
<br>
<ul>
  <li>Recursively list of all files with a size greater than <b>500 MB</b> within <b>C:\Users\</b> and all of its subfolders.</li>
  <li>List all files with a size less than <b>500 KB</b> with <b>C:\Temp\</b>.</li>
</ul>
<br>
This activity performs its task via PowerShell Remote, and as a result there must be connectivity with this protocol to the target host.
<br><br>
<h3>Input:</h3>
<ul>
  <li><b>Host Name:</b> Target host from which to retrieve folder or file permissions.</li>
  <li><b>User Name:</b> Username with which to authenticate to target host.</li>
  <li><b>Password:</b> Username with which to authenticate to target host.</li>
  <li><b>PowerShell Port:</b> Port on which target host will accept a PowerShell Remote connection (default is <b>5985</b>).</li>
  <li><b>URI Type:</b> Protocol with which target host will accept a PowerShell Remote connection (default is <b>HTTP</b>).</li>
  <li><b>Search Path:</b> The full path to the folder in which to perform the search (e.g. <b>C:\temp</b>).</li>
  <li><b>File Size Filter:</b> Find files greater than or less than a specific size.</li>
  <li><b>File Size (Bytes):</b> The filtered file size (in bytes).</li>
  <li><b>Sort By:</b> Sort results by a particular property (e.g. <b>CreationTime</b> or <b>DirectoryName</a>).</li>
  <li><b>Perform recursive file search:</b> Yes/no option to search within the target folder recursively (i.e. all subfolders).</li>
</ul>
<br>
<h3>Example:</h3>
<br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/File%20Management/Find%20Files%20By%20Size/screenshot_1.png?raw=true">
<br><br>
<img src="https://github.com/Ayehu/custom-activities/blob/master/File%20Management/Find%20Files%20By%20Size/screenshot_2.png?raw=true">
