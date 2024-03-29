<h1>Micro Focus SMAX (Service Management Automation X)</h1>
These activities are designed to be used with <a href="https://www.microfocus.com/en-us/products/service-management-automation-suite/overview">Micro Focus SMAX</a> (Service Management Automation X).
<br><br>
Authentication is done via username/password combination, which is used to automatically retrieve an API token upon each separate activity execution.
<br><br>
The various API endpoints used by these activities are:
<br>
<ul>
<li><a href="https://docs.microfocus.com/itom/SMAX:2020.05/CaseExchange">https://docs.microfocus.com/itom/SMAX:2020.05/CaseExchange</a></li>
<li><a href="https://docs.microfocus.com/itom/SMAX:2020.05/CollectQueryProtocol">https://docs.microfocus.com/itom/SMAX:2020.05/CollectQueryProtocol</a></li>
<li><a href="https://docs.microfocus.com/itom/SMAX:2020.05/SingleEntityOps">https://docs.microfocus.com/itom/SMAX:2020.05/SingleEntityOps</a></li>
<li><a href="https://docs.microfocus.com/itom/SMAX:2020.05/BulkUpdate">https://docs.microfocus.com/itom/SMAX:2020.05/BulkUpdate</a></li>
</ul>
<br>
For information on filter syntax, visit <a href="https://docs.microfocus.com/itom/SMAX:2020.05/CollectQueryProtocol#Collection_filtering">https://docs.microfocus.com/itom/SMAX:2020.05/CollectQueryProtocol#Collection_filtering</a>.
<br><br>
Below is an example of the syntax for the "Fields" input:
<br>
<i>Id,Status,DisplayLabel,Description,ImpactScope,Urgency,OwnedByPerson,OwnedByPerson.Name</i>
<br><br>
Below are examples of the syntax for the "Filter" input:
<ul>
  <li><i>LastUpdateTime > 1601321299000</i></li>
  <li><i>LastUpdateTime > 1601321299000 and RequestsOffering = '13263'</i></li>
  <li><i>LastUpdateTime > 1601321299000 and RequestsOffering in(13263,13257)</i></li>
</ul>
<br>
<b>Note:</b> To work with timestamps, use the following activities for conversion:
<ul>
  <li><a href="https://github.com/Ayehu/custom-activities/tree/master/ConvertUNIXTimeToHumanReadable">ConvertUNIXTimeToHumanReadable</a></li>
  <li><a href="https://github.com/Ayehu/custom-activities/tree/master/GetUNIXTimestamp">GetUNIXTimestamp</a></li>
</ul>
