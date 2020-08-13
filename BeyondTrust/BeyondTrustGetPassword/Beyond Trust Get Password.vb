Imports Ayehu.Sdk.ActivityCreation.Interfaces
Imports Ayehu.Sdk.ActivityCreation.Extension
Imports System.Text
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Imports System.IO
Imports System
Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Ayehu.Sdk.ActivityCreation
    Public Class CustomActivity
        Implements IActivity

        Public URL As String
        Public APIKEY As String
        Public RUNAS As String
        Public PWD As String
        Public AccountName As String
        Public SystemName As String
        Public workgroupName As String
        Public applicationDisplayName As String
        Public AccessType As String
        Public DurationMinutes As String
        Public Reason As String
        Public ConflictOption As String
        Public TicketSystemID As String
        Public TicketNumber As String
        Public RotateOnCheckin As String

        Dim client As HttpClient = New HttpClient()
        Dim BaseUrl As String = ""
        Dim SystemId As String = ""
        Dim AccountId As String = ""


        Public Function Execute() As ICustomActivityResult Implements IActivity.Execute

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            Return GenerateActivityResult(Execute(URL, APIKEY, RUNAS, PWD, AccountName, SystemName, workgroupName, applicationDisplayName, AccessType, DurationMinutes, Reason, ConflictOption, TicketSystemID, TicketNumber, RotateOnCheckin))

        End Function

        Function Execute(TheBaseUrl As String, APIKey As String, RunAs As String, pwd As String, AccountName As String, SystemName As String, workgroupName As String, applicationDisplayName As String, AccessType As String, DurationMinutes As String, Reason As String, ConflictOption As String, TicketSystemID As Integer, TicketNumber As String, RotateOnCheckin As String) As String

            Dim ThePassword As String = ""

            BaseUrl = TheBaseUrl
            If String.IsNullOrEmpty(pwd) Then
                client.DefaultRequestHeaders.Add("Authorization", "PS-Auth key=" & APIKey & "; runas=" & RunAs & ";")
            Else
                client.DefaultRequestHeaders.Add("Authorization", "PS-Auth key=" & APIKey & "; runas=" & RunAs & ";pwd=[" & pwd & "];")
            End If

            Auth()
            ManagedAccount(AccountName, SystemName, workgroupName, applicationDisplayName)
            Dim requestid As String = Request(SystemId, AccountId, AccessType, DurationMinutes, Reason, ConflictOption, TicketSystemID, TicketNumber, RotateOnCheckin)
            ThePassword = Credentials(requestid)
            SignOut()
            Return ThePassword


        End Function

        Sub Auth()

            Dim url As Uri = Nothing
            Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(Nothing)
            Dim content As System.Net.Http.StringContent = New StringContent(json)
            content.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            Uri.TryCreate(New Uri(BaseUrl), "/BeyondTrust/api/public/v3/Auth/SignAppin", url)
            Dim signInResponse As HttpResponseMessage = client.PostAsync(url, content).Result
            If signInResponse.StatusCode <> 200 Then Throw New Exception(signInResponse.ReasonPhrase)

        End Sub

        Sub ManagedAccount(AccountName As String, SystemName As String, workgroupName As String, applicationDisplayName As String)

            If String.IsNullOrEmpty(AccountName) Then Throw New Exception("Invalid account name")

            Dim url As Uri = Nothing
            Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(Nothing)
            Dim content As System.Net.Http.StringContent = New StringContent(json)

            Dim cont As String = "accountName=" & AccountName
            If String.IsNullOrEmpty(SystemName) = False Then cont = cont & "&SystemName=" & SystemName
            If String.IsNullOrEmpty(workgroupName) = False Then cont = cont & "&workgroupName=" & workgroupName
            If String.IsNullOrEmpty(applicationDisplayName) = False Then cont = cont & "&applicationDisplayName=" & applicationDisplayName


            content.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/json")

            Uri.TryCreate(New Uri(BaseUrl), "/BeyondTrust/api/public/v3/ManagedAccounts?" & cont, url)


            Dim signInResponse As HttpResponseMessage = client.GetAsync(url).Result

            If signInResponse.StatusCode <> 200 Then Throw New Exception(signInResponse.ReasonPhrase)

            'if systemname indicated then no need for jarray

            If String.IsNullOrEmpty(SystemName) Then
                Dim values As JArray = JsonConvert.DeserializeObject(Of JArray)(signInResponse.Content.ReadAsStringAsync().Result)
                If values.Count = 0 Then Throw New Exception("Invalid account")

                Try
                    SystemId = values(0).Item("SystemId").ToString()
                Catch ex As Exception
                    Throw New Exception("Invalid system ID")
                End Try

                Try
                    AccountId = values(0).Item("AccountId").ToString()
                Catch ex As Exception
                    Throw New Exception("Invalid account ID")
                End Try
            Else
                Dim values As JObject = JsonConvert.DeserializeObject(Of JObject)(signInResponse.Content.ReadAsStringAsync().Result)
                Try
                    SystemId = values.Item("SystemId").ToString()
                Catch ex As Exception
                    Throw New Exception("Invalid system ID")
                End Try

                Try
                    AccountId = values.Item("AccountId").ToString()
                Catch ex As Exception
                    Throw New Exception("Invalid account ID")
                End Try
            End If




        End Sub

        Function Request(SystemID As Integer, AccountID As Integer, AccessType As String, DurationMinutes As Integer, Reason As String, ConflictOption As String, TicketSystemID As Integer, TicketNumber As String, RotateOnCheckin As String) As String

            If DurationMinutes = 0 Then DurationMinutes = 1
            If String.IsNullOrEmpty(AccessType) Then AccessType = "View"

            Dim sb As New StringBuilder()
            Dim sw As New StringWriter(sb)
            Using writer As JsonWriter = New JsonTextWriter(sw)
                writer.Formatting = Formatting.Indented
                writer.WriteStartObject()
                writer.WritePropertyName("AccessType")
                writer.WriteValue(AccessType)
                writer.WritePropertyName("SystemID")
                writer.WriteValue(SystemID)

                writer.WritePropertyName("AccountID")
                writer.WriteValue(AccountID)

                writer.WritePropertyName("ApplicationID")
                writer.WriteValue(DBNull.Value)

                writer.WritePropertyName("DurationMinutes")
                writer.WriteValue(DurationMinutes)

                If String.IsNullOrEmpty(Reason) = False Then
                    writer.WritePropertyName("Reason")
                    writer.WriteValue(Reason)
                End If

                writer.WritePropertyName("AccessPolicyScheduleID")
                writer.WriteValue(DBNull.Value)

                If String.IsNullOrEmpty(ConflictOption) = False Then
                    writer.WritePropertyName("ConflictOption")
                    writer.WriteValue(ConflictOption)
                End If


                If TicketSystemID > 0 Then
                    writer.WritePropertyName("TicketSystemID")
                    writer.WriteValue(TicketSystemID)
                End If

                If String.IsNullOrEmpty(TicketNumber) = False Then
                    writer.WritePropertyName("TicketNumber")
                    writer.WriteValue(TicketNumber)
                End If

                If RotateOnCheckin = "False" Then
                    writer.WritePropertyName("RotateOnCheckin")
                    writer.WriteValue("false")
                End If

                writer.WriteEnd()

            End Using


            Dim url As Uri = Nothing
            Dim json As String = sb.ToString
            Dim content As System.Net.Http.StringContent = New StringContent(json)
            content.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            Uri.TryCreate(New Uri(BaseUrl), "/BeyondTrust/api/public/v3/Requests", url)
            Dim signInResponse As HttpResponseMessage = client.PostAsync(url, content).Result
            If signInResponse.StatusCode <> 200 AndAlso signInResponse.StatusCode <> 201 Then Throw New Exception(signInResponse.ReasonPhrase)
            Dim resp As String = signInResponse.Content.ReadAsStringAsync().Result.ToString()
            If String.IsNullOrEmpty(resp) = True Then Throw New Exception("Invalid request")
            Return resp

        End Function


        Function Credentials(RequestID As String) As String

            Dim url As Uri = Nothing
            Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(Nothing)
            Dim content As System.Net.Http.StringContent = New StringContent(json)
            content.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            Uri.TryCreate(New Uri(BaseUrl), "/BeyondTrust/api/public/v3/Credentials/" & RequestID, url)
            Dim signInResponse As HttpResponseMessage = client.GetAsync(url).Result
            If signInResponse.StatusCode <> 200 Then Throw New Exception(signInResponse.ReasonPhrase)

            Dim ThePassword As String = signInResponse.Content.ReadAsStringAsync().Result
            If String.IsNullOrEmpty(ThePassword) = True Then Throw New Exception("Invalid request ID")
            Return ThePassword.Replace("""", "")

        End Function

        Sub SignOut()

            Dim url As Uri = Nothing
            Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(Nothing)
            Dim content As System.Net.Http.StringContent = New StringContent(json)
            content.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            Uri.TryCreate(New Uri(BaseUrl), "/BeyondTrust/api/public/v3/Auth/Signout", url)
            Dim signInResponse As HttpResponseMessage = client.PostAsync(url, content).Result
            If signInResponse.StatusCode <> 200 Then Throw New Exception(signInResponse.ReasonPhrase)


        End Sub

        Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
            Return True
        End Function

    End Class
End Namespace
