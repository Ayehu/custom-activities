## DockerPushImage - Push a Docker image Docker Hub.

Remark - To be able to access remotely your docker server, folow this [tutorial](https://success.docker.com/article/how-do-i-enable-the-remote-api-for-dockerd) to setup.  
### ATTENTION!!
This configuration must open up your docker app to anyone.
So, ensure that you setup the remote machine firewall to allow only ayehu client to have access.  

##### DLL's to reference
System.Net.Http.dll
System.Web.dll
Newtonsoft.Json.dll  

You can find the dll's at .NET Framework and [Newtonsoft nuget](https://www.nuget.org/packages/Newtonsoft.Json/).  

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;  
using Ayehu.Sdk.ActivityCreation.Extension;  
using System;  
using System.Net.Http;  
using System.Text;  
using System.Web;  

### Mandatory fields when pushing a Docker image:
**RemoteDockerURI**		- URL from the machine that is running Docker application (e.g. http://54.164.40.64:4243)  
**ImageName**			- Image name to be pushed  
**DockerUsername**		- Docker hub username  
**DockerPassword**		- Docker hub password  