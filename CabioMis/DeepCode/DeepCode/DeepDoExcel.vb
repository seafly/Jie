
Public Class DeepDoExcel
'Excel.Selection.NumberFormatLocal   =   "@"     是设置文本格   
'Excel.Selection.NumberFormatLocal   =   "0.00%"百分比   
'Excel.Selection.NumberFormatLocal   =   "yyyy-m-d"日期   
'Excel.Selection.NumberFormatLocal   =   "h:mm;@"时间   
'Excel.Selection.NumberFormatLocal   =   "0.00_   "数值
'Excel.Selection.NumberFormatLocal   =   "G/通用格式"   
    Dim xlApp, xlbook, xlsheet As Object, lpath As String
    Dim isTem As Boolean '是否使用模板
    '参数代表是否显示界面和文件保存的路径
    Sub New(ByVal ShowUI As Boolean, ByVal SavePath As String)
        lpath = SavePath
        isTem = False
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
        isTem = True
        xlApp = CreateObject("Excel.Application")
        xlApp.DisplayAlerts = False '显示警告
        xlApp.Application.Visible = ShowUI '显示界面
        xlbook = xlApp.Workbooks.Open(lpath)
        xlsheet = xlbook.Sheets(1)
    End Sub
    '使用DataTable填充EXCEL，，0代表纵坐标，1代表横坐标,1代表填充的值
    Public Sub FillAt(ByVal SXY As DataTable) '生成EXCEL，带合并单元格的
        With SXY
            For I As Integer = 0 To .Rows.Count - 1
                Dim range1 As Object = Nothing
                range1 = xlsheet.Range(.Rows(I)(0), .Rows(I)(0))
                range1.Select()
                range1.value2 = .Rows(I)(1)
            Next
        End With
    End Sub
    '使用DataTable创建EXCEL，代表在EXCEL何处写第一行Stitle代表第一行是否合并单元格（即第一行的内容），如果为空则不合并,结果值为EXCEL创建完毕后该工作表下一行的开始行号
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
            If isTem = False Then '使用非模板创建时候使用格式
                range1.NumberFormatLocal = "@" '文本模式
                range1.ColumnWidth = SWidth  '宽度
                range1.WrapText = True '自动换行
            End If

            ''''''''''''''
            For i = 0 To str.Rows.Count - 1
                m = 0
                For j = 0 To str.Columns.Count - 1
                    Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                    range1 = xlsheet.Range(lb)
                    range1.value2 = Null2String(str.Rows(i)(j))
                    m = m + 1
                Next
            Next
            CreateByDataTable = i + StartHere + 2
            range1 = Nothing

        Catch ex As Exception
            CreateByDataTable = 0
        End Try

    End Function
    '使用DataTable创建EXCEL，代表在EXCEL何处写第一行,数据类型按照DataTable定义
    Public Function CreateByDataTable2(ByVal str As DataTable, ByVal SWidth As Integer, ByVal STitle As String, ByVal StartHere As Integer) As Integer '生成EXCEL，带合并单元格的
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
                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’构建标题字段
                Dim lb As String = getabc(m + 1) & (StartHere + 1)
                range1 = xlsheet.Range(lb)
                range1.value2 = str.Columns(j).Caption
                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
                Dim lb2 As String = getabc(m + 1) & (StartHere + 2)
                Dim lb3 As String = getabc(m + 1) & (str.Rows.Count + StartHere + 1)
                Dim range11 As Object = Nothing
                range11 = xlsheet.Range(lb3, lb2)
                range11.Select()
                If isTem = False Then '使用非模板创建时候使用格式
                    range11.ColumnWidth = SWidth  '宽度

                    'Debug.WriteLine(str.Columns(j).DataType.ToString & " :" & lb3 & "-" & lb2)
                    Select Case str.Columns(j).DataType.ToString
                        Case "System.Int16", "System.Int32", "System.Int64"
                            range11.NumberFormatLocal = "0" '
                        Case "System.Decimal", "System.Double", "System.Single" '浮点数保留2位小数
                            range11.NumberFormatLocal = "0.00_   " '
                        Case "System.DateTime" '浮点数保留2位小数
                            range11.NumberFormatLocal = "yyyy-m-d h:mm;@" '日期
                        Case Else
                            range11.NumberFormatLocal = "@" '文本模式
                            range11.WrapText = True '自动换行
                    End Select
                End If
                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                m = m + 1

            Next

            ''''''''''''''
            For i = 0 To str.Rows.Count - 1 '填充
                m = 0
                For j = 0 To str.Columns.Count - 1
                    Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                    range1 = xlsheet.Range(lb)
                    range1.value2 = Null2String(str.Rows(i)(j))
                    m = m + 1
                Next
            Next
            CreateByDataTable2 = i + StartHere + 2
            range1 = Nothing

        Catch ex As Exception
            CreateByDataTable2 = 0
        End Try

    End Function
    '使用DataGridView创建EXCEL，代表在EXCEL何处写第一行,数据类型按照DataGridView定义
    Public Function CreateByDataGridView(ByVal str As System.Windows.Forms.DataGridView, ByVal SWidth As Integer, ByVal STitle As String, ByVal StartHere As Integer) As Integer '生成EXCEL，带合并单元格的
        Try
            Dim l1 As Integer = 0
            Dim i, j, m As Integer
            m = str.Columns.Count
            If str.Columns(0).GetType.ToString = "System.Windows.Forms.DataGridViewCheckBoxColumn" Then
                l1 = 1 : m = m - 1
            End If


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
            For j = l1 To str.Columns.Count - 1
                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’构建标题字段
                Dim lb As String = getabc(m + 1) & (StartHere + 1)
                range1 = xlsheet.Range(lb)
                range1.value2 = str.Columns(j).HeaderText
                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
                Dim lb2 As String = getabc(m + 1) & (StartHere + 2)
                Dim lb3 As String = getabc(m + 1) & (str.Rows.Count + StartHere + 1)
                Dim range11 As Object = Nothing
                range11 = xlsheet.Range(lb3, lb2)
                range11.Select()
                If isTem = False Then '使用非模板创建时候使用格式
                    range11.ColumnWidth = SWidth  '宽度
                    'MsgBox(str.Columns(j).ValueType.ToString)
                    'Debug.WriteLine(str.Columns(j).ValueType.ToString & " :" & lb3 & "-" & lb2)
                    Select Case str.Columns(j).ValueType.ToString
                        Case "System.Int16", "System.Int32", "System.Int64"
                            range11.NumberFormatLocal = "0" '
                        Case "System.Decimal", "System.Double", "System.Single" '浮点数保留2位小数
                            range11.NumberFormatLocal = "0.00_   " '
                        Case "System.DateTime" '浮点数保留2位小数
                            range11.NumberFormatLocal = "yyyy-m-d h:mm;@" '日期
                        Case Else
                            range11.NumberFormatLocal = "@" '文本模式
                            range11.WrapText = True '自动换行
                    End Select
                End If

                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                m = m + 1

            Next

            ''''''''''''''
            If l1 = 1 Then '表明是有复选框的'
                Dim z As Integer = 0
                For i = 0 To str.Rows.Count - 1 '填充

                    m = 0
                    Dim k As Windows.Forms.DataGridViewCheckBoxCell = str.Rows(i).Cells(0)
                    If k.Value.ToString = "True" Then
                        For j = l1 To str.Columns.Count - 1
                            Dim lb As String = getabc(m + 1) & (z + StartHere + 2).ToString
                            range1 = xlsheet.Range(lb)

                            range1.value2 = Null2String(str.Rows(i).Cells(j).Value)
                            m = m + 1

                        Next
                        z += 1
                    End If

                Next
                range1 = Nothing
                Return z + StartHere + 2

            Else
                For i = 0 To str.Rows.Count - 1 '填充
                    m = 0
                    For j = l1 To str.Columns.Count - 1
                        Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                        range1 = xlsheet.Range(lb)

                        range1.value2 = Null2String(str.Rows(i).Cells(j).Value)
                        m = m + 1
                    Next
                Next
                range1 = Nothing
                Return i + StartHere + 2

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try

    End Function
    '把DBNull值转换为""
    Private Function Null2String(ByVal str) As String
        If str Is DBNull.Value Then
            Null2String = ""
        Else
            Null2String = str
        End If
    End Function
    '使用模板使用DataTable创建EXCEL,StartHere参数表示从模板的何处写第一行
    Public Function DoWithPanel(ByVal str As DataTable, ByVal StartHere As Integer) As Integer
        Try
            Dim i, j, m As Integer
            m = 0
            For j = 0 To str.Columns.Count - 1
                m = m + 1
            Next
            Dim lbc As String = getabc(m) & StartHere.ToString
            Dim range1 As Object = Nothing
            StartHere = StartHere - 1
            m = 0

            For j = 0 To str.Columns.Count - 1
                Dim lb As String = getabc(m + 1) & (StartHere + 1)
                range1 = xlsheet.Range(lb)
                range1.value2 = str.Columns(j).Caption
                m = m + 1
            Next

            '''''''''''
            range1 = xlsheet.Range("A" & (str.Rows.Count + StartHere + 1), lbc)
            range1.Select()
            range1.NumberFormatLocal = "@" '文本模式

            range1.WrapText = True '自动换行
            ''''''''''''''
            For i = 0 To str.Rows.Count - 1
                m = 0
                For j = 0 To str.Columns.Count - 1

                    Dim lb As String = getabc(m + 1) & (i + StartHere + 2).ToString
                    range1 = xlsheet.Range(lb)
                    range1.value2 = Null2String(str.Rows(i)(j))
                    m = m + 1
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
    '使用LISTVIEW创建EXCEL，代表在EXCEL何处写第一行,宽度为0的不显示，带复选框的只是显示选中的行
    Public Function CreateByListview(ByVal str As Windows.Forms.ListView, ByVal SWidth As Integer, ByVal STitle As String, ByVal StartHere As Integer) As Integer '生成EXCEL，带合并单元格的
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
    
    Protected Overrides Sub Finalize()
        xlsheet.SaveAs(lpath)
        xlsheet = Nothing : xlbook = Nothing : xlApp.quit()
        Dim jcdh As Integer = System.GC.GetGeneration(xlApp)
        xlApp = Nothing

        System.GC.Collect(jcdh)
        MyBase.Finalize()
    End Sub
End Class
