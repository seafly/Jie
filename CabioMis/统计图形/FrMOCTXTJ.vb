Public Class FrMOCTXTJ
    'Private zxl As String
    Private Sub FrMOCTXTJ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_niansl(ComboBox1)
        Dim LB As String() = {"类别统计", "发生区域统计", "MOC申请人", "MOC负责人"}
        GS_wlbktlr3(ComboBox2, LB, "")
    End Sub

    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        Dim n As Integer = ComboBox1.Text
        Dim dj As DataTable = GF_GetMonthDb()
        Dim datedb As DataTable = GF_GetCountDateTb(n, 26, False) '生成一个统计年度的月份起止的日期DB，参数代表年，统计日起，是否加入时分秒
        '''''''''''''''''''''''''''''''''''''''
        Dim l() As String = Nothing
        Dim cxzd As String = "" '查询字段
        Dim sjq, sjz As String '时间起止
        sjq = datedb.Rows(0)(0) : sjz = datedb.Rows(11)(1)
        Select Case ComboBox2.Text
            Case "类别统计"
                l = G_MOCLB : cxzd = "tb_tz_gd"
            Case "发生区域统计"
                cxzd = "tb_tz_fsqy"
                l = gettjsz(cxzd, sjq, sjz)
            Case "MOC申请人"
                cxzd = "tb_tz_ggsqr"
                l = gettjsz(cxzd, sjq, sjz)
            Case "MOC负责人"
                cxzd = "tb_tz_ggfzr"
                l = gettjsz(cxzd, sjq, sjz)
        End Select
        If l.Length = 0 Then
            MsgBox("未找到类别或者时间段内无数据") : Return
        End If

        'Dim allsj As String = ""
        With dj
            For q As Integer = 0 To UBound(l)
                'Dim zsj As String = ""
                Dim lb As String = l(q)
                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                Dim dr As DataRow = .NewRow
                Dim hj As Double = 0
                dr(0) = q + 1 : dr(1) = l(q)
                '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                For i As Integer = 0 To datedb.Rows.Count - 1
                    Dim tt1, tt2 As String
                    tt1 = datedb.Rows(i)(0) : tt2 = datedb.Rows(i)(1)
                    Dim sql As String = "select count(*) from tb_tz where tb_tz_rq between '" & tt1 & "' and '" & tt2 & "'"
                    sql &= " and " & cxzd & "='" & lb & "'"
                    Dim dt11 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                    'zsj &= dt11.Rows(0)(0) & ","
                    hj += dt11.Rows(0)(0)
                    dr(2 + i) = dt11.Rows(0)(0)
                Next
                'zsj = DeepCode.DeepDoStr.GF_removedh(zsj)
                'allsj &= zsj & ","
                '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                dr(14) = hj
                .Rows.Add(dr)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim k As DataRow = .NewRow
            k(0) = dj.Rows.Count + 1 : k(1) = "Total"

            For i As Integer = 2 To 14
                k(i) = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dj, i, 0, dj.Rows.Count - 1)
            Next
            .Rows.Add(k)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End With
        showl.DataSource = dj
        showchart(dj)

        '''''''''''''''''''''''''''''''''


    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub

    'Private Sub ToExcelImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If zxl = "" Then
    '        MsgBox("图形导出只针对类别统计,请先进行类别统计再导出") : Return
    '    End If
    '    MsgBox("可能得一段时间产生报表，请耐心等待")
    '    Dim zfc As String = "a4,"
    '    For i As Integer = 0 To UBound(G_MOCLB)
    '        zfc &= GF_GetExcelSerByX("b", "m", 6 + i) & ","
    '    Next
    '    zfc = DeepCode.DeepDoStr.GF_removedh(zfc)
    '    Dim zbxl As String = zfc
    '    GS_FillExcel(Application.StartupPath() & "\Template\MOC清单.xls", zbxl, zxl, Me)
    'End Sub
    '返回查询到分组的分类数组
    Private Function gettjsz(ByVal strcxzd As String, ByVal TimeBegin As String, ByVal TimeEnd As String) As String()
        Dim sql As String = "select " & strcxzd & " from tb_tz where tb_tz_rq between '" & TimeBegin & "' and '" & TimeEnd & "'  group by " & strcxzd & ""
        Dim zfc As String = GF_getstringsql(G_cnnstr, sql, "")
        Return zfc.Split(",")
    End Function
    Private Sub showchart(ByVal dj As DataTable)
        If ComboBox2.Text = "类别统计" Then
            Dim ys(4) As Color
            ys(0) = Color.Blue : ys(1) = Color.Red : ys(2) = Color.Yellow : ys(3) = Color.Gold : ys(4) = Color.Green


            ClassDeepChart.G_Chart_ShowColumn(Chart1, False, dj, "MOC  Summary(" & ComboBox2.Text & ")  " & ComboBox1.Text, DataVisualization.Charting.Docking.Bottom, Color.Blue, ys, 2, dj.Columns.Count - 2, 0, dj.Rows.Count - 2)
        End If

    End Sub

    Private Sub showl_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles showl.CellEndEdit
        Dim dj As DataTable = DeepCode.DeepDoGridView.ToDataTable(showl)
        showchart(dj)
    End Sub
    Private Sub ToChartImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub
End Class