Imports Ayehu.Sdk.ActivityCreation.Interfaces
Imports Ayehu.Sdk.ActivityCreation.Extension
Imports IBM.Cloud.SDK.Core.Authentication.Iam
Imports IBM.Watson.Assistant.v2
Imports System.Data
Imports System.Net


Namespace Ayehu.Sdk.ActivityCreation
    Public Class CustomActivity
        Implements IActivity


        Public RequestType As String
        Public Phrase As String 
        Public Confidence As String
        Public MaxSuggest As String
        Public DisplayConfidence As String
        Dim APIKEY As String = "{APIKEY}"  
        Dim AssistantID As String = "{AssistantID }"    
        Dim URL As String = "https://api.us-south.assistant.watson.cloud.ibm.com" 'change if need
        Dim Version As String = "2019-02-28"  'change if need
        Dim authenticator As IamAuthenticator
        Dim assistant As AssistantService
        Dim SuggestCounter As Integer = 0

        Public Function Execute() As ICustomActivityResult Implements IActivity.Execute

       Dim Data As String = "{""input"": {""text"": """ + phrase + """}}"
    
		 ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim dt As DataTable = New DataTable("resultSet")
        If (RequestType.ToLower) = "intents" Then
            dt.Columns.Add("Intent")
        ElseIf (RequestType.ToLower) = "entities" Then
            dt.Columns.Add("Entity")
        End If
        If (DisplayConfidence.ToLower) = "yes" Then dt.Columns.Add("Confidence")
        If String.IsNullOrEmpty(MaxSuggest) Then MaxSuggest = 1
        If Integer.Parse(MaxSuggest) = 0 Then MaxSuggest = 1


        authenticator = New IamAuthenticator(APIKEY)
        assistant = New AssistantService(Version, authenticator)
        assistant.SetServiceUrl(URL)
        assistant.DisableSslVerification(True)

        Dim resultSession As IBM.Cloud.SDK.Core.Http.DetailedResponse(Of Model.SessionResponse) = assistant.CreateSession(AssistantID)

        Dim int As New Model.MessageInput()
        int.Text = Data

        If MaxSuggest > 1 Then
            Dim opt As New Model.MessageInputOptions()
            opt.AlternateIntents = True
            int.Options = opt
        End If

        Dim result As IBM.Cloud.SDK.Core.Http.DetailedResponse(Of IBM.Watson.Assistant.v2.Model.MessageResponse) = assistant.Message(AssistantID, resultSession.Result.SessionId, int)

        If result.Result.Output.Intents.Count > 0 AndAlso RequestType.ToLower = "intents" Then
            For Each item As Model.RuntimeIntent In result.Result.Output.Intents
                If item.Confidence > Confidence Then
                    Dim newintent As DataRow = dt.NewRow
                    newintent("Intent") = item.Intent
                    If (DisplayConfidence.ToLower) = "yes" Then newintent("Confidence") = item.Confidence
                    dt.Rows.Add(newintent)
                    SuggestCounter = SuggestCounter + 1
                End If
                If SuggestCounter = MaxSuggest Then Exit For
            Next

        ElseIf result.Result.Output.Entities.Count > 0 AndAlso (RequestType.ToLower) = "entities" Then
            For Each item As Model.RuntimeEntity In result.Result.Output.Entities
                If item.Confidence > Confidence Then
                    Dim newintent As DataRow = dt.NewRow
                    newintent("Entity") = item.Entity
                    If (DisplayConfidence.ToLower) = "yes" Then newintent("Confidence") = item.Confidence
                    dt.Rows.Add(newintent)
                    SuggestCounter = SuggestCounter + 1
                End If
                If SuggestCounter = MaxSuggest Then Exit For
            Next
        End If

        assistant.DeleteSession(AssistantID, resultSession.Result.SessionId)

            Return GenerateActivityResult(dt)


        End Function

    End Class

End Namespace