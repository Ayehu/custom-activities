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

        Public accountId as string
Public host_video as string
Public participant_video as string
Public audio_type as string
Public join_before_host as string
Public enforce_login as string
Public enforce_login_with_domains as string
Public enforce_login_domains as string
Public not_store_meeting_topic as string
Public require_password_for_scheduling_new_meetings as string
Public require_password_for_instant_meetings as string
Public require_password_for_pmi_meetings as string
Public meeting_authentication as string
Public e2e_encryption as string
Public chat as string
Public private_chat as string
Public auto_saving_chat as string
Public entry_exit_chime as string
Public feedback as string
Public post_meeting_feedback as string
Public co_host as string
Public polling as string
Public attendee_on_hold as string
Public show_meeting_control_toolbar as string
Public allow_show_zoom_windows as string
Public annotation as string
Public whiteboard as string
Public remote_control as string
Public webinar_question_answer as string
Public anonymous_question_answer as string
Public breakout_room as string
Public closed_caption as string
Public far_end_camera_control as string
Public group_hd as string
Public virtual_background as string
Public alert_guest_join as string
Public auto_answer as string
Public sending_default_email_invites as string
Public use_html_format_email as string
Public dscp_marking as string
Public stereo_audio as string
Public original_audio as string
Public screen_sharing as string
Public cloud_recording_available_reminder as string
Public jbh_reminder as string
Public cancel_meeting_reminder as string
Public alternative_host_reminder as string
Public schedule_for_host_reminder as string
Public local_recording as string
Public cloud_recording as string
Public auto_recording as string
Public cloud_recording_download as string
Public account_user_access_recording as string
Public host_delete_cloud_recording as string
Public auto_delete_cmr as string
Public recording_authentication as string
Public third_party_audio as string
Public call_out as string
Public show_international_numbers_link as string


        Dim Httpmethod As String = "patch"
        Dim client As HttpClient = New HttpClient()
        Dim dt As DataTable = New DataTable("resultSet")
        Dim RequestURL As String
        Dim TableName As String = "lock_settings"
        Public Async Function Execute() As System.Threading.Tasks.Task(Of ICustomActivityResult) Implements IActivityAsync.Execute

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
            Dim PostData As String = ""
            Dim Data = New StringContent(PostData, Encoding.UTF8, "application/json")
			Dim queryString As Object = HttpUtility.ParseQueryString(String.Empty)
            RequestURL="https://api.zoom.us/v2/accounts/" & accountId & "/lock_settings?"& queryString.ToString()

                                

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