HTTP Request With Token

Allows you to post a twostep request.
First step will post and receive a token which can be used in second post, all within one activity.

Required Dlls.

Newtonsoft.Json.dll

System.Net.Http.dll

Usage:

Within the activity,

Token Json Key – referred to the key name in the json which contains the value of the token.

&#60;Token&#62; can then be used in the second post header 
