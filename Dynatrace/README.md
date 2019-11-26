# Dynatrace **Use the Dynatrace API to automate your monitoring tasks and export different types of data into your third-party reporting and analysis tools.**

[Dynatrace website](https://www.dynatrace.com/support/help/get-started/what-is-dynatrace/) <br/>
[Official documentation](https://www.dynatrace.com/support/help/extend-dynatrace/dynatrace-api/environment-api/)

# Dynatrace Activities

## Dependencies:
1. Newtonsoft.Json

## Remark:
1. Create an account in Dynatrace and get an environment id | https://{your-environment-id}.live.dynatrace.com.
2. Create a host in https://{your-environment-id}.live.dynatrace.com.
3. Create a token in | https://{your-environment-id}.live.dynatrace.com -> Settings -> Integration -> Dynatrace API -> Generate Token.

## Mandatory fields for using api :<br />
AuthorizationToken(string) - Use your existing user token or you can create the User Token with following steps | https://{your-environment-id}.live.dynatrace.com -> Settings -> Integration -> Dynatrace API -> Generate Token<br />
EnvironmentId(string) - Get environment id from URI | https://{your-environment-id}.live.dynatrace.com. <br />
