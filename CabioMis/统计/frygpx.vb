Public Class frygpx

    Private Sub frygpx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian1) : Call GS_niansl(nian2)
        yue1.Text = Format(Now, "MM") : yue2.Text = yue1.Text '将月份显示为带前导零的数字
        'Call showGrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call showGrid()
    End Sub
    Private Sub showGrid()
        Dim sj1 As String = nian1.Text & "-" & yue1.Text & "-1"
        Dim ts As Integer = Date.DaysInMonth(nian2.Text, yue2.Text)
        Dim sj2 As String = nian2.Text & "-" & yue2.Text & "-" & ts & " 23:59:59"
        'MsgBox(sj1 & sj2)
        Dim sql As String
        sql = "select tb_ygpxda_rq,tb_ygpxda_jssj,tb_ygpxda_dd,tb_ygpxda_js,tb_ygpxda_kc,tb_ygpxda_kd,tb_ygpxda_pxlb, count(*) AS '人数',sum(tb_ygpxda_kd) as '总培训时数（H）' "
        sql = sql & " from tb_ygpxda where tb_ygpxda_rq between '" & sj1 & "' and '" & sj2 & "' "
        sql = sql & "GROUP BY tb_ygpxda_rq,tb_ygpxda_jssj,tb_ygpxda_dd,tb_ygpxda_js,tb_ygpxda_kc,tb_ygpxda_kd,tb_ygpxda_pxlb"
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        With db1
            .Columns.Add("是否审核", GetType(String))
            Dim sjt As Integer = .Rows.Count
            If sjt = 0 Then
                Return
            End If

            Dim t As Integer = .Columns.Count - 1
            For i As Integer = 0 To sjt - 1
                Dim sql2 As String = ""
                sql2 = "select tb_ygpxda_ID  "
                sql2 = sql2 & "from tb_ygpxda "
                sql2 = sql2 & "where tb_ygpxda_rq='" & .Rows(i)(0) & "' and tb_ygpxda_jssj='" & .Rows(i)(1) & "'  and  tb_ygpxda_dd='" & .Rows(i)(2) & "' and tb_ygpxda_js='" & .Rows(i)(3) & "' and tb_ygpxda_kc='" & .Rows(i)(4) & "' and tb_ygpxda_kd=" & .Rows(i)(5) & " and tb_ygpxda_pxlb='" & .Rows(i)(6) & "' "
                sql2 = sql2 & " and tb_ygpxda_qcsh='否'"
                Dim dttemp As DataTable = GF_CreateDataSource(G_cnnstr, sql2)

                If dttemp.Rows.Count > 0 Then
                    .Rows(i)(t) = "否"
                Else
                    .Rows(i)(t) = "是"
                End If

            Next
        End With
        Call GS_useviewbydb2(ListView1, db1, -1, 110)
        Label9.Text = "(共" & Me.ListView1.Items.Count & "条记录)"
        '设置行高
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '分别是宽和高
        ListView1.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Dim aa As New frygpx2
        Me.AddOwnedForm(aa)
        aa.ShowDialog()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian1.Text & "年" & yue1.Text & "月至" & nian2.Text & "年" & yue2.Text & "月员工培训统计", Me)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("未审核记录") : Return
        End If
        If MsgBox("确定审核该记录吗?", 1, "提示") <> 1 Then
            Return
        End If
        If GF_storelog1("修改CABIO员工培训档案") = False Then
            Exit Sub
        End If ' 判断是否有权限
        With ListView1.SelectedItems(0)
            Dim sql As String = "update tb_ygpxda set tb_ygpxda_qcsh='是'"
            sql = sql & "where tb_ygpxda_rq='" & .SubItems(0).Text & "' and tb_ygpxda_jssj='" & .SubItems(1).Text & "'  and  tb_ygpxda_dd='" & .SubItems(2).Text & "' and tb_ygpxda_js='" & .SubItems(3).Text & "' and tb_ygpxda_kc='" & .SubItems(4).Text & "' and tb_ygpxda_kd=" & .SubItems(5).Text & "  and tb_ygpxda_pxlb='" & .SubItems(6).Text & "'"
            GS_upztxx(G_cnnstr, sql)
            Dim zfx As String = "培训开始时间" & .SubItems(0).Text & "，培训结束时间，" & .SubItems(1).Text
            GS_storelog3("修改CABIO员工培训档案：" & zfx, "修改CABIO员工培训档案") '储存到日志
        End With
       
        showGrid()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim wb As String = TextBox1.Text.Trim
        Dim zd As String = ComboBox1.Text
        If wb = "" Or zd = "" Then
            Return
        End If
        With ListView1
            If .Items.Count = 0 Then
                Return
            End If
            Dim kk As DataTable = ListviewToDatatable(ListView1)
            'Dim kk As DataTable = DeepCode.DeepDoGridView.ToDataTable(showl, 0, .Rows.Count - 1)
            Dim jg As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(kk, zd & " like '%" & wb & "%'")
            Call GS_useviewbydb2(ListView1, jg, -1, 110)
        End With
    End Sub
End Class