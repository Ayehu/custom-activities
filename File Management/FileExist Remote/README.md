## FileExist Remote - Checks whether a file exist or not supporting impersonation with credentials provided in the the activity for all path types.

## DLL's to reference

SimpleImpersonation.dll

## Fields to be set in the activity.

**Path:** Path in which to search for file. Permitted to specify relative or absolute path information. Relative path information is interpreted as relative to the current working directory.

**Username:** A username (Domain\Username) that has access to both locations ( source and destination ), can be left empty if not required .

**Password:** The password of the account listed in the Username field.

Result: True or False



True if the caller has the required permissions and path contains the name of an existing file; otherwise, false. This method also returns false if path is null, an invalid path, or a zero-length string. If the caller does not have sufficient permissions to read the specified file, no exception is thrown and the method returns false regardless of the existence of path.
