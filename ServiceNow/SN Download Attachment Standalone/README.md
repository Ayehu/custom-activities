<h1>ServiceNow Download Attachment Standalone</h1>

This activity allows for the downloading of file attachments from tickets entirely independent of a native Ayehu NG ServiceNow integration module.  Reasons for using this Custom Activity can include:
<br>
<ul>
  <li>Having insufficient table permissions to use the native integration's attachment download capabilities.</li>
  <li>Having the requirement to download an attachment from a ticket via Remote Executor when no method exists to copy a file from the core Ayehu NG server to that remote host.</li>
</ul>
For details on how to query the sys_attachment table to retrieve the SysID of attachment, refer to the following guide: <a href="https://support.ayehu.com/hc/en-us/articles/360050350674-How-to-Dynamically-Retrieve-and-Download-a-List-of-Attachments-from-a-ServiceNow-Ticket">https://support.ayehu.com/hc/en-us/articles/360050350674-How-to-Dynamically-Retrieve-and-Download-a-List-of-Attachments-from-a-ServiceNow-Ticket</a>.
<br><br>
<h2>Input Fields</h2>
<b>Instance URL:</b> https://xxxxxx.service-now.com
<br>
<b>Username:</b> Username to access ServiceNow instance.
<br>
<b>Password:</b> Password to access ServiceNow instance.
<br>
<b>Attach. SysID:</b> The SysID of the individual attachment (e.g. <b>2553985e1bc5301025db4377cc4bcbee</b>).
<br>
<b>Save Folder:</b> The target folder in which to save the attachment (e.g. <b>C:\my\folder\here\</b>).
<br>
<b>Filename:</b> The filename to be given to the saved attachment (e.g. <b>my_attachment.xls</b>).
