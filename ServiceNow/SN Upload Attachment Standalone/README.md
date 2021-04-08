<h1>ServiceNow Upload Attachment Standalone</h1>

This activity allows for the uploading of file attachments to tickets entirely independent of a native Ayehu NG ServiceNow integration module.  Reasons for using this Custom Activity can include:
<br>
<li>
  <ul>Having insufficient table permissions to use the native integration's attachment upload capabilities.</ul>
  <ul>Having the requirement to upload a ticket attachment via Remote Executor when no method exists to copy a file from a remote host back to the core Ayehu NG server.</ul>
</li>
<br><br>
<h3>Input Fields</h3>
<b>Instance URL:</b> https://xxxxxx.service-now.com
<br>
<b>Username:</b> Username to access ServiceNow instance.
<br>
<b>Password:</b> Password to access ServiceNow instance.
<br>
<b>Table Type:</b> incident, sc_request, change_request, sc_task, etc. (see default names <a href="https://docs.servicenow.com/bundle/london-platform-administration/page/administer/reference-pages/reference/r_TablesAndClasses.html">here</a>).
<br>
<b>Ticket Number:</b> Display number of the ticket (e.g. INC0069734), which will be used to look-up the Sys ID.
<br>
<b>File Path:</b> The full path of the file to upload (e.g. C:\folder\file.jpg)
