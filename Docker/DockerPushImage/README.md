## DockerPushImage - Push a Docker image Docker Hub.

Remark - To be able to access remotely your docker server, folow this [tutorial](https://success.docker.com/article/how-do-i-enable-the-remote-api-for-dockerd) to setup.  
###ATTENTION!!
This configuration must open up your docker app to anyone.
So, ensure that you setup the remote machine firewall to allow only ayehu client to have access.  

##### DLL's to reference
Docker.DotNet.dll  
System.Buffers.dll  
System.ValueTuple.dll  
Docker.DotNet.BasicAuth.dll  
Newtonsoft.Json.dll  

You can find the dll's at [nuget](https://www.nuget.org/packages/Docker.DotNet/).  

##### Libraries to import
using Ayehu.Sdk.ActivityCreation.Interfaces;  
using Ayehu.Sdk.ActivityCreation.Extension;  
using System;  
using Docker.DotNet;  
using System.Collections.Generic;  
using Docker.DotNet.BasicAuth;  

### Mandatory fields when pushing a Docker image:
**RemoteDockerURI**		- URL from the machine that is running Docker application (e.g. http://54.164.40.64:4243)  
**ImageName**			- Image name to be pushed  
**DockerUsername**		- Docker hub username  
**DockerPassword**		- Docker hub password  