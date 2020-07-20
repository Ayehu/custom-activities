Imports Ayehu.Sdk.ActivityCreation.Interfaces
Imports Ayehu.Sdk.ActivityCreation.Extension
Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.IO
Imports System.Data
Imports System
Imports Microsoft.VisualBasic


Namespace Ayehu.Sdk.ActivityCreation
    Public Class CustomActivity
        Implements IActivity

        Dim myCRTVAL As Integer = 0
        Public UserName As String
        Public Password As String
        Public UserNamet As String
        Public Passwordt As String
        Public Proxy As String
        Public Url As String
        Public RequestType As String
        Public Urlt As String
        Public RequestTypet As String
        Public SrcUserName As String
        Public SrcPassword As String
        Public PostData As String
        Public ContentType As String
        Public PostDatat As String
        Public ContentTypet As String
        Public crtval As Integer
        Public HeaderData As String
        Public HeaderDatat As String
        Public Sectype As String
        Public TokenJsonKey As String
        Public Function Execute() As ICustomActivityResult Implements IActivity.Execute

            Dim sw As New StringWriter
            Dim Domain As String = ""
            Dim dt As DataTable = New DataTable("resultSet")

            ' PUT and POST request required data to be posted
            If (RequestTypet.Equals("POST", StringComparison.InvariantCultureIgnoreCase) Or RequestTypet.Equals("PUT", StringComparison.InvariantCultureIgnoreCase)) AndAlso String.IsNullOrEmpty(PostDatat) Then
                Throw New ArgumentNullException("PostData", "Post Data is a required field. Please enter information")
            End If

            myCRTVAL = crtval
            ServicePointManager.ServerCertificateValidationCallback = AddressOf ServerCertificateValidationCallback

            Select Case Sectype.ToLower
                Case "ssl3"
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
                Case "tls"
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                Case "tls11"
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
                Case "tls12"
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            End Select

            Try
                If InStr(UserNamet, "\") Then
                    Domain = UserNamet.Substring(0, UserNamet.IndexOf("\"))
                    UserNamet = UserNamet.Substring(UserNamet.IndexOf("\") + 1, Len(UserNamet) - Len(Domain) - 1)
                End If
            Catch
            End Try

            Dim SNClient As HttpClient
            Dim handler As New HttpClientHandler
            If String.IsNullOrEmpty(Proxy) = False Then
                handler.Proxy = New WebProxy(Proxy)
                handler.UseProxy = True
                handler.Proxy.Credentials = New NetworkCredential(SrcUserName, SrcPassword)
            End If

            handler.UseCookies = False
            SNClient = New HttpClient(handler)

            If UserNamet <> "" Then
                handler.Credentials = New NetworkCredential(UserNamet, Passwordt, Domain)
                SNClient.DefaultRequestHeaders.Add("Authorization", "Basic " +
                   Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(UserNamet + ":" + Passwordt)))
            End If

            If HeaderDatat IsNot Nothing Then
                Dim headers() As String = HeaderDatat.Split(New String() {"|x|x|"}, StringSplitOptions.None)
                For Each header As String In headers
                    If header <> "" Then
                        Dim headerFields() As String = header.Split(New String() {"|y|y|"}, StringSplitOptions.None)
                        If headerFields IsNot Nothing Then
                            If headerFields.Length = 2 Then
                                SNClient.DefaultRequestHeaders.TryAddWithoutValidation(headerFields(0), headerFields(1))

                            Else
                                SNClient.DefaultRequestHeaders.TryAddWithoutValidation(headerFields(0), "")
                            End If
                        End If
                    End If
                Next
            End If

            SNClient.BaseAddress = New Uri(Urlt)
            SNClient.Timeout = System.Threading.Timeout.InfiniteTimeSpan
            Dim response As HttpResponseMessage = Nothing
            If RequestTypet = "Get" Then
                response = SNClient.GetAsync(SNClient.BaseAddress).Result
            ElseIf RequestTypet = "Post" Then
                response = SNClient.PostAsync(SNClient.BaseAddress, New StringContent(PostDatat, Encoding.UTF8, ContentTypet)).Result
            End If

            Dim values As JObject = JsonConvert.DeserializeObject(Of JObject)(response.Content.ReadAsStringAsync().Result.ToString)
            Dim Token As String = values.GetValue(TokenJsonKey).ToString

            Domain = ""

            ' PUT and POST request required data to be posted
            If (RequestType.Equals("POST", StringComparison.InvariantCultureIgnoreCase) Or RequestType.Equals("PUT", StringComparison.InvariantCultureIgnoreCase)) AndAlso String.IsNullOrEmpty(PostData) Then
                Throw New ArgumentNullException("PostData", "Post Data is a required field. Please enter information")
            End If

            Try
                If InStr(UserName, "\") Then
                    Domain = UserName.Substring(0, UserName.IndexOf("\"))
                    UserName = UserName.Substring(UserName.IndexOf("\") + 1, Len(UserName) - Len(Domain) - 1)
                End If
            Catch
            End Try


            handler = New HttpClientHandler
            If String.IsNullOrEmpty(Proxy) = False Then
                handler.Proxy = New WebProxy(Proxy)
                handler.UseProxy = True
                handler.Proxy.Credentials = New NetworkCredential(SrcUserName, SrcPassword)
            End If

            handler.UseCookies = False
            SNClient = New HttpClient(handler)

            If UserName <> "" Then
                handler.Credentials = New NetworkCredential(UserName, Password, Domain)
                SNClient.DefaultRequestHeaders.Add("Authorization", "Basic " +
                   Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(UserName + ":" + Password)))
            End If

            If HeaderData IsNot Nothing Then
                Dim headers() As String = HeaderData.Split(New String() {"|x|x|"}, StringSplitOptions.None)
                For Each header As String In headers
                    If header <> "" Then
                        Dim headerFields() As String = header.Split(New String() {"|y|y|"}, StringSplitOptions.None)
                        If headerFields IsNot Nothing Then
                            If headerFields.Length = 2 Then
                                headerFields(1) = Replace(headerFields(1), "<token>", Token, 1,, CompareMethod.Text)
                                SNClient.DefaultRequestHeaders.TryAddWithoutValidation(headerFields(0), headerFields(1))
                            Else
                                SNClient.DefaultRequestHeaders.TryAddWithoutValidation(headerFields(0), "")
                            End If
                        End If
                    End If
                Next
            End If

            SNClient.BaseAddress = New Uri(Url)
            SNClient.Timeout = System.Threading.Timeout.InfiniteTimeSpan
            Dim response2 As HttpResponseMessage = Nothing
            If RequestType = "Get" Then
                response2 = SNClient.GetAsync(SNClient.BaseAddress).Result
            ElseIf RequestType = "Post" Then
                response2 = SNClient.PostAsync(SNClient.BaseAddress, New StringContent(PostData, Encoding.UTF8, ContentType)).Result
            ElseIf RequestType = "Put" Then
                response2 = SNClient.PutAsync(SNClient.BaseAddress, New StringContent(PostData, Encoding.UTF8, ContentType)).Result
            ElseIf RequestType = "Delete" Then
                response2 = SNClient.DeleteAsync(SNClient.BaseAddress).Result
            End If

            Dim _headers As String = response2.Headers.ToString()
            dt.Columns.Add("Body", GetType(String))
            dt.Columns.Add("Headers", GetType(String))
            dt.Columns.Add("Status Code", GetType(Integer))
            dt.Columns.Add("Status Phrase", GetType(String))
            dt.Columns.Add("Request Message", GetType(String))
            dt.Rows.Add(response2.Content.ReadAsStringAsync().Result.ToString, response2.Headers.ToString(), response2.StatusCode, response2.ReasonPhrase, response2.RequestMessage)

            Return GenerateActivityResult(dt)

        End Function



        Public Function ServerCertificateValidationCallback(ByVal sender As Object, ByVal cert As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean

            If myCRTVAL = 1 Then
                Return True
            Else
                Return sslPolicyErrors = System.Net.Security.SslPolicyErrors.None
            End If
        End Function

    End Class

End Namespace