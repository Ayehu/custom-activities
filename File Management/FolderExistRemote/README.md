## Folder Exist Remote - Checks whether a folder exist or not supporting impersonation with credentials provided in the the activity for all path types.

## DLL's to reference

SimpleImpersonation.dll

## Fields to be set in the activity.

**Path:** Path in which to search for folder. Permitted to specify relative or absolute path information. Relative path information is interpreted as relative to the current working directory.

**Username:** A username (Domain\Username) that has access to both locations ( source and destination ), can be left empty if not required .

**Password:** The password of the account listed in the Username field.

**Result:** True or False

True if the caller has the required permissions and path contains the name of an existing file; otherwise, false. Due to limit of FileExist command not returning exceptions if path is null, invalid or caller does not have sufficient sufficient permissions to directory of specified file, an additional check is completed when returning false.  The additional check validates if the designated file is readonly in order to return an appropriate exception if failed
