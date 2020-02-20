# BeyondTrust Get Password
**Use the BeyondTrust API to automate your password retrieval**

[BeyondTrust website](https://www.beyondtrust.com/) <br/>
[Official documentation](https://www.beyondtrust.com/docs/privileged-remote-access/how-to/integrations/api/index.htm)

# BeyondTrust Activities

## Dependencies:
1. Newtonsoft.Json

## Remark:
1. Extract user credentials stored within BeyondTrust Password Vault

## Mandatory fields for using api :<br />
1. URL (string)
2. APIKey (string)
3. RUNAS (string)
4. AccountName (string)
5. DurationMinutes (string) - default value: "10"

## Activity Settings:<br />

• URL <br />
o Required – String <br />
o Example: Https://192.170.160.187 <br />
o URL of BeyondTrust instance <br />

• API Key o Required – String o Example: e7c23e73e85f3349b40a5953476dc6234234234232325346576568789878789fgh3450117dfasdfasdfasdf9 o The API Key configured in BeyondInsight for your application

• Runas o Required – String o Example: ayehu o The username of a BeyondInsight user that has been granted permission to use the API Key.

• Password o Optional – Masked String o The RunAs user password; required only if the User Password is required on the Application API Registration).

• Account Name o Required – String o Example: admin.local o Name of the Managed Account

• System Name o Optional – String o Example: AYEHU-SRV o Name of the Managed System

• Work Group Name o Optional – String o Name of workgroup

• Application Display Name o Optional – String o Display name of the Application, applied only when ‘type’ is also given

• Type o Optional – Enum o Type of the Managed Account to return  Empty  system - returns local accounts  domainlinked - returns domain acoutns linked to systems  database - returns database accounts  cloud - returns cloud system accounts  application - returns application accounts

• Access Type o Required – Enum o Options:  View (default) - 'View Password' acces  RDP - RDP access (corresponds to POST Sesssions SessionType ‘RDP’ or ‘rdpfile’)  SSH - SSH access (corresponds to POST Sesssions SessionType ‘SSH’)  App - Application access (corresponds to POST Sesssions SessionType ‘App’ or ‘appfile’)

• Duration o Required – Integer (1 - 525600) o The request duration (in minutes)

• Reason o Optional – String o Reason for the request

• Conflict Option o Optional – enum o The conflict resolution option to use if an existing request is found for the same user, system, and account (reuse, renew). If omitted and a conflicting request is found, returns a 409 error. o Options:  reuse - Return an existing, approved request ID for the same user/system/account/access type (if one exists). If the request does not already exist, creates a new request using the request body details.  renew - Cancel any existing approved requests for the same user/system/account and create a new request using the request body details.

• Ticket System ID o Optional – Integer o ID of the ticket system. If omitted, then default ticket system will be used.

• Ticket Number o Optional – String o Number of associated ticket. Can be required if ticket system is marked as required in the global options.

• Rotate On Checkin o Optional – Boolean o Default: True o True to rotate the credentials on check-in/expiry, otherwise false. This property can only be used if the Access Policy (either auto-selected or given in AccessPolicyScheduleID) supports it. See the ‘Allow API Rotation Override’ Access Policy setting under ‘View’ access. If the Managed Account given in AccountID does not rotate the credentials after check-in/expiry, this setting is ignored.
