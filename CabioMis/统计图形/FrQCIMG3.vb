Public Class FrQCIMG3
    Private DJWH As String '点击的是什么
    Private Sub FrQCIMG3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim LB As String() = {"小罐PH&C", "中罐PH&C", "大罐PH&C", "放罐QC"}
        GS_wlbktlr3(ComboBox1, LB, "")
        wz()
    End Sub
    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub

    Private Sub ToExcelImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub
    Private Sub wz()
        GroupBox1.Width = Me.Width - GroupBox1.Left - 5
        Dim h As Integer = 0
        With Chart1
            .Left = GroupBox1.Left
            .Width = GroupBox1.Width
            .Height = Me.Height - .Top - 20
        End With

    End Sub

    Private Sub FrQCIMG3_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ph As String = TextBox1.Text.Trim
        If ph = "" Then
            Return
        End If
        DJWH = ComboBox1.Text
        Dim sql As String = ""
        Select Case DJWH
            Case "小罐PH&C"
                sql = "select tb_y864q_w777o,tb_y864q_num as '小罐批号','' as '中罐批号','' as '大罐批号',tb_y864q_qcrq,tb_y864q_p516h as '无菌样情况' ,tb_y864q_g176y as '发酵PH值',tb_y864q_d68w as '糖' from tb_y864q where tb_y864q_num='" & ph & "' order by tb_y864q_qcrq asc"

            Case "中罐PH&C"
                sql = "select tb_f123x_z915s,'' as '小罐批号',tb_f123x_num as '中罐批号','' as '大罐批号',tb_f123x_qcrq,tb_f123x_d35v as '无菌样情况',tb_f123x_x834p as '发酵PH值',tb_f123x_b969t  as '糖' from tb_f123x  where tb_f123x_num='" & ph & "' order by tb_f123x_qcrq asc"

            Case "大罐PH&C"

                sql = "select tb_q546i_t651l,'' as '小罐批号','' as '中罐批号',tb_q546i_num as '大罐批号',tb_q546i_qcrq,tb_q546i_a941s as '无菌样情况',tb_q546i_a935s as '发酵PH值',tb_q546i_r604j  as '糖' from tb_q546i  where tb_q546i_num='" & ph & "' order by tb_q546i_qcrq asc"
            Case "放罐QC"

                sql = "select tb_q546i_t651l,'' as '小罐批号','' as '中罐批号',tb_q546i_num as '大罐批号',tb_q546i_qcrq,tb_q546i_a941s as '无菌样情况',tb_q546i_j300c as '生物量（g/100ml)',tb_q546i_x817p  as '总油%',tb_q546i_n455g  as 'AA（%）'  from tb_q546i  where tb_q546i_num='" & ph & "' and tb_q546i_j300c>0 order by tb_q546i_qcrq asc"
        End Select
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        With dt
            If .Rows.Count = 0 Then
                MsgBox("无符合条件记录")
                Return
            End If
            tcsj(dt) '填充相关批号数据
            GS_DataGridViewbyDb(showl, dt, True, True)
            GroupBox1.Text = "查询结果：" & .Rows.Count & "条数据"
        End With

        showchartmain(dt)
    End Sub
    Private Sub tcsj(ByVal dt As DataTable) '填充相关批号数据
        With dt

            For i As Integer = 0 To .Rows.Count - 1
                Dim sql As String  = "select tb_b970t.tb_b970t_num,tb_b959t.tb_b959t_num,tb_i234a.tb_i234a_num from  tb_b970t,tb_b959t,tb_i234a  "
                sql &= " where  tb_b959t.tb_b959t_num2=tb_b970t.tb_b970t_num  and tb_b959t.tb_b959t_num=tb_i234a.tb_i234a_num2"
                Dim dbs = ""
                Select Case DJWH
                    Case "小罐PH&C"
                        Dim ph As String = .Rows(i)("小罐批号")
                        dbs = " and tb_b970t.tb_b970t_num='" & ph & "'"
                        'Dim sql1 As String = "select tb_b959t_num from tb_b959t  where tb_b959t_num2='" & ph & "'"
                        'Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql1)
                        'Dim ph1 As String = dt1.Rows(0)(0)
                        'Dim sql2 As String = "select tb_i234a_num from tb_i234a  where tb_i234a_num2='" & ph1 & "'"
                        'Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql2)
                        'Dim ph2 As String = dt2.Rows(0)(0)
                        '.Rows(i)("中罐批号") = ph1 : .Rows(i)("大罐批号") = ph2
                    Case "中罐PH&C"
                        Dim ph As String = .Rows(i)("中罐批号")
                        dbs = " and tb_b959t.tb_b959t_num='" & ph & "'"
                        'Dim sql1 As String = "select tb_b959t_num2 from tb_b959t  where tb_b959t_num='" & ph & "'"
                        'Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql1)
                        'Dim ph1 As String = dt1.Rows(0)(0)
                        'Dim sql2 As String = "select tb_i234a_num from tb_i234a  where tb_i234a_num2='" & ph1 & "'"
                        'Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql2)
                        'Dim ph2 As String = dt2.Rows(0)(0)
                        '.Rows(i)("小罐批号") = ph1 : .Rows(i)("大罐批号") = ph2
                    Case "大罐PH&C", "放罐QC"
                        Dim ph As String = .Rows(i)("大罐批号")
                        dbs = " and tb_i234a.tb_i234a_num='" & ph & "'"
                        'Dim sql1 As String = "select tb_i234a_num2 from tb_i234a  where tb_i234a_num='" & ph & "'"
                        'Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql1)
                        'Dim ph1 As String = dt1.Rows(0)(0)
                        'Dim sql2 As String = "select tb_b959t_num2 from tb_b959t  where tb_b959t_num='" & ph1 & "'"
                        'Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql2)
                        'Dim ph2 As String = dt2.Rows(0)(0)
                        '.Rows(i)("中罐批号") = ph1 : .Rows(i)("小罐批号") = ph2
                End Select

                sql &= dbs
                Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                .Rows(i)("小罐批号") = dt1.Rows(0)(0) : .Rows(i)("中罐批号") = dt1.Rows(0)(1) : .Rows(i)("大罐批号") = dt1.Rows(0)(2)
            Next

        End With

    End Sub
    Private Sub showchartmain(ByVal dt As DataTable)
        Dim ys(2) As Color
        ys(0) = Color.Red : ys(1) = Color.Green : ys(2) = Color.Black
        ShowLine(Chart1, False, dt, DJWH, DataVisualization.Charting.Docking.Top, ys, 6)

        With Chart1
            For i As Integer = 0 To .Series.Count - 1
                For j As Integer = 0 To dt.Rows.Count - 1
                    Dim QAJG As String = DeepCode.DeepDoStr.Null2String(dt.Rows(j)("无菌样情况"))
                    If QAJG = "染菌" Then
                        'Dim hh As String = .Series(i).Points(j).YValues(0)
                        '.Series(i).Points(j).Label = hh & "(染菌)"
                        .Series(i).Points(j).MarkerColor = Color.Red
                        .Series(i).Points(j).MarkerSize = 10
                    End If
                Next

            Next

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
    Private Sub showl_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles showl.CellEndEdit
        Dim dj As DataTable = DeepCode.DeepDoGridView.ToDataTable(showl)
        showchartmain(dj)
    End Sub

    Private Sub Chart1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseDoubleClick
        If sender.Dock <> DockStyle.Fill Then
            sender.Dock = DockStyle.Fill
        Else
            sender.Dock = DockStyle.None
        End If
    End Sub
End Class