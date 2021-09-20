## FileMove Remote ##

Moves a file from a source location to a destination location supporting impersonation with credentials provided in the the activity.

## DLLs to Reference

SimpleImpersonation.dll

## Input Fields

**Source Path:** The path of the source file (when accessing a remote machine or a shared location use UNC format).

**Destination Path:** The path of the destination file (when accessing a remote machine or a shared location use UNC format).

**Username:** A username (Domain\Username) that has access to both locations ( source and destination ), can be left empty if not required 

**Password:** The password of the account listed in the Username field.

## Example

<img src="https://github.com/Ayehu/custom-activities/blob/master/File%20Management/FileMove%20Remote/screenshot.png?raw=true">
