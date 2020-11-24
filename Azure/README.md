## Azure Activities
Activities repository to manage Azure cloud infrastructure (e.g. virtual machines, disks, network interfaces, etc.).
<br><br>
Some activities will generate an authorization token on-the-fly, while others require that you generate one independently and then pass it to the activity itself.  The authorization token can be retrieved using the <a href="https://github.com/Ayehu/custom-activities/tree/master/Azure/AzureGetToken">AzureGetToken</a> activity (Management API only) or by using the <a href="https://github.com/Ayehu/custom-activities/tree/master/Azure/AzureRetrieveAccessToken">AzureRetrieveAccessToken</a> activity and selecting the appropriate API for the <b>Scope</b> field.
