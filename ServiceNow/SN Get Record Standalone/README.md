<h1>ServiceNow Get Record Standalone</h1>

This activity allows for the retrieval of a ticket entirely independent of a native Ayehu NG ServiceNow integration module.  Reasons for using this Custom Activity can include:
<br>
<ul>
  <li>Having insufficient table permissions to use the native integration.</li>
</ul>
<h2>Input Fields</h2>
<b>Instance URL:</b> https://xxxxxx.service-now.com
<br>
<b>Username:</b> Username to access ServiceNow instance.
<br>
<b>Password:</b> Password to access ServiceNow instance.
<br>
<b>Table Type:</b> Internal name of the target table (e.g. incident, sc_request, change_request, sc_task, etc.  See default names <a href="https://docs.servicenow.com/bundle/london-platform-administration/page/administer/reference-pages/reference/r_TablesAndClasses.html">here</a>).
<br>
<b>Ticket Number:</b> Display number of the ticket (e.g. INC0069734), which will be used to look-up the Sys ID.
