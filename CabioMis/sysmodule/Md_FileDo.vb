Imports System.IO
Imports System.Text
Module Md_FileDo
    '外部或文件处理
    '读写文本函数
    Public Function GF_readwrite(ByVal lpath As String, ByVal DOWHAT As String) As String
#If Not Debug Then
        Try
            If DOWHAT = "READ" Then
                Dim sr As New StreamReader(lpath, Encoding.Default)
                Dim rvTxt As String = sr.ReadToEnd()
                sr.Close()
                sr = Nothing
                Return rvTxt
            Else

                Dim fs As New FileStream(lpath, FileMode.Create)
                Dim data As Byte() = System.Text.Encoding.Default.GetBytes(DOWHAT)
                fs.Write(data, 0, data.Length)
                fs.Flush()
                fs.Close()
                Return ""
            End If
        Catch ex As Exception

        End Try
#End If
    End Function

    ''' <summary>
    ''' 对ListView、或DataGridView内容转存为excel
    ''' </summary>
    ''' <param name="lst">数据源</param>
    ''' <param name="excelbt">文件名称</param>
    ''' <param name="xx">窗体</param>
    Public Sub GS_toexcel(ByVal lst As Control, ByVal excelbt As String, ByVal xx As Form)
        Try
            If GF_getListViewsz(lst) = 0 Then
                Exit Sub
            End If
            Dim dhk As New SaveFileDialog
            dhk.Filter = "2007EXCEL电子表格|*.XLSX"
            dhk.Filter &= "|2000-2003EXCEL电子表格|*.XLS"
            If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If
            Dim wjm As String = dhk.FileName : dhk = Nothing
            If wjm = "" Then
                Exit Sub
            End If
            Dim ss As New DeepCode.DeepDoExcel(True, wjm), jj As Integer
            Select Case lst.GetType.ToString
                Case "System.Windows.Forms.ListView"
                    Dim cc As Windows.Forms.ListView = lst
                    jj = ss.CreateByListview(cc, 15, excelbt, 1)
                Case "System.Windows.Forms.DataGridView"
                    Dim cc As Windows.Forms.DataGridView = lst
                    jj = ss.CreateByDataGridView(cc, 15, excelbt, 1)
                Case "yangNetCl.yanDaTaGridView"
                    Dim cc As yangNetCl.yanDaTaGridView = lst
                    jj = ss.CreateByDataGridView(cc, 15, excelbt, 1)
            End Select

            Dim jcdh As Integer = System.GC.GetGeneration(ss) : ss = Nothing : System.GC.Collect(jcdh)
            xx.TopMost = True
            MsgBox("生成电子表格完毕！")
            xx.TopMost = False
            System.Diagnostics.Process.Start(wjm)
        Catch ex As Exception
        End Try

    End Sub
    Public Sub GS_dbtoexcel(ByVal lst As DataTable, ByVal excelbt As String, ByVal xx As Form)
        Try
            If lst.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim dhk As New SaveFileDialog
            dhk.Filter = "2007EXCEL电子表格|*.XLSX"
            dhk.Filter &= "|2000-2003EXCEL电子表格|*.XLS"
            If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If
            Dim wjm As String = dhk.FileName
            dhk = Nothing
            If wjm = "" Then
                Exit Sub
            End If
            Dim ss As New DeepCode.DeepDoExcel(True, wjm), jj As Integer

            jj = ss.CreateByDataTable2(lst, 15, excelbt, 1)

            Dim jcdh As Integer = System.GC.GetGeneration(ss) : ss = Nothing : System.GC.Collect(jcdh)
            xx.TopMost = True
            MsgBox("生成电子表格完毕！")
            xx.TopMost = False
            System.Diagnostics.Process.Start(wjm)
        Catch ex As Exception
        End Try
    End Sub
    '对ListView内容转存为html
    Public Sub GS_tohtml(ByVal lst As ListView, ByVal excelbt As String)
        If GF_getListViewsz(lst) > 0 Then
            Dim htmtop As String = "<html><head><meta http-equiv='Content-Type' content='text/html; charset=gb2312'><title>" & excelbt & "</title></head><body>"
            excelbt = "<div align='center'>" & excelbt & "</div>"
            htmtop = htmtop & excelbt
            Dim dt As DataTable = GF_ListviewToDatatable2(lst, "all")
            htmtop = htmtop & GF_printasweb(dt)
            htmtop = htmtop & "</body></html>"
            Dim dhk As New SaveFileDialog
            dhk.Filter = "网页文件|*.HTML"
            dhk.ShowDialog()
            Dim wjm As String = dhk.FileName
            If wjm <> "" Then
                GF_readwrite(wjm, htmtop)
                MsgBox("生成网页文件完毕！")
            End If
            dhk = Nothing
        End If
    End Sub
    ' 第一个参数 是地址 , 第二个是要读取EXCEL里面的哪个表 "" 代表默认使用[Sheet1$]
    Public Function GF_XlsDataTable(ByVal db1 As String, ByVal tbname As String) As Data.DataTable
        Dim name As String = "[Sheet1$]"
        If tbname <> "" Then
            name = tbname
        End If
        Dim strcnn As String = "provider=Microsoft.Jet.OLEDB.4.0; data source=" & db1 & ";Extended Properties=Excel 8.0;"

        Dim Sql As String = "select * from " & name
        Dim cnn As New OleDb.OleDbConnection(strcnn)
        Dim dt As New DataTable
        Dim adp As New OleDb.OleDbDataAdapter(Sql, cnn)
        adp.Fill(dt)
        adp = Nothing : cnn = Nothing
        GF_XlsDataTable = dt
    End Function
    '以WEB形式显示打印
    Public Function GF_printasweb(ByVal strdb As DataTable) As String
        Try
            Dim tbhead As String = Chr(10) & "<tr align='center' vAlign=top bgColor=#CAE6FF>"
            For i As Integer = 0 To strdb.Columns.Count - 1
                tbhead = tbhead & "<td>" & strdb.Columns(i).Caption & "</td>" & Chr(10)
            Next
            tbhead = tbhead & "</tr>" & vbCrLf
            Dim tbbody As String = ""
            For j As Integer = 0 To strdb.Rows.Count - 1
                tbbody = tbbody & "<tr align='center' valign='middle' bgcolor='#ffffff'>" & Chr(10)
                For i As Integer = 0 To strdb.Columns.Count - 1
                    If strdb.Rows(j)(i) Is DBNull.Value Then
                        tbbody = tbbody & "<td>&nbsp;</td>" & Chr(10)
                    Else
                        tbbody = tbbody & "<td>" & strdb.Rows(j)(i).ToString & "</td>" & Chr(10)
                    End If
                Next
                tbbody = tbbody & "</tr>" & vbCrLf
            Next
            Dim tbhtml As String = Chr(10) & "<table width='95%' border='0' cellpadding='3' cellspacing='1' align='center' sty" _
& "le='font-size: 10pt' bgcolor='#000000' id='mytable'>" & tbhead & tbbody & "</table>"
            GF_printasweb = tbhtml
        Catch ex As Exception
            GF_printasweb = ""
        End Try

    End Function
    '打开帮助
    Public Sub GS_Help(ByVal str As String)
        Dim yhm, mm, sjk, fwq, port As String
        Using sr As IO.StreamReader = New IO.StreamReader(Application.StartupPath() & "\sysconnet.ini")
            yhm = sr.ReadLine() : sjk = sr.ReadLine() : mm = sr.ReadLine() : fwq = sr.ReadLine() : port = sr.ReadLine() : sr.Close()
        End Using
        If fwq = "(local)" Then
            fwq = "127.0.0.1"
        End If
        If port = "" Then
            port = ":80"
        Else
            port = ":" & port
        End If
        Dim bzurl As String = "http://" & fwq & port & "/cabiojs/fso/left2.asp?lj=" & str
        System.Diagnostics.Process.Start("IExplore.exe", bzurl)
    End Sub
    '返回系统特殊目录的路径
    Public Function GF_GetSysPath(ByVal path As Environment.SpecialFolder) As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Function
End Module
