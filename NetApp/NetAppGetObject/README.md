## NetAppGetObject -Return result according XML request in NetApp.

##### DLL's to reference
NetApp.dll  

You can find the dll at this repository in the NetApp folder.  

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using NetApp.My;  

### Mandatory fields:

**IP**					- IP  
**Username**			- Username to access API  
**Password**			- Password to acces API  
**ObjectRequestXml**	- XML containing filters types of search. Bellow you can see and example:  

<?xml version="1.0" encoding="UTF-8" standalone="no" ?>. 
<ObjectName>Export Policies</ObjectName>. 
<FilterItems>. 
	<FilterItem>. 
		<FilterName>name</FilterName>. 
		<Valueitems>. 
			<FilterValue>{PUT FILTER VALUE FOR `NAME` HERE}</FilterValue>. 
		</Valueitems>. 
	</FilterItem>. 
	<FilterItem>. 
		<FilterName>vserver</FilterName>  
		<Valueitems>. 
			<FilterValue>{PUT FILTER VALUE FOR `VSERVER` HERE}</FilterValue>. 
		</Valueitems>. 
	</FilterItem>. 
</FilterItems>. 
