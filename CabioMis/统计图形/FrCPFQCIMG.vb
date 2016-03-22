Public Class FrCPFQCIMG
    Private zdqsd As Integer '显示字段开始
    Private Sub FrCPFQCIMG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim LB As String() = {"成品油指标", "毛油指标", "成品粉1号塔", "成品粉34号塔", "成品粉外加工"}
        GS_wlbktlr3(ComboBox1, LB, "")
        wz()
    End Sub
    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub

 
    Private Sub wz()

        GroupBox1.Width = Me.Width - GroupBox1.Left - 5
        Dim h As Integer = 0
        With Chart1
            .Left = GroupBox1.Left
            .Width = GroupBox1.Width
            h = Int((Me.Height - .Top - 10) / 2)
            .Height = h - 10
        End With
        With Chart2
            .Left = GroupBox1.Left
            .Width = GroupBox1.Width
            .Top = h + h - 20
            .Height = Chart1.Height
        End With

    End Sub

    Private Sub FrCPFQCIMG_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub showsj(ByVal str As String)
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        Dim sql As String = ""
        Dim charttitle As String = ""

        Select Case str
            Case "成品油指标"
                sql = "select  tb_h195z_num,tb_h195z_jgrq,tb_h195z_qaspjg,tb_h195z_c6u as 'ARA',tb_h195z_c28u as '过氧化值',tb_h195z_m403e as '酸价' from vw_h195z  where tb_h195z_jgrq between '" & tt1 & "' and '" & tt2 & "'  order by tb_h195z_jgrq  asc"
                charttitle = str
                zdqsd = 4

            Case "毛油指标"
                sql = "select   tb_x825p_num,tb_x825p_jgrq,tb_x825p_qaspjg,tb_x825p_u699m as '过氧化值(meq/Kg)',tb_x825p_t686m as '菌渣残油总油%',tb_x825p_m387e as 'ARA含量',tb_x825p_b959t as '毛油含磷量（ppm）'  from tb_x825p  where tb_x825p_jgrq between '" & tt1 & "' and '" & tt2 & "'order by tb_x825p_jgrq asc"
                charttitle = str
                zdqsd = 5

            Case "成品粉1号塔"
                sql = "select  tb_x832p_num,tb_x832p_cplb,tb_x832p_jgrq,tb_x832p_qaspjg,tb_x832p_h199z,tb_x832p_e106x,tb_x832p_d65v as 'ARA（≥10.0％）',tb_x832p_s624k as '过氧化值',tb_x832p_a948s as '表面油' from vw_x832p "
                sql &= " where tb_x832p_jgrq between '" & tt1 & "' and '" & tt2 & "' and tb_x832p_th='1号塔成品粉'  order by   tb_x832p_jgrq asc "
                charttitle = str
                zdqsd = 7
            Case "成品粉34号塔"
                sql = "select  tb_x832p_num,tb_x832p_cplb,tb_x832p_jgrq,tb_x832p_qaspjg,tb_x832p_h199z,tb_x832p_e106x,tb_x832p_d65v as 'ARA（≥10.0％）',tb_x832p_s624k as '过氧化值',tb_x832p_a948s as '表面油' from vw_x832p "
                sql &= " where tb_x832p_jgrq between '" & tt1 & "' and '" & tt2 & "' and tb_x832p_th='34号塔成品粉'  order by   tb_x832p_jgrq asc "
                charttitle = str
                zdqsd = 7
            Case "成品粉外加工"
                sql = "select  tb_x832p_num,tb_x832p_cplb,tb_x832p_jgrq,tb_x832p_qaspjg,tb_x832p_h199z,tb_x832p_e106x,tb_x832p_d65v as 'ARA（≥10.0％）',tb_x832p_s624k as '过氧化值',tb_x832p_a948s as '表面油' from vw_x832p "
                sql &= " where tb_x832p_jgrq between '" & tt1 & "' and '" & tt2 & "' and   tb_x832p_cplb='APGK'  order by   tb_x832p_jgrq asc "
                charttitle = str
                zdqsd = 7

        End Select
        Dim mydt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        GroupBox1.Text = "查询结果：" & mydt.Rows.Count & "条数据"
        GS_DataGridViewbyDb(showl, mydt, True, False)
        Dim dt0 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        'showl.DataSource = dt
        showchartmain(dt0, charttitle)

    End Sub
    Private Sub showchartmain(ByVal dt11 As DataTable, ByVal charttitle As String)
        showchart(Chart1, dt11, charttitle, zdqsd)
        
        For i As Integer = zdqsd To dt11.Columns.Count - 1
            dt11.Columns.RemoveAt(zdqsd)
        Next
        If ComboBox1.SelectedIndex = 1 Then
            showchart(Chart2, dt11, charttitle, zdqsd - 2)
        Else
            showchart(Chart2, dt11, charttitle, zdqsd - 1)
        End If

        'MsgBox(dt11.Columns.Count)
        'MsgBox(dt0.Columns.Count)
    End Sub
    Private Sub showchart(ByVal MsChartName As DataVisualization.Charting.Chart, ByVal dt As DataTable, ByVal strbt As String, ByVal zdqsd As Integer)
        Dim ys(2) As Color
        ys(0) = Color.Blue : ys(1) = Color.Green : ys(2) = Color.Black
        ShowLine(MsChartName, False, dt, strbt, DataVisualization.Charting.Docking.Top, ys, zdqsd)
        With MsChartName
            'For i As Integer = 0 To .Series.Count - 1
            Dim i As Integer = 0
            For j As Integer = 0 To dt.Rows.Count - 1
                Dim QAJG As String = DeepCode.DeepDoStr.Null2String(dt.Rows(j)(2))
                If QAJG = "报废" Then
                    'Dim hh As String = .Series(i).Points(j).YValues(0)
                    '.Series(i).Points(j).Label = hh & "(报废)"
                    .Series(i).Points(j).MarkerColor = Color.Red
                    .Series(i).Points(j).MarkerSize = 10
                End If
                If InStr(strbt, "成品粉") > 0 Then
                    Dim eb, jl As String
                    eb = DeepCode.DeepDoStr.Null2String(dt.Rows(j)("tb_x832p_h199z"))
                    jl = DeepCode.DeepDoStr.Null2String(dt.Rows(j)("tb_x832p_e106x"))
                    If eb <> "0/5×10g" Then
                        .Series(i).Points(j).Label = .Series(i).Points(j).Label & vbCrLf & "EB:" & eb
                    End If
                    If jl <> "<10" Then
                        .Series(i).Points(j).Label = .Series(i).Points(j).Label & vbCrLf & "菌落总数:" & jl
                    End If
                End If


            Next

            'Next

        End With


    End Sub
    Private Sub ShowLine(ByVal MsChartName As DataVisualization.Charting.Chart, ByVal Show3D As Boolean, ByVal DataTableName As DataTable, ByVal ChartTitle As String, ByVal ChartTitleDock As DataVisualization.Charting.Docking, ByVal colorC() As Color, ByVal SeriesBegin As Integer)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        showsj(ComboBox1.Text)
    End Sub
    Private Sub showl_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles showl.CellEndEdit
        Dim dj As DataTable = DeepCode.DeepDoGridView.ToDataTable(showl)
        showchartmain(dj, ComboBox1.Text)
    End Sub
    Private Sub ToChartImg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg2.Click
        ClassDeepChart.GS_SaveChartImg(Chart2)
    End Sub

    Private Sub ToExcelImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub
    Private Sub Chart1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart1.DoubleClick
        If sender.Dock <> DockStyle.Fill Then
            Chart2.Visible = False
            sender.Dock = DockStyle.Fill
        Else
            Chart2.Visible = True
            sender.Dock = DockStyle.None
        End If
    End Sub
    Private Sub Chart2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart2.DoubleClick
        If sender.Dock <> DockStyle.Fill Then
            Chart1.Visible = False
            sender.Dock = DockStyle.Fill
        Else
            Chart1.Visible = True
            sender.Dock = DockStyle.None
        End If
    End Sub
End Class