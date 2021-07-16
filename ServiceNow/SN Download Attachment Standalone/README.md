<h1>ServiceNow Download Attachment Standalone</h1>

This activity allows for the downloading of file attachments from tickets entirely independent of a native Ayehu NG ServiceNow integration module.  Reasons for using this Custom Activity can include:
<br>
<ul>
  <li>Having insufficient table permissions to use the native integration's attachment download capabilities.</li>
  <li>Having the requirement to download an attachment from a ticket via Remote Executor when no method exists to copy a file from a remote host back to the core Ayehu NG server.</li>
</ul>
<br>
<h2>Input Fields</h2>
<b>Instance URL:</b> https://xxxxxx.service-now.com
<br>
<b>Username:</b> Username to access ServiceNow instance.
<br>
<b>Password:</b> Password to access ServiceNow instance.
<br>
<b>Attach. SysID:</b> The SysID of the individual attachment.
<br>
<b>Save Folder:</b> The target folder in which to save the attachment.
<br>
<b>Filename:</b> The filename to be given to the saved attachment.
