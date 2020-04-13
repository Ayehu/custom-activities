## SharePointCreateSite - Create a new site from template.

##### DLL's to reference
Microsoft.SharePoint.Client.dll
Microsoft.SharePoint.Client.Runtime.dll
System.IdentityModel.Tokens.dll

Fields to be set in the activity.

**InstanceAdminURL** 	- The SharePoint Admin base URL (ex: https://tenant-admin.domain.com)

**SiteName**			- SharePoint Site to add.

**SiteTitle**			- The title of the new Site.

**SiteOwnerLogin**		- The email of the user as defined in Active Directory.

**SiteTemplate**		- The template to create site from.

**UserName**			- Username used to login in admin panel of SharePoint instance.

**Password**			- Password used to login in admin panel of SharePoint instance.