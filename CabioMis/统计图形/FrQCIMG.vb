Public Class FrQCIMG
    Private zdqsd As Integer '显示字段开始
    Private sftsbz As Boolean = False '是否进行特殊标注
    Private DJWH As String '点击的是什么
    Private Sub showsj()
        Dim sql As String = ""
        Dim charttitle As String = ""
        Dim pxzd As String = "" '排序字段
        Dim bm As String = ""
        Dim tt1, tt2 As DateTime
        tt1 = DateTimePicker1.Text : tt2 = DateTimePicker2.Text & " 23:59:00"
        If DateDiff(DateInterval.Day, tt1, tt2) < 0 Then
            MsgBox("起时间应当小于等于止时间") : Return
        End If
        Dim ph As String = TextBox1.Text.Trim
        Dim bds2 As String = ""

        Select Case DJWH
            Case "毛油NETAA"
                sql = "select tb_x825p_num,tb_x825p_jgrq,tb_x825p_qaspjg,tb_x825p_d68w as '干菌体Net AA（Kg）',tb_x825p_mynetaa as '毛油Net AA' from tb_x825p  "
                zdqsd = 3
                bm = "tb_x825p"
                bds2 = " and " & bm & "_num like '%" & ph & "%'"
                pxzd = bm & "_jgrq"
                sql &= " where " & pxzd & "  between '" & tt1 & "' and '" & tt2 & "' " & bds2 & "   order by " & pxzd & " asc "
                sftsbz = True
            Case "成品油NETAA"
                sql = "select  tb_h195z_num,tb_h195z_jgrq,tb_h195z_qaspjg,tb_h195z_s621k as '投入毛油Net AA（Kg）',tb_h195z_t673l as '成品油Net AA（Kg)' from vw_h195z "
                bm = "tb_h195z"
                bds2 = " and " & bm & "_num like '%" & ph & "%'"
                pxzd = bm & "_jgrq"
                sql &= " where " & pxzd & "  between '" & tt1 & "' and '" & tt2 & "'  " & bds2 & "  order by " & pxzd & " asc "
                zdqsd = 3
                sftsbz = True
            Case "小罐消后"
                sql = "select  tb_y864q_num,tb_y864q_qcrq,tb_y864q_x832p as '氨基氮' ,tb_y864q_f126x as '溶磷' from tb_y864q "
                zdqsd = 2
                bm = "tb_y864q"
                bds2 = " and " & bm & "_num like '%" & ph & "%'"
                pxzd = bm & "_qcrq"
                sql &= " where " & pxzd & "  between '" & tt1 & "' and '" & tt2 & "'  " & bds2 & "  order by " & pxzd & " asc "
                sftsbz = False
            Case "中罐消后"
                sql = "select  tb_f123x_num,tb_f123x_qcrq,tb_f123x_e73w as '氨基氮' ,tb_f123x_x825p as '溶磷' from tb_f123x "
                zdqsd = 2
                bm = "tb_f123x"
                bds2 = " and " & bm & "_num like '%" & ph & "%'"
                pxzd = bm & "_qcrq"
                sql &= " where  tb_f123x_z915s='消后' and " & pxzd & "  between '" & tt1 & "' and '" & tt2 & "'  " & bds2 & "  order by " & pxzd & " asc "
                sftsbz = False
            Case "大罐消后"
                sql = "select  tb_q546i_num,tb_q546i_qcrq,tb_q546i_h209z as '氨基氮' ,tb_q546i_h193z as '溶磷' from tb_q546i "
                zdqsd = 2
                bm = "tb_q546i"
                bds2 = " and " & bm & "_num like '%" & ph & "%'"
                pxzd = bm & "_qcrq"
                sql &= " where   tb_q546i_t651l='消后' and " & pxzd & "  between '" & tt1 & "' and '" & tt2 & "'  " & bds2 & "  order by " & pxzd & " asc"
                sftsbz = False
            Case "烘干指标"
                sql = "select    tb_q546i_num,tb_q546i_t651l,tb_q546i_qcrq,tb_q546i_n448f as '干菌体水份%',tb_q546i_v744n as '干菌体总油%',tb_q546i_f144x as '干菌体AA（%）' from tb_q546i "
                bm = "tb_q546i"
                bds2 = " and " & bm & "_num like '%" & ph & "%'"
                pxzd = bm & "_qcrq"
                sql &= " where  tb_q546i_t651l='烘干'   and " & pxzd & "  between '" & tt1 & "' and '" & tt2 & "'  " & bds2 & "  order by " & pxzd & " asc "
                zdqsd = 3
                sftsbz = False
            Case "放罐指标"
                sql = "select    tb_q546i_num,tb_q546i_t651l,tb_q546i_qcrq,tb_q546i_a941s,tb_q546i_j300c as '生物量（g/100ml)',tb_q546i_x817p as '总油%',tb_q546i_n455g as 'AA（%）' from tb_q546i "
                bm = "tb_q546i"
                bds2 = " and " & bm & "_num like '%" & ph & "%'"
                pxzd = bm & "_qcrq"
                sql &= " where  tb_q546i_t651l='放罐'   and " & pxzd & "  between '" & tt1 & "' and '" & tt2 & "'  " & bds2 & "  order by " & pxzd & " asc "
                zdqsd = 4
                sftsbz = True
        End Select
        Dim dt11 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)

        Dim dt As DataTable = GF_czmctb(dt11, "", pxzd & " asc")
        GS_DataGridViewbyDb(showl, dt, True, True)
        GroupBox1.Text = "查询结果：" & dt11.Rows.Count
        showchartmain(dt)
    End Sub
    Private Sub showchartmain(ByVal dt As DataTable)
        Dim ys(3) As Color
        ys(0) = Color.Red : ys(1) = Color.Green : ys(2) = Color.Violet : ys(3) = Color.Gold
        ShowLine(Chart1, False, dt, DJWH, DataVisualization.Charting.Docking.Top, ys, zdqsd)
        If sftsbz = True Then
            With Chart1
                'For i As Integer = 0 To .Series.Count - 1
                Dim i As Integer = 0
                For j As Integer = 0 To dt.Rows.Count - 1
                    Dim QAJG As String = DeepCode.DeepDoStr.Null2String(dt.Rows(j)(2))

                    If QAJG = "报废" Then
                        'Dim hh As String = .Series(i).Points(j).YValues(0)
                        '.Series(i).Points(j).Label = hh '& "(报废)"
                        .Series(i).Points(j).MarkerColor = Color.Red
                        .Series(i).Points(j).MarkerSize = 10
                    End If

                    If DJWH = "放罐指标" And DeepCode.DeepDoStr.Null2String(dt.Rows(j)(3)) <> "正常" Then
                        'Dim hh As String = .Series(i).Points(j).YValues(0)
                        '.Series(i).Points(j).Label = hh '& "(" & DeepCode.DeepDoStr.Null2String(dt.Rows(j)(3)) & ")"
                        .Series(i).Points(j).MarkerColor = Color.Red
                        .Series(i).Points(j).MarkerSize = 10
                    End If
                Next

                'Next

            End With
        End If

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

    'Private Sub ShowData(ByVal db As DataTable, ByVal charttitle As String, ByVal zdqsd As Integer)
    '    GS_DataGridViewbyDb(showl, db, True, True)

    '    Dim ys(2) As Color
    '    ys(0) = Color.Blue : ys(1) = Color.Green : ys(2) = Color.Black

    '    ShowLine(Chart1, False, db, charttitle, DataVisualization.Charting.Docking.Top, ys, zdqsd)
    '    If sftsbz = True Then
    '        With Chart1
    '            For i As Integer = 0 To .Series.Count - 1
    '                For j As Integer = 0 To db.Rows.Count - 1
    '                    Dim QAJG As String = DeepCode.DeepDoStr.Null2String(dt.Rows(j)(2))
    '                    If QAJG = "报废" Then
    '                        .Series(i).Points(j).Label = "报废"
    '                    End If
    '                    If pxzd = "tb_x832p_jgrq" Then
    '                        Dim eb, jl As String
    '                        eb = DeepCode.DeepDoStr.Null2String(dt.Rows(j)("tb_x832p_h199z"))
    '                        jl = DeepCode.DeepDoStr.Null2String(dt.Rows(j)("tb_x832p_e106x"))
    '                        If eb <> "0/5×10g" Then
    '                            .Series(i).Points(j).Label = .Series(i).Points(j).Label & vbCrLf & "EB:" & eb
    '                        End If
    '                        If jl <> "<10" Then
    '                            .Series(i).Points(j).Label = .Series(i).Points(j).Label & vbCrLf & "菌落总数:" & jl
    '                        End If
    '                    End If
    '                Next

    '            Next

    '        End With
    '    End If

    'End Sub
    Private Sub FrQCIMG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Dim LB As String() = {"毛油NETAA", "成品油NETAA", "小罐消后", "中罐消后", "烘干指标", "大罐消后", "放罐指标"}
        GS_wlbktlr3(ComboBox1, LB, "")
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

    Private Sub FrQCIMG_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub
    Private Sub showl_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles showl.CellEndEdit
        Dim dj As DataTable = DeepCode.DeepDoGridView.ToDataTable(showl)
        showchartmain(dj)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DJWH = ComboBox1.Text
        showsj()
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

    Private Sub Chart1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseDoubleClick
        If sender.Dock <> DockStyle.Fill Then
            sender.Dock = DockStyle.Fill
        Else
            sender.Dock = DockStyle.None
        End If
    End Sub
End Class