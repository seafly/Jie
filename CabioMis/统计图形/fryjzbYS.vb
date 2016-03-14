'************************************************************************************************
'*窗体名称：fryjzbYS
'*功    能：油剂生产周报
'*编 写 者：yangshuai
'*编写日期
'*邮    箱：shuaigoplay@yahoo.com.cn
'*输    入：
'*输    出：excel文件
'*修 改 者：
'*修改日期：
'*备    注：
'************************************************************************************************
Public Class fryjzbYS
    Private ylbdb As DataTable '查询结果供图形使用
    Private Sub fryjzbYS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        wz()
        Call GS_niansl(nian1)
        yue1.Text = Format(DateAdd("m", -1, Now), "MM") '显示上月的月份
    End Sub

    '********************************************************************************************
    '*函数名称：getYJSCZBdatatable
    '*功    能：生成油剂生产周报数据的datatable
    '*编 写 者：yangshuai
    '*编写日期
    '*邮    箱：shuaigoplay@yahoo.com.cn
    '*输    入：monthStr as string :月份字符串，由多个月份组成每个月份以“,”隔开
    '*输    出：油剂生产周报数据的datatable
    '*修 改 者：
    '*修改日期：
    '*备    注：
    '********************************************************************************************
    Public Function getYJSCZBdatatable(ByVal monthStr As String) As Data.DataTable
        Dim dt As New Data.DataTable()
        Dim monthArr() As String  '分解月份字符串的数组
        Dim tmpMonthLow As String '临时低位日期
        Dim tmpMonthhigh As String '临时高位日期
        Dim cnn As New Data.OleDb.OleDbConnection(G_cnnstr)
        Dim myread As New Data.OleDb.OleDbCommand()
        Dim rs As Data.OleDb.OleDbDataReader
        '添加datatable列开始
        dt.Columns.Add("时间起", GetType(String))
        dt.Columns.Add("时间止", GetType(String))
        dt.Columns.Add("放罐止罐号", GetType(String)) '放罐止罐号为该时间段内，最后一个时间的放罐的批号,注意这里以放罐时间为区间
        dt.Columns.Add("Harvest", GetType(String)) '放罐总批数,注意这里以放罐时间为区间
        dt.Columns.Add("Contaminate", GetType(String)) ''QC放罐为染菌的批数,注意这里以大罐QC时间为区间
        dt.Columns.Add("Harvest Net AA", GetType(String)) ''不为报废的毛油批其NETAA平均值，不平均0值,注意这里以放罐时间为区间
        'dt.Columns.Add("Contaminate rate", Type.GetType("System.String"))
        dt.Columns.Add("毛油止批号", GetType(String)) '毛油止罐号为该时间段内，最后一个时间的毛油的批号,注意这里以毛油产出时间为区间
        dt.Columns.Add("毛油浸出罐数", GetType(Integer)) '注意这里以毛油产出时间为区间
        dt.Columns.Add("Crude oil", GetType(Double)) '注意这里以毛油产出时间为区间
        dt.Columns.Add("报废毛油", GetType(Double)) '以QA审批结果报废为标识，注意这里以毛油产出时间为区间
        dt.Columns.Add("Batch yield", GetType(String)) '单批毛油产量,不为报废的毛油量除以不为报废的批数，注意这里以毛油产出时间为区间
        dt.Columns.Add("毛油ARA含量", GetType(Double)) '‘ARA含量平均值，不平均0值，注意这里以毛油产出时间为区间
        dt.Columns.Add("Extraction yield rate%", GetType(Double)) '浸出收率，注意这里以毛油产出时间为区间
        dt.Columns.Add("成品油止批号", GetType(String)) '成品油止罐号为该时间段内，最后一个时间的成品油的批号，注意这里以成品产出日期为区间
        dt.Columns.Add("成品油产出批数", GetType(Integer)) '成品油产出批数为该时间段内，批数合计，注意这里以成品产出日期为区间
        dt.Columns.Add("Input Crude oil", GetType(String)) '成品油周批数，注意这里以成品产出日期为区间
        dt.Columns.Add("Finished  Oil", GetType(String)) '成品油产量，注意这里以成品产出日期为区间
        dt.Columns.Add("报废成品油", GetType(String)) '以QA审批结果报废为标识，，注意这里以成品产出日期为区间
        dt.Columns.Add("成品油ARA含量", GetType(Double)) ''成品油ARA含量，ARA含量平均值，不平均0值，注意这里以成品产出日期为区间
        dt.Columns.Add("Oil Yield(weight)rate%", GetType(String)) '精炼收率,'成品油收率平均值，不平均0值，注意这里以成品产出日期为区间
        dt.Columns.Add("Yield(AA) rate%", GetType(String)) '成品油AA收率平均值，不平均0值，注意这里以成品产出日期为区间
        dt.Columns.Add("单批成品油产量", GetType(Double)) '不为报废的成品油量除以不为报废的批数，注意这里以成品产出日期为区间
        '添加datatable列结束
        cnn.Open()
        myread.Connection = cnn
        monthArr = Split(monthStr, ",")
        For i As Integer = 2 To monthArr.Length Step 2
            Dim dataRow As Data.DataRow
            Dim index As Integer = 0
            dataRow = dt.NewRow()
            tmpMonthLow = monthArr(i - 2)
            tmpMonthhigh = monthArr(i - 1)
            dataRow(0) = tmpMonthLow
            dataRow(1) = tmpMonthhigh
            tmpMonthhigh &= " 23:59:59"
            '''''''''''''''''''''''''''''''''''''''''''''''''''放罐止罐号为该时间段内，最后一个时间的放罐的批号
            myread.CommandText = "select top 1  tb_x825p_num3 from tb_x825p where tb_x825p_jgrq2 between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' order by tb_x825p_jgrq2 desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("放罐止罐号") = rs(0)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''放罐总批数
            myread.CommandText = "select count(*) from tb_x825p where tb_x825p_jgrq2 between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Harvest") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''QC放罐为染菌的批数
            myread.CommandText = "select count(*) from tb_q546i where tb_q546i_qcrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and  tb_q546i_a941s='染菌' and tb_q546i_t651l='放罐'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Contaminate") = rs(0) ' '染菌数
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''不为报废的毛油批其NETAA平均值，不平均0值,注意这里以放罐时间为区间
            myread.CommandText = "select  avg(tb_x825p_k317c) from tb_x825p where tb_x825p_jgrq2 between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and  tb_x825p_qaspjg<>'报废' and tb_x825p_k317c>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Harvest Net AA") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''毛油止批号
            myread.CommandText = "select top 1  tb_x825p_num from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' order by tb_x825p_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("毛油止批号") = rs(0)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''毛油总批数与总重量
            myread.CommandText = "select count(*), sum(tb_x825p_s640k) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("毛油浸出罐数") = rs(0)
                dataRow("Crude oil") = rs(1)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''报废毛油
            myread.CommandText = "select  sum(tb_x825p_s640k) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and  tb_x825p_qaspjg='报废'"
            rs = myread.ExecuteReader
            If rs.Read Then
          
                dataRow("报废毛油") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''不为报废的毛油量除以不为报废的批数
            myread.CommandText = "select  count(*), sum(tb_x825p_s640k) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and  tb_x825p_qaspjg<>'报废'"
            rs = myread.ExecuteReader
            If rs.Read Then
                Try
                    dataRow("Batch yield") = FormatNumber(rs(1) / rs(0), 2)
                Catch ex As Exception
                    dataRow("Batch yield") = 0
                End Try

            End If
            rs.Close()
            '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘ARA含量平均值，不平均0值

            myread.CommandText = "select avg(tb_x825p_m387e) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_x825p_m387e>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("毛油ARA含量") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()

            ''''''''''''''''''''''''''''''''''''''''毛油收率平均值，不平均0值
            myread.CommandText = "select avg(tb_x825p_sn) from tb_x825p where tb_x825p_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_x825p_sn>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Extraction yield rate%") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
    
            '''''''''''''''''''''''''''''''''''''''''''''''''''成品油成品油止批号
            myread.CommandText = "select top 1  tb_h195z_num from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' order by tb_h195z_jgrq desc "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("成品油止批号") = rs(0)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            myread.CommandText = "select sum(tb_h195z_n426f),sum(tb_h195z_m408e),count(*) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' "
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Input Crude oil") = DeepCode.DeepDoStr.Null2zero(rs(0)) '毛油投入量/每成品批（Kg）
                dataRow("Finished  Oil") = DeepCode.DeepDoStr.Null2zero(rs(1)) '成品油产量
                dataRow("成品油产出批数") = DeepCode.DeepDoStr.Null2zero(rs(2))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''报废成品油
            myread.CommandText = "select sum(tb_h195z_m408e) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "' and tb_h195z_qaspjg='报废'"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("报废成品油") = DeepCode.DeepDoStr.Null2zero(rs(0))
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''成品油ARA含量，ARA含量平均值，不平均0值
            myread.CommandText = "select avg(tb_h195z_c6u) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_h195z_c6u>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("成品油ARA含量") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''成品油收率平均值，不平均0值
            myread.CommandText = "select avg(tb_h195z_u704m) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_h195z_u704m>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Oil Yield(weight)rate%") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''成品油AA收率收率平均值，不平均0值
            myread.CommandText = "select avg(tb_h195z_q554i) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and tb_h195z_q554i>0"
            rs = myread.ExecuteReader
            If rs.Read Then
                dataRow("Yield(AA) rate%") = FormatNumber(DeepCode.DeepDoStr.Null2zero(rs(0)), 2)
            End If
            rs.Close()
            ''''''''''''''''''''''''''''''''不为报废的成品油量除以不为报废的批数
            myread.CommandText = "select   count(*), sum(tb_h195z_m408e) from vw_h195z where tb_h195z_jgrq between '" & tmpMonthLow & "' and '" & tmpMonthhigh & "'  and  tb_h195z_qaspjg<>'报废'"
            rs = myread.ExecuteReader
            If rs.Read Then
                Try
                    dataRow("单批成品油产量") = FormatNumber(rs(1) / rs(0), 2)
                Catch ex As Exception
                    dataRow("单批成品油产量") = 0
                End Try

            End If
            rs.Close()
            '’‘’‘’‘
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim j1 As Double = Null2zero(dataRow(2))

            'Try
            '    If j1 = 0 Then
            '        dataRow("Contaminate rate") = 0
            '    Else
            '        dataRow("Contaminate rate") = Format(dataRow("Contaminate") / dataRow("Harvest"), "0.00%")
            '    End If

            'Catch ex As Exception
            '    dataRow("Contaminate rate") = 0
            'End Try

            '''''''''''''''''''''''''
  
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dt.Rows.Add(dataRow)
        Next
        'ylbdb = dt
        Dim aaRow As DataRow = dt.NewRow()
        aaRow(0) = "Total"
        For i As Integer = 3 To dt.Columns.Count - 1
            Dim m As Double = 0
            Try
                m = FormatNumber(GF_jsColumnTotal(dt, i, 0, dt.Rows.Count - 1), 2)
            Catch ex As Exception

            End Try
            aaRow(i) = m

        Next
        dt.Rows.Add(aaRow)
        'Monthly Plan
        'aaRow = dt.NewRow()
        'aaRow(0) = "Monthly Plan"
        'aaRow(2) = "Monthly Plan"
        'dt.Rows.Add(aaRow)

        getYJSCZBdatatable = dt
    End Function
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
    Private Sub wz()

        ListView1.Width = Me.Width - ListView1.Left - 10
        Dim kd As Integer = Int(Me.Width / 2)
        Panel1.Width = kd
        Panel1.Height = Me.Height - Panel1.Top - 30
        'MsgBox(Chart1.Height)
        Panel2.Left = Panel1.Width + Panel1.Left
        Panel2.Width = Me.Width - Panel2.Left
        Panel2.Height = Panel1.Height
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim monthStr As String = GF_Time2Week(CDate(nian1.Text & "-" & yue1.Text))
        Dim dt As Data.DataTable = getYJSCZBdatatable(monthStr)
        ylbdb = dt.Copy()
        GS_DataGridViewbyDb(ListView1, dt, True, True)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ys(4) As Color
        ys(0) = Color.Red : ys(1) = Color.Green : ys(2) = Color.Pink : ys(3) = Color.Gold : ys(4) = Color.Blue
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        ylbdb.Columns.RemoveAt(0)
        ylbdb.Columns.RemoveAt(ylbdb.Columns.Count - 1)
        ShowLine(Chart2, False, ylbdb, "成品油平均指标(周)", DataVisualization.Charting.Docking.Top, ys, ylbdb.Columns.Count - 3)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        DeepDoDataTable.DelDataColAtIndex(ylbdb, "1,2,5,6,7,8,12,13,14,15,16,17,18,19")
        ShowLine(Chart1, False, ylbdb, "毛油平均指标(周)", DataVisualization.Charting.Docking.Top, ys, 1)
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        'GS_dbtoexcel(ylbdb, GroupBox1.Text, Me)
        GS_toexcel(ListView1, GroupBox1.Text, Me)
    End Sub
    Private Sub Buttonunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonunload.Click
        Me.Close()
    End Sub

    Private Sub fryjzbYS_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub ToChartImg2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg2.Click
        ClassDeepChart.GS_SaveChartImg(Chart2)
    End Sub

    Private Sub ToExcelImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToChartImg.Click
        ClassDeepChart.GS_SaveChartImg(Chart1)
    End Sub
End Class