## SharePointUpdateSiteOwner - Updates the owner of SharePoint site.

##### DLL's to reference
Microsoft.SharePoint.Client.dll
Microsoft.SharePoint.Client.Runtime.dll

Fields to be set in the activity.

**InstanceURL** 	- The SharePoint base URL

**Site**			- SharePoint Site to set the new owner. If it's the root website, then leave it empty.

**UserName**		- Username used to login in admin panel of SharePoint instance.

**Password**		- Password used to login in admin panel of SharePoint instance.

**UserLogonName** 	- User full login name as defined in the Domain or Azure Active Directory.