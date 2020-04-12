## SharepointCreateSite - Create a new site from template.

##### DLL's to reference
Microsoft.SharePoint.Client.dll
Microsoft.SharePoint.Client.Runtime.dll
Microsoft.Online.SharePoint.Client.Tenant.dll

## Important: Creation of the actual site can take up to 10 minutes even though the activiy ran successfully.
## Also, you'd need to run activity to set site admins as this activity doesn't.

Fields to be set in the activity.

**InstanceAdminURL** 	- The Sharepoint Admin base URL (ex: https://tenant-admin.domain.com)

**SiteName**			- Sharepoint Site to add.

**SiteTitle**			- The title of the new Site.

**SiteOwnerLogin**		- The email of the user as defined in Active Directory.

**SiteTemplate**		- The template to create site from.

**UserName**			- Username used to login in admin panel of Sharepoint instance.

**Password**			- Password used to login in admin panel of Sharepoint instance.