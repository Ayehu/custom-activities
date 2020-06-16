Imports Ayehu.Sdk.ActivityCreation.Interfaces
Imports Ayehu.Sdk.ActivityCreation.Extension
Imports System.Data
Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System
Imports System.Collections.Generic
Imports System.Web

Namespace Ayehu.Sdk.ActivityCreation
    Public Class CustomActivity
        Implements IActivityAsync

        Public ApiKey as string
Public ApiSecret as string

        Public userId as string
Public topic as string
Public type as string
Public start_time as string
Public duration as string
Public timezone as string
Public password as string
Public agenda as string
Public field as string
Public value as string
Public repeat_interval as string
Public weekly_days as string
Public monthly_day as string
Public monthly_week as string
Public monthly_week_day as string
Public end_times as string
Public end_date_time as string
Public host_video as string
Public participant_video as string
Public cn_meeting as string
Public in_meeting as string
Public join_before_host as string
Public mute_upon_entry as string
Public watermark as string
Public use_pmi as string
Public approval_type as string
Public registration_type as string
Public audio as string
Public auto_recording as string
Public enforce_login as string
Public enforce_login_domains as string
Public alternative_hosts as string
Public close_registration as string
Public waiting_room as string
Public items as string
Public contact_name as string
Public contact_email as string
Public registrants_email_notification as string
Public meeting_authentication as string
Public authentication_option as string
Public authentication_domains as string


        Dim Httpmethod As String = "post"
        Dim client As HttpClient = New HttpClient()
        Dim dt As DataTable = New DataTable("resultSet")
        Dim RequestURL As String
        Dim TableName As String = "meetings"
        Public Async Function Execute() As System.Threading.Tasks.Task(Of ICustomActivityResult) Implements IActivityAsync.Execute

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            Dim PostData As String = "{  ""topic"" : " & Microsoft.VisualBasic.Strings.Chr(34) & topic & Microsoft.VisualBasic.Strings.Chr(34) & ",  ""type""  : " & type & ",  ""start_time"" : " & Microsoft.VisualBasic.Strings.Chr(34) & start_time & Microsoft.VisualBasic.Strings.Chr(34) & ",  ""duration"" : " & Microsoft.VisualBasic.Strings.Chr(34) & duration & Microsoft.VisualBasic.Strings.Chr(34) & ",  ""timezone"" : " & Microsoft.VisualBasic.Strings.Chr(34) & timezone & Microsoft.VisualBasic.Strings.Chr(34) & ",  ""password"" : " & Microsoft.VisualBasic.Strings.Chr(34) & password & Microsoft.VisualBasic.Strings.Chr(34) & ",  ""agenda"" : " & Microsoft.VisualBasic.Strings.Chr(34) & agenda & Microsoft.VisualBasic.Strings.Chr(34) & ",  ""recurrence"": {    ""type""  : " & type & ",    ""repeat_interval"" : " & Microsoft.VisualBasic.Strings.Chr(34) & repeat_interval & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""weekly_days"" : " & Microsoft.VisualBasic.Strings.Chr(34) & weekly_days & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""monthly_day"" : " & Microsoft.VisualBasic.Strings.Chr(34) & monthly_day & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""monthly_week"" : " & Microsoft.VisualBasic.Strings.Chr(34) & monthly_week & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""monthly_week_day"" : " & Microsoft.VisualBasic.Strings.Chr(34) & monthly_week_day & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""end_times"" : " & Microsoft.VisualBasic.Strings.Chr(34) & end_times & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""end_date_time"" : " & Microsoft.VisualBasic.Strings.Chr(34) & end_date_time & Microsoft.VisualBasic.Strings.Chr(34) & "  },  ""settings"": {    ""host_video"" : " & Microsoft.VisualBasic.Strings.Chr(34) & host_video & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""participant_video"" : " & Microsoft.VisualBasic.Strings.Chr(34) & participant_video & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""cn_meeting"" : " & Microsoft.VisualBasic.Strings.Chr(34) & cn_meeting & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""in_meeting"" : " & Microsoft.VisualBasic.Strings.Chr(34) & in_meeting & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""join_before_host"" : " & Microsoft.VisualBasic.Strings.Chr(34) & join_before_host & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""mute_upon_entry"" : " & Microsoft.VisualBasic.Strings.Chr(34) & mute_upon_entry & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""watermark"" : " & Microsoft.VisualBasic.Strings.Chr(34) & watermark & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""use_pmi"" : " & Microsoft.VisualBasic.Strings.Chr(34) & use_pmi & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""approval_type"" : " & Microsoft.VisualBasic.Strings.Chr(34) & approval_type & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""registration_type"" : " & Microsoft.VisualBasic.Strings.Chr(34) & registration_type & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""audio"" : " & Microsoft.VisualBasic.Strings.Chr(34) & audio & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""auto_recording"" : " & Microsoft.VisualBasic.Strings.Chr(34) & auto_recording & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""enforce_login"" : " & Microsoft.VisualBasic.Strings.Chr(34) & enforce_login & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""enforce_login_domains"" : " & Microsoft.VisualBasic.Strings.Chr(34) & enforce_login_domains & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""alternative_hosts"" : " & Microsoft.VisualBasic.Strings.Chr(34) & alternative_hosts & Microsoft.VisualBasic.Strings.Chr(34) & ",    ""global_dial_in_countries"": [      """"    ],    ""registrants_email_notification"" : " & Microsoft.VisualBasic.Strings.Chr(34) & registrants_email_notification & Microsoft.VisualBasic.Strings.Chr(34) & "  }}"
            Dim Data = New StringContent(PostData, Encoding.UTF8, "application/json")
			Dim queryString As Object = HttpUtility.ParseQueryString(String.Empty)
            RequestURL="https://api.zoom.us/v2/users/" & userId & "/meetings?"& queryString.ToString()

                                

            If RequestURL.EndsWith("&") OrElse RequestURL.EndsWith("?") Then RequestURL = RequestURL.Substring(0, RequestURL.Length - 1)
            Dim content As System.Net.Http.StringContent = New StringContent(PostData, Encoding.UTF8, "application/json")
            content.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            client.DefaultRequestHeaders.Add("authorization", "Bearer " + JsonWebToken.Encode(ApiKey, ApiSecret))

            Dim Request As HttpResponseMessage = Nothing
            Select Case Httpmethod
                Case "get"
                    Request = client.GetAsync(RequestURL).Result
                Case "delete"
                    Request = client.DeleteAsync(RequestURL).Result
                Case "put"
                    Request = client.PutAsync(RequestURL, Data).Result
                Case "post"
                    Request = client.PostAsync(RequestURL, Data).Result
                Case "patch"
                    Dim myHttpRequestMessage As New HttpRequestMessage(New HttpMethod("PATCH"), RequestURL)
                    myHttpRequestMessage.Content = content
                    Request = client.SendAsync(myHttpRequestMessage).Result
            End Select
            Select Case Request.StatusCode

                Case HttpStatusCode.NoContent, HttpStatusCode.Created, HttpStatusCode.Accepted
                    Return GenerateActivityResult("Success")

                Case HttpStatusCode.OK

                    Dim values As JObject = JsonConvert.DeserializeObject(Of JObject)(Request.Content.ReadAsStringAsync().Result)
                    If String.IsNullOrEmpty(TableName) Then  'Single record
                        For Each obj As Object In values
                            If dt.Columns.Count = 0 Then
                                dt.Columns.Add(obj.Key)
                            Else
                                Exit For
                            End If
                        Next
                        Dim newrow As DataRow = dt.NewRow
                        For Each obj As Object In values
                            If dt.Columns.Contains(obj.Key) = False Then dt.Columns.Add(obj.Key) ' Some columns discovered later
                            newrow(obj.Key) = obj.Value
                        Next
                        dt.Rows.Add(newrow)
                    Else
                        If values.ContainsKey(TableName) Then
                            For Each usersJ As JObject In values(TableName)
                                For Each obj As Object In usersJ
                                    If dt.Columns.Count = 0 Then
                                        dt.Columns.Add(obj.Key)
                                    Else
                                        Exit For
                                    End If
                                Next

                                Dim newrow As DataRow = dt.NewRow
                                For Each obj As Object In usersJ
                                    If dt.Columns.Contains(obj.Key) = False Then dt.Columns.Add(obj.Key) ' Some columns discovered later
                                    newrow(obj.Key) = obj.Value
                                Next
                                dt.Rows.Add(newrow)
                            Next
                        Else
                            Dim newrow As DataRow = dt.NewRow
                            For Each obj As Object In values
                                If dt.Columns.Contains(obj.Key) = False Then dt.Columns.Add(obj.Key) ' Some columns discovered later
                                newrow(obj.Key) = obj.Value
                            Next
                            dt.Rows.Add(newrow)
                        End If
                    End If

                    Return GenerateActivityResult(dt)

                Case Else
                    If String.IsNullOrEmpty(Request.ReasonPhrase) = False Then
                        Throw New System.Exception(Request.ReasonPhrase)
                    Else
                        Throw New System.Exception(Request.StatusCode)
                    End If

            End Select

        End Function

        Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
            Return True
        End Function

    End Class

    Public Class JsonWebToken

        Public Shared Function Encode(APIKey As String, Secret As String) As String

            Dim keyBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(Secret)

            Dim myhdr As New HDR
            myhdr.alg = "HS256"
            myhdr.typ = "JWT"

            Dim Expiry As System.DateTime = DateTime.UtcNow.AddSeconds(120)
            Dim ts As Integer = CInt((Expiry - New System.DateTime(1970, 1, 1)).TotalSeconds)
            Dim myhdrpayload As String = Newtonsoft.Json.JsonConvert.SerializeObject(myhdr)
            Dim mytpayload As New Tpayload
            mytpayload.iss = APIKey
            mytpayload.exp = ts

            Dim mypayload As String = Newtonsoft.Json.JsonConvert.SerializeObject(mytpayload)

            Dim headerBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(myhdrpayload)
            Dim payloadBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(mypayload)

            Dim stringToSign = Base64UrlEncode(headerBytes) + "." + Base64UrlEncode(payloadBytes)
            Dim bytesToSign = System.Text.Encoding.UTF8.GetBytes(stringToSign)
            Dim sha As New System.Security.Cryptography.HMACSHA256(keyBytes)
            Dim signature As Byte() = sha.ComputeHash(bytesToSign)

            Return stringToSign + "." + Base64UrlEncode(signature)

        End Function

        Private Shared Function Base64UrlEncode(ByVal input As Byte()) As String
            Dim output = System.Convert.ToBase64String(input)
            output = output.Split("="c)(0)
            output = output.Replace("+"c, "-"c)
            output = output.Replace("/"c, "_"c)
            Return output
        End Function
    End Class

    Public Class HDR

        Public alg As String
        Public typ As String

    End Class

    Public Class Tpayload

        Public iss As String
        Public exp As Integer

    End Class

End Namespace