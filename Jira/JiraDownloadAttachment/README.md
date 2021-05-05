For the "Instance URL" field, the following are the default formats:
<br>
<ul>
<li>On-premise instance - http:// SERVER_NAME :8080</li>
<li>Cloud instance - https:// SITE_NAME .atlassian.net</li>
</ul>
<br>
In order to retrieve the attachment ID and attachment filename needed to execute this activity, you have two options.
<br><br>
The first and easiest option is to use the <a href="https://github.com/Ayehu/custom-activities/tree/master/Jira/JiraListAttachments">JiraListAttachments</a> activity from this repository.
<br><br>
The second option is to use the default out-of-the-box Jira integration within Ayehu NG.  This is achieved by using the <b>JiraGetIssue</b> activity and then extracting the contents of the "Attachment" column.
<br><br>
Below is an example of the JSON contained within that cell:
<br>
<pre>
{
  "self": "https://xxxx.atlassian.net/rest/api/2/attachment/32209",
  "id": "32209",
  "filename": "INSTALLATION_LOG.txt",
  "author": {
    "self": "https://xxxx.atlassian.net/rest/api/2/user?accountId=5d4c5392cca0cf0c56be398e",
    "accountId": "5d4c5392cca0cf0c56be398e",
    "avatarUrls": {
      "48x48": "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/5d4c5392cca0cf0c56be398e/015dc3da-60eb-4ed1-a173-aad766501025/48",
      "24x24": "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/5d4c5392cca0cf0c56be398e/015dc3da-60eb-4ed1-a173-aad766501025/24",
      "16x16": "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/5d4c5392cca0cf0c56be398e/015dc3da-60eb-4ed1-a173-aad766501025/16",
      "32x32": "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/5d4c5392cca0cf0c56be398e/015dc3da-60eb-4ed1-a173-aad766501025/32"
    },
    "displayName": "Derek Pascarella",
    "active": true,
    "timeZone": "Asia/Jerusalem",
    "accountType": "atlassian"
  },
  "created": "2020-07-20T16:14:53.596-04:00",
  "size": 846934,
  "mimeType": "text/plain",
  "content": "https://xxxx.atlassian.net/secure/attachment/32209/INSTALLATION_LOG.txt"
}
</pre>
<br>
Here, we see a key named "id" which will serve as our "Attachment ID".  We also see a key named "filename" which will serve as our "Attachment Filename".
<br><br>
In the <b>JiraDownloadFile</b> activity configuration, use only the folder path for the "Save Folder" field (e.g. "C:\my\folder\").  By default, the same filename from the Jira ticket will be used when saving.  You can optionally select the "Save attachment with a custom filename" checkbox and then specify that custom filename in the field that becomes enabled.
