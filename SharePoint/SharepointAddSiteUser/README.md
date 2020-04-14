## SharePointAddSiteUser - Activity to Add site user and with SiteAdmin role.

##### DLL's to reference
Microsoft.SharePoint.Client.dll
Microsoft.SharePoint.Client.Runtime.dll

**Important** - To add user to site, the UserName provided for authentication has to be already admin on that site.

Fields to be set in the activity.

**InstanceURL** 	- The SharePoint base URL

**Site**			- SharePoint Site to add user to. If it's the root website, then leave it empty.

**UserName**		- Username used to login in admin panel of SharePoint instance.

**Password**		- Password used to login in admin panel of SharePoint instance.

**UserLogonName** 	- User full login name as defined in the Domain or Azure Active Directory.