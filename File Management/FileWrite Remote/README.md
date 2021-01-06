## FileWrite Remote - Creates a new plain text file supporting impersonation with credentials provided in the the activity

## DLL's to reference

SimpleImpersonation.dll

## Fields to be set in the activity.

Value: The string to write into the file.

Append to File: Specify whether to overwrite or append to an existing file.

Path: The path where the file should be created, must include file name in path (when accessing a remote machine or a shared location use UNC format).

Username: A username (Domain\Username) that has access to both locations ( source and destination ), can be left empty if not required .

Password: The password of the account listed in the Username field.
