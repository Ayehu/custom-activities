Imports Ayehu.Sdk.ActivityCreation.Interfaces
Imports Ayehu.Sdk.ActivityCreation.Extension
Imports System
Imports System.Xml
Imports System.XML.Linq
Imports System.Core
Imports System.Data
Imports System.Text
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Strings

Namespace Ayehu.Sdk.ActivityCreation
	Public Class CustomActivity
	  Implements  IActivity

		'Define the activity's variables.
		Public unixTimestamp As String
		Public dateFormat As String

 		Public Function Execute() As ICustomActivityResult Implements IActivity.Execute
			Dim timestampLength As Integer = Len(unixTimestamp)

			If timestampLength = 10 Then
				unixTimestamp = unixTimestamp & "000"
			End If

			'Insert your PowerShell script within the block below.
			Dim ScriptCode as String = <![CDATA[
				$unixTime = 'unixTimestamp'
				$unixEpochStart = new-object DateTime 1970,1,1,0,0,0,([DateTimeKind]::Utc)
				$utcTimeString = $unixEpochStart.AddMilliSeconds($unixTime)
				$utcTimestamp = Get-Date -Format 'dateFormat' $utcTimeString
				Write-Output $utcTimestamp
			]]>.Value()

			'These lines must be used for each and every variable.
			ScriptCode = ScriptCode.Replace("unixTimestamp", unixTimestamp)
			ScriptCode = ScriptCode.Replace("dateFormat", dateFormat)

			Dim HasParams as Integer = 0
			Dim TableAsString as String = ""

			Dim sw As New StringWriter
			Dim dt As DataTable = New DataTable("resultSet")
			dt.Columns.Add("Result", GetType(String))

			If String.IsNullOrEmpty(ScriptCode) = False Then ScriptCode = ScriptCode.Replace(Chr(10), vbCrLf)

			Dim arr() As String = {}

			Using instance = New PowerShellProcessInstance(New Version(4, 0), Nothing, Nothing, False)
				Using runspace = RunspaceFactory.CreateOutOfProcessRunspace(New TypeTable(arr), instance)
					runspace.Open()

					Using powershellInstance = PowerShell.Create(RunspaceMode.NewRunspace)
						powershellInstance.Runspace = runspace

						Dim pipeline As Pipeline = runspace.CreatePipeline()
						
						If HasParams = 1 AndAlso String.IsNullOrEmpty(TableAsString) = False Then
							Dim param As CommandParameter
							Dim enc As New System.Text.UTF8Encoding()
							Dim stream As New MemoryStream()
							Dim dtParams As New DataTable()
							Dim allBytes() As Byte = enc.GetBytes(TableAsString)
							
							stream.Write(allBytes, 0, allBytes.Length)
							stream.Position = 0
							dtParams.ReadXml(stream)
							
							Dim myCommand As Command = New Command(ScriptCode, True)
							
							For Each row As DataRow In dtParams.Rows
								param = New CommandParameter(row(0), row(1))
								myCommand.Parameters.Add(param)
							Next

							pipeline.Commands.Add(myCommand)
							pipeline.Commands.Add("Out-String")
						Else
							pipeline.Commands.AddScript(ScriptCode)
							pipeline.Commands.Add("Out-String")
						End If
						
						Dim results As Collection(Of PSObject) = pipeline.Invoke()
						runspace.Close()
						Dim stbuilder As StringBuilder = New StringBuilder()
						Dim Result As String = ""
						
						For Each obj As PSObject In results
							Result = ClearString(obj.ToString())
							dt.Rows.Add(Result)
						Next

						runspace.Close()
						runspace.Dispose()
					End Using
				End Using
			End Using

			dt.WriteXml(sw, XmlWriteMode.WriteSchema, False)
			Return Me.GenerateActivityResult(dt)

		End Function

		Function ClearString(Result As String) As String
			Result = Trim(Result)

			Do While Result.StartsWith(vbCrLf)
				Result = Mid(Result, 3, Len(Result))
			Loop

			Do While Result.StartsWith(vbCr)
				Result = Mid(Result, 2, Len(Result))
			Loop

			Do While Result.StartsWith(vbLf)
				Result = Mid(Result, 2, Len(Result))
			Loop

			Do While Result.EndsWith(vbCrLf)
				Result = Mid(Result, 1, Len(Result) - 2)
			Loop

			Do While Result.EndsWith(vbCr)
				Result = Mid(Result, 1, Len(Result) - 1)
			Loop

			Do While Result.EndsWith(vbLf)
				Result = Mid(Result, 1, Len(Result) - 1)
			Loop

			Return Trim(Result)
		End Function
	End Class
End Namespace