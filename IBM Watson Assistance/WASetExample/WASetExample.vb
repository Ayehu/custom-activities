Imports Ayehu.Sdk.ActivityCreation.Interfaces
Imports Ayehu.Sdk.ActivityCreation.Extension
Imports System.Text
Imports IBM.Cloud.SDK.Core.Authentication.Iam
Imports IBM.Watson.Assistant.v1
Imports System.Net

Namespace Ayehu.Sdk.ActivityCreation
    Public Class CustomActivity
	  Implements  IActivity

        
  Public Intent As String 
  Public phrase As String 

    Dim APIKEY As String = "{APIKEY}"
    Dim WorkspaceID As String = "{WorkspaceID}"

    Dim URL As String = "https://api.us-south.assistant.watson.cloud.ibm.com"
    Dim Version As String = "2019-02-28"
    Dim authenticator As IamAuthenticator
    Dim assistant As AssistantService

  Public Function Execute() As ICustomActivityResult Implements IActivity.Execute
          
     ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        authenticator = New IamAuthenticator(APIKEY)
        assistant = New AssistantService(Version, authenticator)
        assistant.SetServiceUrl(URL)
        assistant.DisableSslVerification(True)

        Dim result = assistant.CreateExample(WorkspaceID, Intent, phrase)

        Return GenerateActivityResult("Succsss")
    
        End Function
    End Class
End Namespace
