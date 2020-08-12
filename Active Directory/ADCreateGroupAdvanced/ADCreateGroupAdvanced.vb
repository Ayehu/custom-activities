Imports Ayehu.Sdk.ActivityCreation.Interfaces
Imports Ayehu.Sdk.ActivityCreation.Extension
Imports System.Text
Imports System.DirectoryServices
Imports System.IO
Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Net

Namespace Ayehu.Sdk.ActivityCreation
    Public Class ActivityClass
        Implements IActivity


        Private Const DefaultAdPort As String = "389"
        Private Const ADS_GROUP_TYPE_GLOBAL_GROUP = &H2
        Private Const ADS_GROUP_TYPE_DOMAIN_LOCAL_GROUP = &H4
        Private Const ADS_GROUP_TYPE_UNIVERSAL_GROUP = &H8
        Private Const ADS_GROUP_TYPE_SECURITY_ENABLED = &H80000000
        Public HostName As String
        Public Description As String
        Public Notes As String
        Public ManagedBy As String
        Public Scope As String = "Global"
        Public AdType As String = "Security"
        Public UserName As String
        Public Password As String
        Public ADUserName As String
        Public Path As String
        Public SecurePort As String

        Public Function Execute() As ICustomActivityResult Implements IActivity.Execute

            Dim dt As DataTable = New DataTable("resultSet")
            dt.Columns.Add("Result", GetType(String))

            If String.IsNullOrEmpty(SecurePort) = True Then
                SecurePort = DefaultAdPort
            End If

            If IsNumeric(SecurePort) = False Then
                Dim msg As String = "Port parameter must be a number"
                Throw New ApplicationException(msg)
            End If

            Dim de As DirectoryEntry = GetAdEntry(HostName, SecurePort, UserName, Password)


            If LCase(Path).Contains("cn=") OrElse LCase(Path).Contains("ou=") Then
            Else
                Path = Path.Replace("/", "\")
                Path = Trim(Path)
                If Path.Contains("\") Then
                    If Path.StartsWith("\") Then Path = "ou=" & Path.Substring(1)
                    Path = Path.Replace("\", ",ou=")
                End If
                If Path.StartsWith("ou=") = False Then Path = "ou=" & Path


                If LCase(Path).StartsWith("ou=users") Or LCase(Path).StartsWith("ou=builtin") Or LCase(Path).StartsWith("ou=microsoft exchange system objects") Or LCase(Path).StartsWith("ou=system") Or LCase(Path).StartsWith("ou=program data") Or LCase(Path).StartsWith("ou=managed service accounts") Or LCase(Path).StartsWith("ou=lostandfound") Or LCase(Path).StartsWith("ou=computers") Or LCase(Path).StartsWith("ou=foreignsecurityprincipals") Or LCase(Path).StartsWith("ou=ntds quotas") Then Path = "cn=" & Path.Substring(3)

                Dim TheNewPathBackup = Path
                Try
                    Dim PathStart As String = Path.Substring(0, LCase(Path).IndexOf("ou="))
                    Dim Pathends As String = Path.Substring(LCase(Path).IndexOf("ou="))
                    Dim Myarray As Array = Split(Pathends, ",")
                    Array.Reverse(Myarray)
                    For Each pt As String In Myarray
                        PathStart = PathStart & "," & pt
                    Next
                    Path = PathStart.Replace(",,", ",")
                    If Path.StartsWith(",") Then Path = Path.Substring(1)
                Catch
                    Path = TheNewPathBackup
                End Try
            End If

            Dim ds As DirectorySearcher = New DirectorySearcher(de)
            ds.Filter = "(&(objectClass=group) (sAMAccountName=" + ADUserName + "))"
            ds.SearchScope = SearchScope.Subtree
            Dim results As SearchResult = ds.FindOne()
            If results Is Nothing Then

                'Get Some deafult user in order to get complete path sample
                Dim dq As DirectorySearcher = New DirectorySearcher(de)
                dq.Filter = "(&(objectCategory=person)(objectClass=user))"
                dq.SearchScope = SearchScope.Subtree
                Dim TempUser As SearchResult = dq.FindOne()

                Dim entry As DirectoryEntry
                If LCase(Path) = "ou=" Then
                    entry = GetAdEntryByFullPath(de.Path & "/" & TempUser.Path.Substring(TempUser.Path.IndexOf("DC=")), UserName, Password)
                Else
                    entry = GetAdEntryByFullPath(de.Path & "/" & Path & "," & TempUser.Path.Substring(TempUser.Path.IndexOf("DC=")), UserName, Password)
                End If

                Dim groupType As Integer
                If (Scope = "Global" AndAlso AdType = "Security") Then
                    groupType = ADS_GROUP_TYPE_GLOBAL_GROUP Or ADS_GROUP_TYPE_SECURITY_ENABLED
                ElseIf (Scope = "Global" AndAlso AdType = "Distribution") Then
                    groupType = ADS_GROUP_TYPE_GLOBAL_GROUP
                ElseIf (Scope = "Universal" AndAlso AdType = "Security") Then
                    groupType = ADS_GROUP_TYPE_UNIVERSAL_GROUP Or ADS_GROUP_TYPE_SECURITY_ENABLED
                ElseIf (Scope = "Universal" AndAlso AdType = "Distribution") Then
                    groupType = ADS_GROUP_TYPE_UNIVERSAL_GROUP
                End If

                Dim group As DirectoryEntry = entry.Children.Add("CN=" + ADUserName, "group")
                group.Properties("sAmAccountName").Value = ADUserName
                group.Properties("groupType").Value = groupType
                group.Properties("description").Value = Description
                group.Properties("info").Value = Notes
                group.Properties("managedBy").Value = ManagedBy
                group.CommitChanges()
                group.Close()
                dt.Rows.Add("Success")
            Else
                Throw New Exception("Group already exists")
            End If

            de.Close()

            Return Me.GenerateActivityResult(dt)
        End Function

        Public Function GetAdEntryByFullPath(ByVal path As String, ByVal userName As String, ByVal password As String) As DirectoryEntry
            Dim adEntry = New DirectoryEntry(path, userName, password, AuthenticationTypes.Secure)
            Return adEntry
        End Function

        Public Function GetAdEntry(ByVal domainServer As String, ByVal domainPort As String, ByVal username As String, ByVal password As String) As DirectoryEntry
            Dim defaultAdSecurePort As String = "636"
            If domainPort.Equals(defaultAdSecurePort) AndAlso IsIpAddress(domainServer) Then Throw New Exception("When using a secure port, a server domain name must be defined for the device.")
            Dim domainUrl As String = "LDAP://" & domainServer

            If Not domainPort.Equals(DefaultAdPort) Then
                domainUrl = domainUrl & ":" & domainPort
            End If

            Dim adEntry = New DirectoryEntry(domainUrl, username, password, AuthenticationTypes.Secure)
            Return adEntry
        End Function

        Private Function IsIpAddress(ByVal domainServer As String) As Boolean
            Dim address As IPAddress
            Return IPAddress.TryParse(domainServer, address)
        End Function


    End Class
End Namespace

