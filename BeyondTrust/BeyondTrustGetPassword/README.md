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

• API Key <br />
o Required – String <br />
o Example: e7c23e73e85f3349b40a5953476dc6234234234232325346576568789878789fgh3450117dfasdfasdfasdf9 <br />
o The API Key configured in BeyondInsight for your application <br />

• Runas <br />
o Required – String <br />
o Example: ayehu <br />
o The username of a BeyondInsight user that has been granted permission to use the API Key.<br />

• Password <br />
o Optional – Masked String <br />
o The RunAs user password; required only if the User Password is required on the Application API Registration).<br />

• Account Name <br />
o Required – String <br />
o Example: admin.local <br />
o Name of the Managed Account<br />

System Name <br />
o Optional – String <br />
o Example: AYEHU-SRV <br />
o Name of the Managed System<br />

Work Group Name <br />
o Optional – String <br />
o Name of workgroup<br />

Application Display Name <br />
o Optional – String <br />
o Display name of the Application, applied only when ‘type’ is also given<br />

Type <br />
o Optional – Enum <br />
o Type of the Managed Account to return <br />
 Empty <br />
 system - returns local accounts <br />
 domainlinked - returns domain acoutns linked to systems <br />
 database - returns database accounts <br />
 cloud - returns cloud system accounts <br />
 application - returns application accounts<br />

Access Type <br />
o Required – Enum <br />
o Options: <br />
 View (default) - 'View Password' acces <br />
 RDP - RDP access (corresponds to POST Sesssions SessionType ‘RDP’ or ‘rdpfile’) <br />
 SSH - SSH access (corresponds to POST Sesssions SessionType ‘SSH’) <br />
 App - Application access (corresponds to POST Sesssions SessionType ‘App’ or ‘appfile’)<br />

Duration <br />
o Required – Integer (1 - 525600) <br />
o The request duration (in minutes)<br />

Reason <br />
o Optional – String <br />
o Reason for the request<br />

Conflict Option <br />
o Optional – enum o The conflict resolution option to use if an existing request is found for the same user, system, and account (reuse, renew). If omitted and a conflicting request is found, returns a 409 error. <br />
o Options: <br />
 reuse - Return an existing, approved request ID for the same user/system/account/access type (if one exists). If the request does not already exist, creates a new request using the request body details. <br />
 renew - Cancel any existing approved requests for the same user/system/account and create a new request using the request body details.<br />

Ticket System ID <br />
o Optional – Integer o ID of the ticket system. If omitted, then default ticket system will be used.<br />

Ticket Number <br />
o Optional – String o Number of associated ticket. Can be required if ticket system is marked as required in the global options.<br />

Rotate On Checkin <br />
o Optional – Boolean o Default: True o True to rotate the credentials on check-in/expiry, otherwise false. This property can only be used if the Access Policy (either auto-selected or given in AccessPolicyScheduleID) supports it. See the ‘Allow API Rotation Override’ Access Policy setting under ‘View’ access. If the Managed Account given in AccountID does not rotate the credentials after check-in/expiry, this setting is ignored.<br />
