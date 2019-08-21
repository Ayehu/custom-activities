Imports Ayehu.Sdk.ActivityCreation.Interfaces
Imports Ayehu.Sdk.ActivityCreation.Extension
Imports System.Text
Imports System
Imports System.Xml
Imports System.Data
Imports System.IO
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports Syncfusion.XlsIO

Namespace Ayehu.Sdk.ActivityCreation
    Public Class ActivityClass
        Implements IActivity


        Public HostName As String
        Public UserName As String
        Public Password As String
        Public Path As String
        Public ExcelEngine As Object
        Public PreserveTypes As Integer
        Public Sname As String
        Public NewValue As String

        Public Function Execute() As ICustomActivityResult Implements IActivity.Execute


            Dim dt As DataTable = New DataTable("resultSet")
            dt = ReadXLSRemote(HostName, UserName, Password, Path, ExcelEngine, PreserveTypes, Sname, NewValue)
            Return Me.GenerateActivityResult(dt)
        End Function

        Function ReadXLSRemote(ByVal HostName As String, ByVal UserName As String, ByVal Password As String, ByVal Path As String, ExcelEngine As Object, ByVal PreserveTypes As Integer, SheetName As String, SheetTable As String) As DataTable

            Dim dtResult As New DataTable("resultSet")
            dtResult.Columns.Add("Result", GetType(String))
            Try
                SheetTable = Trim(SheetTable)
                If String.IsNullOrEmpty(SheetTable) Then
                    Throw New Exception("Table field must contain a table type variable")
                End If

                Dim ExcelByte() As Byte = Convert.FromBase64String(SheetTable)
                File.WriteAllBytes(Path, ExcelByte)
                dtResult.Rows.Add("Success")
            Catch
                Dim Table As DataTable
                Table = New DataTable()

                Try
                    Dim sr As StringReader = New StringReader(SheetTable)
                    Table.ReadXml(sr)

                Catch ex As Exception
                    Throw New Exception("Table field must contain a table type variable")
                End Try


                Try

                    Dim application As IApplication = ExcelEngine.Excel
                    application.DefaultVersion = ExcelVersion.Excel2010
                    application.UseNativeStorage = False
                    Dim workbook As IWorkbook
                    Dim sheet As IWorksheet

                    If File.Exists(Path) Then
                        workbook = application.Workbooks.Open(Path)

                        If String.IsNullOrEmpty(SheetName) Then
                            sheet = workbook.Worksheets(0)
                        Else
                            sheet = workbook.Worksheets(SheetName)
                        End If

                        If sheet Is Nothing Then
                            workbook.Worksheets.AddCopy(workbook.Worksheets(0))
                            workbook.ActiveSheetIndex = workbook.Worksheets.Count - 1
                            sheet = workbook.Worksheets(workbook.ActiveSheetIndex)
                            sheet.Name = SheetName

                        End If
                    Else
                        workbook = application.Workbooks.Create(1)
                        sheet = workbook.Worksheets(0)
                        If String.IsNullOrEmpty(SheetName) = False Then sheet.Name = SheetName
                    End If







                    Dim prsrvTypes As Boolean = False
                    If PreserveTypes = 1 Then
                        prsrvTypes = True
                    End If

                    sheet.ImportDataTable(Table, True, 1, 1, -1, -1, prsrvTypes)
                    sheet.UsedRange.AutofitRows()
                    sheet.UsedRange.AutofitColumns()


                    workbook.Version = ExcelVersion.Excel2010
                    workbook.SaveAs(Path)
                    workbook.Close()
                    ExcelEngine.ThrowNotSavedOnDestroy = False
                    ExcelEngine.Dispose()
                    dtResult.Rows.Add("Success")
                Catch ex As Exception
                    Throw New Exception("Unable to write excel " + Err.Description)
                End Try
            End Try

            Return dtResult

        End Function


    End Class
End Namespace