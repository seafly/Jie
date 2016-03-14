Public Class frtb_cpkczbcx

    '初始化
    Private Sub frtb_cpkczbcx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        'Me.nian1.Text = Date.Today.Year
        'Me.yue1.Text = "0" & Date.Today.Month
        GS_niansl(nian1)
        GS_wlbktlr(yue1, Date.Today.Month, 1, 12)
        'weizhi()
        'showkczb()
    End Sub
    '生成excel
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub
    '关闭
    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub
    ''初始化位置
    'Private Sub weizhi()
    '    GroupBox1.Width = Me.Width - GroupBox1.Left - 5
    '    showl.Width = GroupBox1.Width
    '    showl.Height = Me.Height - showl.Top - 40
    'End Sub
    '显示出查询结果
    Private Sub showkczb()
        Dim cpkcdt As Data.DataTable = GF_CreateDataSource(G_cnnstr, "select tb_cpkczb_ID as [id],tb_cpkczb_rq as [日期],tb_cpkczb_coil as [Crude Oil (kg)],tb_cpkczb_foil as [Finished Oil (kg)],tb_cpkczb_toil as [Toll Oil(Kg)],tb_cpkczb_Powder as [Powder(kg)], tb_cpkczb_gaa as [Gold-AA (kg)],tb_cpkczb_sum as [Sum( As 40% AA)] from tb_cpkczb where datepart(year,tb_cpkczb_rq)=" & nian1.Text & " and datepart(month,tb_cpkczb_rq)=" & yue1.Text & " order by tb_cpkczb_ID desc")
        GS_DataGridViewbyDb(showl, cpkcdt, "0", False, True)
        '            ''''''''''''''''''''''下面显示图形
        cpkcdt.Columns.RemoveAt(0)
        Dim ys(5) As Color
        ys(0) = Color.Blue : ys(1) = Color.Red : ys(2) = Color.Black : ys(3) = Color.Green : ys(4) = Color.Gold : ys(5) = Color.Yellow
        ClassDeepChart.G_Chart_ShowLine(Chart1, DataVisualization.Charting.SeriesChartType.Line, False, cpkcdt, nian1.Text & "-" & yue1.Text & "成品库存周报", DataVisualization.Charting.Docking.Top, ys)

    End Sub
    '添加
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim nform As New frtb_cpkczb
        nform.ShowDialog()
        showkczb()
    End Sub
    '查询
    Private Sub Buttsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttsearch.Click
        showkczb()
    End Sub
    '删除
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Me.showl.SelectedRows.Count = 0 Then
            MsgBox("请选择一条记录再点击删除") : Exit Sub
        End If
        If MsgBox("你确定删除本条记录吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''''''''''''''''''''''
        If GF_storelog1("删除成品库存周报") = False Then
            Exit Sub
        End If ' 判断是否有权限
        GS_upztxx(G_cnnstr, "delete from tb_cpkczb where tb_cpkczb_id=" & Me.showl.SelectedRows(0).Cells(0).Value)
        GS_storelog3("删除成品库存周报：" & Me.showl.SelectedRows(0).Cells(1).Value, "删除成品库存周报") '储存到日志
        showkczb()
    End Sub
    ''月份改变
    'Private Sub yue1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles yue1.SelectedIndexChanged
    '    showkczb()
    'End Sub
    ''年份改变
    'Private Sub nian1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles yue1.SelectedIndexChanged
    '    showkczb()
    'End Sub

    Private Sub ToChartImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub
End Class