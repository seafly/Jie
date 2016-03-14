Imports System.Windows.Forms.DataVisualization.Charting

Public Class Frpctztxtj

    Private Sub Frpctztxtj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_niansl(ComboBox1)
        GS_wlbktlr(ComboBox2, Date.Today.Month, 1, 12)
    End Sub

    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, Me.Text, Me)
    End Sub
    Private Sub ToExcelImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelImg.Click
        GS_toexcel(DataGridView1, Me.Text, Me)
    End Sub
    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        Dim tt1, tt2 As String
        tt1 = ComboBox1.Text & "-" & (ComboBox2.Text - 1) & "-26"
        If ComboBox2.Text = 1 Then
            tt1 = (ComboBox1.Text - 1) & "-12-26"
        End If
        tt2 = ComboBox1.Text & "-" & ComboBox2.Text & "-25"
        '''''''''''''''''''''
        Dim dt0 As New DataTable
        With dt0
            .Columns.Add("序号", GetType(Integer)) : .Columns.Add("部门", GetType(String)) : .Columns.Add("工段", GetType(String))
            .Columns.Add("发现项", GetType(Integer)) : .Columns.Add("完成项", GetType(Integer))
            For i As Integer = 0 To UBound(G_PCLB)
                .Columns.Add(G_PCLB(i), GetType(Integer))
            Next
        End With
        '''''''''''''''''''
        Dim sql As String = "select tb_pctz_bm,tb_pctz_gd,count(*)  from tb_pctz where tb_pctz_rq between '" & tt1 & "' and '" & tt2 & "' group by tb_pctz_bm,tb_pctz_gd order by tb_pctz_bm,tb_pctz_gd"
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
        With dt
            For i As Integer = 0 To .Rows.Count - 1
                Dim bm As String = .Rows(i)(0) : Dim gd As String = DeepCode.DeepDoStr.Null2String(.Rows(i)(1))
                Dim kk As DataRow = dt0.NewRow
                kk(0) = i + 1 : kk(1) = bm : kk(2) = gd : kk(3) = .Rows(i)(2)
                '''''''''''''''''''''''
                Dim sql2 As String = "select count(*) from tb_pctz where tb_pctz_rq between '" & tt1 & "' and '" & tt2 & "' and tb_pctz_bm='" & bm & "' and tb_pctz_gd='" & gd & "'"
                Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql2)

                kk(4) = dt2.Rows(0)(0) '完成项目
                '''''''''''''''''''''
                For j As Integer = 0 To UBound(G_PCLB)
                    Dim sqll As String = "select count(*) from tb_pctz where tb_pctz_rq between '" & tt1 & "' and '" & tt2 & "' and tb_pctz_bm='" & bm & "' and tb_pctz_gd='" & gd & "' and tb_pctz_lb='" & G_PCLB(j) & "'"
                    Dim dttemp As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sqll)
                    Dim n2 As Integer = 0
                    If dttemp.Rows.Count > 0 Then
                        Try

                            n2 = dttemp.Rows(0)(0)
                        Catch ex As Exception

                        End Try

                    End If

                    kk(5 + j) = n2
                Next

                ''''''''''''''''
                dt0.Rows.Add(kk)
            Next
            '''''''''''''''''''''''下面求合计
            Dim zs As Integer = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dt0, 3, 0, dt0.Rows.Count - 1)
            Dim kk1 As DataRow = dt0.NewRow
            kk1(0) = dt0.Rows.Count + 1 : kk1(1) = "合计" : kk1(2) = ""
            '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
            Dim dmchart As New DataTable
            dmchart.Columns.Add("X", GetType(String)) : dmchart.Columns.Add("Y", GetType(Double))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For i As Integer = 3 To dt0.Columns.Count - 1
                Dim b1 As Double = DeepCode.DeepDoDataTable.GF_jsColumnTotal(dt0, i, 0, dt0.Rows.Count - 1)
                kk1(i) = b1
                If i > 4 Then

                    Dim CC As DataRow = dmchart.NewRow
                    CC(0) = dt0.Columns(i).Caption
                    CC(1) = FormatNumber(b1 / zs, 4)
                    dmchart.Rows.Add(CC)
                End If
            Next
            dt0.Rows.Add(kk1)
            ''''''''''''''''
            showl.DataSource = dt0
            GS_ysgx(showl) '求和最后一行颜色更新‘
            showchart(dmchart)
        End With
        ''''''''''''''''''''''''''''''''''
        scbb1() '按照月份统计
    End Sub
    Sub showchart(ByVal dmchart As DataTable)
        ''''''''''''''''''''''下面显示图形
        ClassDeepChart.G_Chart_ShowLine(Chart1, DataVisualization.Charting.SeriesChartType.Pie, True, dmchart, ComboBox1.Text & "-" & ComboBox2.Text & "偏差数据", DataVisualization.Charting.Docking.Top)
        With Chart1
            .Series(0)("PieLabelStyle") = "Outside"
            .Series(0).LabelFormat = "P3"
            .Series(0).Points(0)("Exploded") = "True"
        End With
    End Sub

    Private Sub scbb1()
        Dim l() As String = G_PCLB
        Dim n As Integer = ComboBox1.Text
        Dim dj As DataTable = GF_GetMonthDb()
        Dim datedb As DataTable = GF_GetCountDateTb(n, 26, False) '生成一个统计年度的月份起止的日期DB，参数代表年，统计日起，是否加入时分秒
        With dj
            For q As Integer = 0 To UBound(l)
                Dim lb As String = l(q)
                '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                Dim dr As DataRow = .NewRow
                Dim hj As Double = 0
                dr(0) = q + 1 : dr(1) = l(q)
                '‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
                For i As Integer = 0 To datedb.Rows.Count - 1
                    Dim tt1, tt2 As String
                    tt1 = datedb.Rows(i)(0) : tt2 = datedb.Rows(i)(1)
                    Dim sql As String = "select count(*) from tb_pctz where tb_pctz_rq between '" & tt1 & "' and '" & tt2 & "'"
                    sql &= " and tb_pctz_lb='" & lb & "'"
                    Dim dt11 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql)
                    hj += dt11.Rows(0)(0)
                    dr(2 + i) = dt11.Rows(0)(0)
                Next
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
        '''''''''''''''''''''''''''''''''
        DataGridView1.DataSource = dj
        GS_ysgx(DataGridView1) '求和最后一行颜色更新
    End Sub

    Private Sub Chart1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseDoubleClick
        If sender.Dock <> DockStyle.Fill Then
            sender.Dock = DockStyle.Fill
        Else
            sender.Dock = DockStyle.None
        End If
    End Sub
    Private Sub Chart1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Chart1.MouseDown
        ' Call Hit Test Method
        Dim result As HitTestResult = Chart1.HitTest(e.X, e.Y)

        ' Check if data point is already exploded
        Dim exploded As Boolean = False
        Try
            If Chart1.Series(0).Points(result.PointIndex).CustomProperties = "Exploded=true" Then
                exploded = True
            Else
                exploded = False
            End If
        Catch ex As Exception

        End Try

        ' Remove all exploded attributes
        Dim point As DataPoint
        For Each point In Chart1.Series(0).Points
            point.CustomProperties = ""
        Next point

        ' If data point is already exploded get out.
        If exploded Then
            Return
        End If
        ' If data point is selected
        If result.ChartElementType = ChartElementType.DataPoint Then
            ' Set Attribute
            point = Chart1.Series(0).Points(result.PointIndex)
            point.CustomProperties = "Exploded = true"
        End If

        ' If legend item is selected
        If result.ChartElementType = ChartElementType.LegendItem Then
            ' Set Attribute
            point = Chart1.Series(0).Points(result.PointIndex)
            point.CustomProperties = "Exploded = true"
        End If
    End Sub 'Chart1_MouseDown


    Private Sub ButtonSAVEIMG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSAVEIMG.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub
End Class