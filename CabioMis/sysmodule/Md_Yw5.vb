Module Md_Yw5
    '填充电子表格，TemplatePath模板路径，XYSer坐标序列，DataSer值序列
    Public Sub GS_FillExcel(ByVal TemplatePath As String, ByVal XYSer As String, ByVal DataSer As String, ByVal FormName As Form)
        If XYSer = "" Then
            Return
        End If
        Dim cc As New DataTable
        cc.Columns.Add("x", GetType(String))
        cc.Columns.Add("y", GetType(String))
        Dim n1() As String = XYSer.Split(",")
        Dim n2() As String = DataSer.Split(",")
        If UBound(n1) <> UBound(n2) Then
            MsgBox("坐标序列与值序列不对应！") : Return
        End If
        For i As Integer = 0 To UBound(n1)
            Dim n As DataRow = cc.NewRow
            n(0) = n1(i) : n(1) = n2(i)
            cc.Rows.Add(n)
        Next
        ''''''''''''''''''''''''''''''''''
        Dim dhk As New SaveFileDialog
        dhk.Filter = "EXCEL电子表格|*.XLS"
        If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        Dim wjm As String = dhk.FileName : dhk = Nothing
        If wjm = "" Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''''''''''''
        Dim jj As New DeepCode.DeepDoExcel(True, wjm, TemplatePath)
        jj.FillAt(cc)
        Dim jcdh As Integer = System.GC.GetGeneration(jj) : jj = Nothing : System.GC.Collect(jcdh)
        MsgBox("生成电子表格完毕！")
        FormName.TopMost = False
        System.Diagnostics.Process.Start(wjm)
    End Sub
    '生成一个统计年度的月份起止的日期DB，参数代表年，统计日起，是否加入时分秒
    Public Function GF_GetCountDateTb(ByVal NYear As Integer, ByVal NDayBegin As Integer, ByVal WithHMS As Boolean) As DataTable
        Dim L As String = ""
        If WithHMS = True Then
            L = " 23:59:59"
        Else
            L = ""
        End If
        Dim NDayEnd As Integer = NDayBegin - 1
        Dim cc As New DataTable
        cc.Columns.Add("DATEBEGIN", GetType(String))
        cc.Columns.Add("DATEEND", GetType(String))
        Dim n As DataRow = cc.NewRow
        n(0) = (NYear - 1).ToString & "-12-" & NDayBegin.ToString : n(1) = NYear.ToString & "-1-" & NDayEnd.ToString & L
        cc.Rows.Add(n)
        For i As Integer = 1 To 11
            Dim n1 As DataRow = cc.NewRow
            n1(0) = NYear.ToString & "-" & i.ToString & "-" & NDayBegin.ToString : n1(1) = NYear.ToString & "-" & (i + 1).ToString & "-" & NDayEnd.ToString & L
            cc.Rows.Add(n1)
        Next
        Return cc
    End Function
    '得到EXCEL的横坐标序列，横坐标起点值，横坐标止点值，纵坐标值
    '如：GF_GetExcelSerByX("d", "g", 9)="D9,E9,F9,G9"
    Public Function GF_GetExcelSerByX(ByVal NXBegin As String, ByVal NXEnd As String, ByVal NY As Integer) As String
        NXBegin = UCase(NXBegin) : NXEnd = UCase(NXEnd)
        Dim n1 As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim q As Integer = InStr(n1, NXBegin)
        Dim r As Integer = InStr(n1, NXEnd)
        Dim zfc As String = ""
        For i As Integer = q To r
            Dim m1 As String
            m1 = Mid(n1, i, 1) & NY.ToString
            zfc &= m1 & ","
        Next
        Return Microsoft.VisualBasic.Left(zfc, Len(zfc) - 1)
    End Function
    Public Function GF_GetMonthDb() As DataTable
        Dim kk() As String = {"NO.", "Category", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "Total"}
        Dim n As New DataTable
        For i As Integer = 0 To UBound(kk)
            Dim l As String = kk(i)
            Select Case l
                Case "Category"
                    n.Columns.Add(l, GetType(String))
                Case Else
                    n.Columns.Add(l, GetType(Double))
            End Select
        Next
        Return n
    End Function
End Module
