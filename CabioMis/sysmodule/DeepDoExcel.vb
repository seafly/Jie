Public Class DeepDoExcel
    '
    Dim xlApp, xlbook, xlsheet As Object, lpath As String
    '参数代表是否显示界面和文件保存的路径
    Sub New(ByVal ShowUI As Boolean, ByVal SavePath As String)
        lpath = SavePath
        xlApp = CreateObject("Excel.Application")
        xlApp.DisplayAlerts = False '显示警告
        xlApp.Application.Visible = ShowUI '显示界面
        xlApp.WorkBooks.add()
        xlbook = xlApp.ActiveWorkBook
        xlsheet = xlbook.Sheets(1)
    End Sub
    '参数代表是否显示界面和文件保存的路径
    Sub New(ByVal ShowUI As Boolean, ByVal SavePath As String, ByVal PanlePath As String)
        System.IO.File.Copy(PanlePath, SavePath, True)
        lpath = SavePath
        xlApp = CreateObject("Excel.Application")
        xlApp.DisplayAlerts = False '显示警告
        xlApp.Application.Visible = ShowUI '显示界面
        xlbook = xlApp.Workbooks.Open(lpath)
        xlsheet = xlbook.Sheets(1)
    End Sub
    '使用LISTVIEW创建EXCEL，代表在EXCEL何处写第一行,宽度为0的不显示，带复选框的只是显示选中的行
    Public Function CreateByListview(ByVal str As ListView, ByVal SWidth As Integer, ByVal STitle As String, ByVal StartHere As Integer) As Integer '生成EXCEL，带合并单元格的
        Try
            Dim i, j, m As Integer
            m = 0
            For j = 0 To str.Columns.Count - 1
                If str.Columns(j).Width > 0 Then
                    m = m + 1
                End If
            Next
            Dim lbc As String = getabc(m) & StartHere.ToString
            Dim range1 As Object = Nothing
            If STitle = "" Then
                StartHere = StartHere - 1
            Else

                range1 = xlsheet.Range("A" & StartHere.ToString, lbc)
                range1.Select()
                range1.Merge(False)
                range1.NumberFormatLocal = "@" '文本模式
                range1.RowHeight = 37.5 '高度
                range1.HorizontalAlignment = 3        '水平居中
                range1.VerticalAlignment = 2 '垂直居中2,垂直底部对齐3，垂直顶端对齐１
                range1.value2 = STitle
            End If
            m = 0
            For j = 0 To str.Columns.Count - 1
                If str.Columns(j).Width > 0 Then
                    Dim lb As String = getabc(m + 1) & (StartHere + 1)
                    range1 = xlsheet.Range(lb)
                    'range1.NumberFormatLocal = "@"
                    'range1.ColumnWidth = SWidth
                    range1.value2 = str.Columns(j).Text

                    m = m + 1
                End If
            Next
            If str.CheckBoxes = True Then '如果是有复选框的
                '''''''''''
                range1 = xlsheet.Range("A" & (str.Items.Count + StartHere + 1), lbc)
                range1.Select()
                range1.NumberFormatLocal = "@" '文本模式
                range1.ColumnWidth = SWidth  '宽度
                range1.WrapText = True '自动换行
                ''''''''''''''
                For i = 0 To str.CheckedItems.Count - 1
                    m = 0
                    For j = 0 To str.Columns.Count - 1
                        If str.Columns(j).Width > 0 Then
                            Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                            range1 = xlsheet.Range(lb)
                            'range1.NumberFormatLocal = "@" '文本模式
                            'range1.ColumnWidth = SWidth '宽度
                            '' range1.RowHeight = 37.5 '高度
                            '' range1.VerticalAlignment = 2 '垂直居中
                            'range1.WrapText = True '自动换行
                            range1.value2 = str.CheckedItems(i).SubItems(j).Text
                            m = m + 1
                        End If
                    Next
                Next
            Else '如果是无复选框的显示全部子项
                '''''''''''
                range1 = xlsheet.Range("A" & (str.Items.Count + StartHere + 1), lbc)
                range1.Select()
                range1.NumberFormatLocal = "@" '文本模式
                range1.ColumnWidth = SWidth  '宽度
                range1.WrapText = True '自动换行
                ''''''''''''''
                For i = 0 To str.Items.Count - 1
                    m = 0
                    For j = 0 To str.Columns.Count - 1
                        If str.Columns(j).Width > 0 Then
                            Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                            range1 = xlsheet.Range(lb)
                            'range1.NumberFormatLocal = "@" '文本模式
                            'range1.ColumnWidth = SWidth '宽度
                            '' range1.RowHeight = 37.5 '高度
                            ''  range1.VerticalAlignment = 2 '垂直居中
                            'range1.WrapText = True '自动换行
                            range1.value2 = str.Items(i).SubItems(j).Text
                            m = m + 1
                        End If
                    Next
                Next
            End If
            CreateByListview = i + StartHere + 2
            range1 = Nothing

        Catch ex As Exception
            CreateByListview = 0
        End Try

    End Function
    '使用DataTable创建EXCEL，代表在EXCEL何处写第一行
    Public Function CreateByDataTable(ByVal str As DataTable, ByVal SWidth As Integer, ByVal STitle As String, ByVal StartHere As Integer) As Integer '生成EXCEL，带合并单元格的
        Try
            Dim i, j, m As Integer
            m = str.Columns.Count
            Dim lbc As String = getabc(m) & StartHere.ToString
            Dim range1 As Object = Nothing
            If STitle = "" Then
                StartHere = StartHere - 1
            Else
                range1 = xlsheet.Range("A" & StartHere.ToString, lbc)
                range1.Select()
                range1.Merge(False)
                range1.NumberFormatLocal = "@" '文本模式
                range1.RowHeight = 37.5 '高度
                range1.HorizontalAlignment = 3        '水平居中
                range1.VerticalAlignment = 2 '垂直居中2,垂直底部对齐3，垂直顶端对齐１
                range1.value2 = STitle
            End If
            m = 0
            For j = 0 To str.Columns.Count - 1

                Dim lb As String = getabc(m + 1) & (StartHere + 1)
                range1 = xlsheet.Range(lb)
                range1.value2 = str.Columns(j).Caption

                m = m + 1

            Next

            '''''''''''
            '''''''''''
            range1 = xlsheet.Range("A" & (str.Rows.Count + StartHere + 1), lbc)
            range1.Select()
            range1.NumberFormatLocal = "@" '文本模式
            range1.ColumnWidth = SWidth  '宽度
            range1.WrapText = True '自动换行
            ''''''''''''''
            For i = 0 To str.Rows.Count - 1
                m = 0
                For j = 0 To str.Columns.Count - 1
                    Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                    range1 = xlsheet.Range(lb)
                    range1.value2 = Null2String(str.Rows(i)(j).Text)
                    m = m + 1
                Next
            Next
            CreateByDataTable = i + StartHere + 2
            range1 = Nothing

        Catch ex As Exception
            CreateByDataTable = 0
        End Try

    End Function
    '使用模板使用LISTVIEW创建EXCEL,StartHere参数表示从模板的何处写第一行
    Public Function DoWithPanel(ByVal str As ListView, ByVal StartHere As Integer) As Integer
        '使用LISTVIEW创建EXCEL，代表在EXCEL何处写第一行,宽度为0的不显示，带复选框的只是显示选中的行
        Try
            Dim i, j, m As Integer
            m = 0
            For j = 0 To str.Columns.Count - 1
                If str.Columns(j).Width > 0 Then
                    m = m + 1
                End If
            Next
            Dim lbc As String = getabc(m) & StartHere.ToString
            Dim range1 As Object = Nothing
            StartHere = StartHere - 1
            m = 0

            For j = 0 To str.Columns.Count - 1
                If str.Columns(j).Width > 0 Then
                    Dim lb As String = getabc(m + 1) & (StartHere + 1)
                    range1 = xlsheet.Range(lb)
                    'range1.NumberFormatLocal = "@"
                    'range1.ColumnWidth = SWidth
                    range1.value2 = str.Columns(j).Text

                    m = m + 1
                End If
            Next

            '''''''''''
            range1 = xlsheet.Range("A" & (str.Items.Count + StartHere + 1), lbc)
            range1.Select()
            range1.NumberFormatLocal = "@" '文本模式

            range1.WrapText = True '自动换行
            ''''''''''''''
            For i = 0 To str.Items.Count - 1
                m = 0
                For j = 0 To str.Columns.Count - 1
                    If str.Columns(j).Width > 0 Then
                        Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                        range1 = xlsheet.Range(lb)
                        range1.value2 = str.Items(i).SubItems(j).Text
                        m = m + 1
                    End If
                Next
            Next
            DoWithPanel = i + StartHere + 2
            range1 = Nothing

        Catch ex As Exception
            DoWithPanel = 0
        End Try
    End Function
    '下面函数是为了计算EXCEL的列标
    Private Function getabc(ByVal str As Integer) As String
        Dim n1 As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim BB As String = ""
        If str <= 26 Then
            BB = Mid(n1, str, 1)
        Else
            Dim BS As Integer = Int(str / 26)
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

    Protected Overrides Sub Finalize()
        xlsheet.SaveAs(lpath)
        xlsheet = Nothing : xlbook = Nothing : xlApp.quit()
        Dim jcdh As Integer = System.GC.GetGeneration(xlApp)
        xlApp = Nothing

        System.GC.Collect(jcdh)
        MyBase.Finalize()
    End Sub
End Class
