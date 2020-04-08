## SharepointUpdateSiteOwner - Updates the owner of Sharepoint site.

##### DLL's to reference
Microsoft.SharePoint.Client.dll
Microsoft.SharePoint.Client.Runtime.dll

Fields to be set in the activity.

**InstanceURL** 	- The Sharepoint base URL

**Site**			- Sharepoint Site to add user to. If it's the root website, then leave it empty.

**UserName**		- Username used to login in admin panel of Sharepoint instance.

**Password**		- Password used to login in admin panel of Sharepoint instance.

**UserLogonName** 	- User full login name as defined in the Domain or Azure Active Directory.