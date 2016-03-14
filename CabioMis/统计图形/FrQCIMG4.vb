Public Class FrQCIMG4
    Private DJWH As String '点击的是什么
    Private zdqsd As Integer '显示字段开始
    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉'")
        GS_bcfbd(dt, 2, ComboBox3)

    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles  ComboBox3.Click
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, ComboBox4)
    End Sub
    Private Sub showl_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles showl.CellEndEdit
        Dim dj As DataTable = DeepCode.DeepDoGridView.ToDataTable(showl)
        showchartmain(dj)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        showsj()
    End Sub
    Private Sub showsj()
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        Dim lb1, lb2 As String
        lb1 = ComboBox1.Text : lb2 = ComboBox2.Text
        Dim zd As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mx='" & lb2 & "' and tb_biaozdinf_biao='tb_x832p'", 1)
        If zd = "" Then
            MsgBox("描叙查询出错") : Return
        End If
        Dim sql As String = "select tb_x832p_num as '批号'," & zd & " as '" & lb2 & "' from vw_x832p "
        Dim pxzd As String = "tb_x832p_jgrq"
        zdqsd = 1
        sql &= " where " & pxzd & "  between '" & tt1 & "' and '" & tt2 & "' and tb_x832p_scdm='" & lb1 & "' order by " & pxzd & " asc "
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(showl, dt, False, False)
        GroupBox1.Text = "查询结果：" & dt.Rows.Count
        DJWH = tt1 & "至" & tt2 & lb1 & lb2
        showchartmain(dt)
    End Sub
    Private Sub showchartmain(ByVal dt As DataTable)
        Dim ys(3) As Color
        ys(0) = Color.Red : ys(1) = Color.Green : ys(2) = Color.Black : ys(3) = Color.Gold
        ShowLine(Chart1, False, dt, DJWH, DataVisualization.Charting.Docking.Top, ys, zdqsd)
    End Sub
    Public Sub ShowLine(ByVal MsChartName As DataVisualization.Charting.Chart, ByVal Show3D As Boolean, ByVal DataTableName As DataTable, ByVal ChartTitle As String, ByVal ChartTitleDock As DataVisualization.Charting.Docking, ByVal colorC() As Color, ByVal SeriesBegin As Integer)
        If DataTableName.Columns.Count < 2 Then
            MsgBox("至少应该有2列") : Return
        End If
        With MsChartName
            .Series.Clear() : .Titles.Clear()
            .DataSource = DataTableName '指定数据源
            .ChartAreas(0).Area3DStyle.Enable3D = Show3D '显示区域3D效果
            .ChartAreas(0).AxisX.Interval = 1
            If DataTableName.Rows.Count > 60 Then
                .ChartAreas(0).AxisX.Interval = 6
            End If
            .Titles.Add(ChartTitle) '标题文字
            ' XY轴坐标的放大
            .ChartAreas(0).CursorX.IsUserEnabled = True
            .ChartAreas(0).CursorX.IsUserSelectionEnabled = True
            .ChartAreas(0).AxisX.ScaleView.Zoomable = True
            .ChartAreas(0).AxisX.ScrollBar.IsPositionedInside = True
            .ChartAreas(0).CursorY.IsUserEnabled = True
            .ChartAreas(0).CursorY.IsUserSelectionEnabled = True
            .ChartAreas(0).AxisY.ScaleView.Zoomable = True
            .ChartAreas(0).AxisY.ScrollBar.IsPositionedInside = True
        End With

        With MsChartName.Legends(0)
            .Enabled = True '确认显示标题
            .Alignment = StringAlignment.Center '标题对齐图的方式
            .TitleForeColor = Color.Black '颜色
            .TitleAlignment = StringAlignment.Center '文字对齐方式
            .TitleSeparator = DataVisualization.Charting.LegendSeparatorStyle.Line '分割样式
            .TitleSeparatorColor = Color.Black
            .Docking = ChartTitleDock '相对图的停靠方式
        End With

        For i As Integer = SeriesBegin To DataTableName.Columns.Count - 1
            MsChartName.Series.Add(DataTableName.Columns(i).Caption)
            With MsChartName.Series(i - SeriesBegin)
                .ChartType = DataVisualization.Charting.SeriesChartType.Line '折线图
                .BorderWidth = 3 '线粗细
                .ShadowOffset = 2 '阴影
                .Color = colorC(i - SeriesBegin)
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle '点的形状
                .MarkerSize = 5 '点大小
                .MarkerColor = Color.Gold '点的颜色
                .IsValueShownAsLabel = True '显示点的值
                .XValueMember = DataTableName.Columns(0).Caption '指定横坐标字段
                .XValueType = DataVisualization.Charting.ChartValueType.Auto '指定坐标类型
                .YValueMembers = DataTableName.Columns(i).Caption '指定纵坐标字段
            End With
        Next
        MsChartName.Update() '这句话很重要，才能显示下面的tooltip
        '显示下面的各个点的tooltip为DataTableName0列的值
        For i As Integer = 0 To MsChartName.Series.Count - 1
            For j As Integer = 0 To MsChartName.Series(i).Points.Count - 1
                MsChartName.Series(i).Points(j).ToolTip = DataTableName.Rows(j)(0)
            Next
        Next

    End Sub
    Private Sub FrQCIMG4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select tb_bhlb_mc from tb_bhlb")
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, "select tb_cpdmhz_cpdm from tb_cpdmhz where tb_cpdmhz_cpxz like '%成品粉%' group by tb_cpdmhz_cpdm")
        dt = Frcgdhbb.dtshow(dt, dt2)
        Call GS_wlbktlr2(ComboBox1, dt, 0, "")
        ComboBox2.SelectedIndex = 0
        wz()
    End Sub
    Private Sub wz()
        GroupBox1.Width = Me.Width - GroupBox1.Left - 5
        With Chart1
            .Left = GroupBox1.Left
            .Width = GroupBox1.Width
            .Height = Me.Height - .Top - 30
        End With
    End Sub

    Private Sub FrQCIMG_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        wz()
    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub
    Private Sub ToExcelImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub

    Private Sub Chart1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseDoubleClick
        If sender.Dock <> DockStyle.Fill Then
            sender.Dock = DockStyle.Fill
        Else
            sender.Dock = DockStyle.None
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        showsj2()
    End Sub
    Private Sub showsj2()
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        Dim lb1, lb2, lb3 As String
        lb1 = ComboBox3.Text : lb2 = ComboBox4.Text : lb3 = ComboBox5.Text
        Dim zd As String = DeepCode.DeepDoDataTable.GF_cnwithen(_D.G_zdinf, "tb_biaozdinf_mx='" & lb3 & "' and tb_biaozdinf_biao='tb_x832p'", 1)
        If zd = "" Then
            MsgBox("描叙查询出错") : Return
        End If
        Dim sql As String = "select tb_x832p_num as '批号'," & zd & " as '" & lb3 & "' from vw_x832p "
        Dim pxzd As String = "tb_x832p_jgrq"
        zdqsd = 1
        sql &= " where " & pxzd & "  between '" & tt1 & "' and '" & tt2 & "' and tb_x832p_mingc='" & lb1 & "' and tb_x832p_jiagdm='" & lb2 & "' order by " & pxzd & " asc "
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GS_DataGridViewbyDb(showl, dt, False, False)
        GroupBox1.Text = "查询结果：" & dt.Rows.Count
        DJWH = tt1 & "至" & tt2 & lb1 & lb2
        showchartmain(dt)
    End Sub

End Class