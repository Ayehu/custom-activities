## FileCopy Remote - Moves a file from a source location to a destination location supporting impersonation with credentials provided in the the activity

## DLL's to reference

SimpleImpersonation.dll

## Fields to be set in the activity.

Source Path: The path of the source file (when accessing a remote machine or a shared location use UNC format).

Destination Path: The path of the destination file (when accessing a remote machine or a shared location use UNC format).

Username: A username (Domain\Username) that has access to both locations ( source and destination ), can be left empty if not required 

Password: The password of the account listed in the Username field.

Overwrite: Specify whether to overwrite the destination file or not.
