<h1>ServiceNow Upload Attachment Standalone</h1>

This activity allows for the uploading of file attachments to tickets entirely independent of a native Ayehu NG ServiceNow integration module.  Reasons for using this Custom Activity can include:
<br>
<ul>
  <li>Having insufficient table permissions to use the native integration's attachment upload capabilities.</li>
  <li>Having the requirement to upload a ticket attachment via Remote Executor when no method exists to copy a file from a remote host back to the core Ayehu NG server.</li>
</ul>
<br>
<h2>Input Fields</h2>
<b>Instance URL:</b> https://xxxxxx.service-now.com
<br>
<b>Username:</b> Username to access ServiceNow instance.
<br>
<b>Password:</b> Password to access ServiceNow instance.
<br>
<b>Table Type:</b> Internal name of the target table (e.g. incident, sc_request, change_request, sc_task, etc.).
<br>
<b>Ticket Number:</b> Display number of the ticket (e.g. INC0069734), which will be used to look-up the Sys ID.
<br>
<b>File Path:</b> The full path of the file to upload (e.g. C:\folder\file.jpg)
