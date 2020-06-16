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

        Public setting_type as string


        Dim Httpmethod As String = "patch"
        Dim client As HttpClient = New HttpClient()
        Dim dt As DataTable = New DataTable("resultSet")
        Dim RequestURL As String
        Dim TableName As String = "account_settings"
        Public Async Function Execute() As System.Threading.Tasks.Task(Of ICustomActivityResult) Implements IActivityAsync.Execute

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            Dim PostData As String = "{  ""zoom_rooms"": {    ""upcoming_meeting_alert"": true,    ""show_alert_before_meeting"": false,    ""start_airplay_manually"": false,    ""weekly_system_restart"": false,    ""display_meeting_list"": false,    ""display_top_banner"": false,    ""display_feedback_survey"": false,    ""auto_direct_sharing"": true,    ""transform_meeting_to_private"": true,    ""hide_id_for_private_meeting"": false,    ""auto_start_scheduled_meeting"": true,    ""auto_stop_scheduled_meeting"": false,    ""audio_device_daily_auto_test"": false,    ""support_join_3rd_party_meeting"": false,    ""email_address_prompt_before_recording"": true,    ""secure_connection_channel"": true,    ""encrypt_shared_screen_content"": false,    ""allow_multiple_content_sharing"": false,    ""show_non_video_participants"": true,    ""show_call_history_in_room"": true,    ""make_room_alternative_host"": true,    ""show_contact_list_on_controller"": false,    ""count_attendees_number_in_room"": false,    ""send_whiteboard_to_internal_contact_only"": true  }}"
            Dim Data = New StringContent(PostData, Encoding.UTF8, "application/json")
			Dim queryString As Object = HttpUtility.ParseQueryString(String.Empty)
            RequestURL="https://api.zoom.us/v2/rooms/account_settings?"& queryString.ToString()

                                

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