## SharePointListSiteOwner - Retrieves the Owner of a SharePoint site.

##### DLL's to reference
Microsoft.SharePoint.Client.dll
Microsoft.SharePoint.Client.Runtime.dll
Microsoft.Online.SharePoint.Client.Tenant.dll

## The UserName have to be part of site admins to get owner information.

Fields to be set in the activity.

**InstanceURL** 	- The SharePoint base URL

**Site**			- SharePoint Site to get the owner information. If it's the root website, then leave it empty.

**UserName**		- Username used to login in admin panel of SharePoint instance.

**Password**		- Password used to login in admin panel of SharePoint instance.