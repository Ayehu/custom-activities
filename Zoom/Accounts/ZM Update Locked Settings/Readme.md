#     Zoom


Update Locked Settings

[Account Locked Settings](https://support.zoom.us/hc/en-us/articles/115005269866) allow you turn settings on or off for all users in your account. No user except the account admin or account owner can change these settings. With lock settings, you force the settings on for all users. Use this API to update an account's locked settings.

**Note:** This API can be used by Zoom Accounts that are on a Pro or a higher plan as well accounts that have Master and Sub Accounts options enabled. 

**Prerequisites:**
* Pro or a higher paid account. 
**Scope:** `account:write:admin`
 

Method: Patch

OperationID: updateAccountLockSettings

EndPoint:

/accounts/{accountId}/lock_settings
