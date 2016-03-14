Imports Microsoft.Office.Interop.Excel
Public Class Class1
    Public Function createexcelbylist(ByVal str As ListView, ByVal kd As Integer, ByVal sbt As String, ByVal lpath As String) As Boolean '生成EXCEL，带合并单元格的
        Try
            'kd代表宽度,sbt 代表合并的标题
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlbook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlsheet As Microsoft.Office.Interop.Excel.Worksheet
            xlApp = CType(CreateObject("Excel.Application"), Application)
            xlApp.DisplayAlerts = False '显示警告
            xlApp.Application.Visible = True '显示界面
            xlApp.WorkBooks.add()
            xlbook = xlApp.ActiveWorkBook
            xlsheet = CType(xlbook.Sheets(1), Worksheet)
            ' On Error Resume Next
            Dim i, j, m As Integer
            m = 0
            For j = 0 To str.Columns.Count - 1
                If str.Columns(j).Width > 0 Then
                    m = m + 1
                End If
            Next
            Dim lbc As String = getabc(m) & "1"
            Dim range1 As Microsoft.Office.Interop.Excel.Range  = xlsheet.Range("A1", lbc)
            range1.Select()
            range1.Merge(False)
            range1.NumberFormatLocal = "@" '文本模式
            range1.RowHeight = 37.5 '高度
            range1.HorizontalAlignment = 3        '水平居中
            range1.VerticalAlignment = 2 '垂直居中2,垂直底部对齐3，垂直顶端对齐１
            range1.value2 = sbt
            m = 0
            For j = 0 To str.Columns.Count - 1
                If str.Columns(j).Width > 0 Then
                    Dim lb As String = getabc(m + 1) & "2"
                    range1 = xlsheet.Range(lb)
                    range1.NumberFormatLocal = "@"
                    range1.ColumnWidth = kd
                    range1.value2 = str.Columns(j).Text

                    m = m + 1
                End If
            Next
            If str.CheckBoxes = True Then '如果是有复选框的
                For i = 0 To str.CheckedItems.Count - 1
                    m = 0
                    For j = 0 To str.Columns.Count - 1
                        If str.Columns(j).Width > 0 Then
                            Dim lb As String = getabc(m + 1) & (i + 3).ToString
                            range1 = xlsheet.Range(lb)
                            range1.NumberFormatLocal = "@" '文本模式
                            range1.ColumnWidth = kd '宽度
                            ' range1.RowHeight = 37.5 '高度
                            ' range1.VerticalAlignment = 2 '垂直居中
                            range1.WrapText = True '自动换行
                            range1.value2 = str.CheckedItems(i).SubItems(j).Text
                            m = m + 1
                        End If
                    Next
                Next
            Else '如果是无复选框的显示全部子项
                For i = 0 To str.Items.Count - 1
                    m = 0
                    For j = 0 To str.Columns.Count - 1
                        If str.Columns(j).Width > 0 Then
                            Dim lb As String = getabc(m + 1) & (i + 3).ToString
                            range1 = xlsheet.Range(lb)
                            range1.NumberFormatLocal = "@" '文本模式
                            range1.ColumnWidth = kd '宽度
                            ' range1.RowHeight = 37.5 '高度
                            '  range1.VerticalAlignment = 2 '垂直居中
                            range1.WrapText = True '自动换行
                            range1.value2 = str.Items(i).SubItems(j).Text
                            m = m + 1
                        End If
                    Next
                Next
            End If
            xlsheet.SaveAs(lpath)
            range1 = Nothing
            xlsheet = Nothing : xlbook = Nothing : xlApp.quit()
            Dim jcdh As Integer = System.GC.GetGeneration(xlApp)
            xlApp = Nothing
            System.GC.Collect(jcdh)
            createexcelbylist = True
        Catch ex As Exception
            createexcelbylist = False
        End Try
    End Function
    '下面函数是为了计算EXCEL的列标
    Private Function getabc(ByVal str As Integer) As String
        Dim n1 As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim BB As String = ""
        If str <= 26 Then
            BB = Mid(n1, str, 1)
        Else
            Dim BS As Integer = CInt(Int(str / 26))
            Dim YS As Integer = str Mod 26
            If YS > 0 Then
                BB = Mid(n1, BS, 1)
                BB = BB & Mid(n1, YS, 1)
            Else
                BB = Mid(n1, BS - 1, 1)
                BB = BB & "Z"
            End If
        End If
        getabc = BB
    End Function
End Class
