Public Class ClassDeepChart
    '柱状图显示
    '注意DataTable列为横坐标，因此有列开始及结束处索引参数，其行代表数据，每多一行表示一条，自动拆分，因此有行开始及结束处索引参数
    'ChartTitleDock参数表示标题相对图的停靠方式
    Public Shared Sub G_Chart_ShowColumn(ByVal MsChartName As DataVisualization.Charting.Chart, ByVal Show3D As Boolean, ByVal DataTableName As DataTable, ByVal ChartTitle As String, ByVal ChartTitleDock As DataVisualization.Charting.Docking, ByVal colorB As Color, ByVal colorC() As Color, ByVal DbColBegin As Integer, ByVal DbColEnd As Integer, ByVal DbRowBegin As Integer, ByVal DbRowEnd As Integer)
        Dim a As New DataTable
        With a
            .Columns.Add("X", GetType(String))
            For j As Integer = DbRowBegin To DbRowEnd
                .Columns.Add(DataTableName.Rows(j)(1), GetType(Double))
            Next
            For i As Integer = DbColBegin To DbColEnd
                Dim dr As DataRow = .NewRow
                dr(0) = DataTableName.Columns(i).Caption
                For j As Integer = DbRowBegin To DbRowEnd
                    dr(j + 1) = DataTableName.Rows(j)(i)
                Next
                .Rows.Add(dr)
            Next
        End With
        Dim arcount As Integer = 0
        With MsChartName
            .Series.Clear() : .Titles.Clear()
            .DataSource = a '指定数据源
            .ChartAreas(arcount).Area3DStyle.Enable3D = Show3D '显示区域3D效果
            .Titles.Add(ChartTitle) '标题文字
            .ChartAreas(arcount).AxisX.Interval = 1
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

        For i As Integer = 1 To a.Columns.Count - 1
            MsChartName.Series.Add(a.Columns(i).Caption)
            With MsChartName.Series(i - 1)
                .ChartType = DataVisualization.Charting.SeriesChartType.Column '柱状图
                .BorderWidth = 3 '线粗细
                .ShadowOffset = 2 '阴影
                .Color = colorC(i - 1)
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle '点的形状
                .MarkerSize = 5 '点大小
                .MarkerColor = Color.Gold '点的颜色
                .IsValueShownAsLabel = True '显示点的值
                .XValueMember = a.Columns(0).Caption '指定横坐标字段
                .XValueType = DataVisualization.Charting.ChartValueType.Auto '指定坐标类型
                .YValueMembers = a.Columns(i).Caption '指定纵坐标字段
            End With
        Next
        MsChartName.Update() '这句话很重要，才能显示下面的tooltip
        '显示下面的各个点的tooltip为DataTableName0列的值
        For i As Integer = 0 To MsChartName.Series.Count - 1
            For j As Integer = 0 To MsChartName.Series(i).Points.Count - 1
                MsChartName.Series(i).Points(j).ToolTip = a.Rows(j)(0)
            Next
        Next

    End Sub
    '折线图或饼图显示
    '以折线图的方式显示，注意DataTable第0列为横坐标，其它列为纵坐标，每多一列表示一条线，自动拆分
    'ChartTitleDock参数表示标题相对图的停靠方式，取值0顶1右2左3底
    Public Shared Sub G_Chart_ShowLine(ByVal MsChartName As DataVisualization.Charting.Chart, ByVal ChartStyle As DataVisualization.Charting.SeriesChartType, ByVal Show3D As Boolean, ByVal DataTableName As DataTable, ByVal ChartTitle As String, ByVal ChartTitleDock As DataVisualization.Charting.Docking)
        If DataTableName.Columns.Count < 2 Then
            MsgBox("至少应该有2列") : Return
        End If
        With MsChartName
            .Series.Clear() : .Titles.Clear()
            .DataSource = DataTableName '指定数据源
            .ChartAreas(0).Area3DStyle.Enable3D = Show3D '显示区域3D效果
            .Titles.Add(ChartTitle) '标题文字
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

        For i As Integer = 1 To DataTableName.Columns.Count - 1
            MsChartName.Series.Add(DataTableName.Columns(i).Caption)
            With MsChartName.Series(i - 1)
                .ChartType = ChartStyle '折线或者柱状图
                .BorderWidth = 3 '线粗细
                .ShadowOffset = 2 '阴影
                .Color = Color.Green
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
    '折线图或饼图显示，和上面过程一样，加入了一个颜色数组参数作为重载
    '以折线图的方式显示，注意DataTable第0列为横坐标，其它列为纵坐标，每多一列表示一条线，自动拆分
    'ChartTitleDock参数表示标题相对图的停靠方式，取值0顶1右2左3底
    Public Shared Sub G_Chart_ShowLine(ByVal MsChartName As DataVisualization.Charting.Chart, ByVal ChartStyle As DataVisualization.Charting.SeriesChartType, ByVal Show3D As Boolean, ByVal DataTableName As DataTable, ByVal ChartTitle As String, ByVal ChartTitleDock As DataVisualization.Charting.Docking, ByVal colorC() As Color)
        If DataTableName.Columns.Count < 2 Then
            MsgBox("至少应该有2列") : Return
        End If
        With MsChartName
            .Series.Clear() : .Titles.Clear()
            .DataSource = DataTableName '指定数据源
            .ChartAreas(0).Area3DStyle.Enable3D = Show3D '显示区域3D效果
            .Titles.Add(ChartTitle) '标题文字
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

        For i As Integer = 1 To DataTableName.Columns.Count - 1
            MsChartName.Series.Add(DataTableName.Columns(i).Caption)
            With MsChartName.Series(i - 1)
                .ChartType = ChartStyle '折线或者柱状图
                .BorderWidth = 3 '线粗细
                .ShadowOffset = 2 '阴影
                .Color = colorC(i - 1)
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
    Public Shared Sub GS_SaveChartImg(ByVal MsChartName As DataVisualization.Charting.Chart)
        Try
            Dim dhk As New SaveFileDialog
            dhk.Filter = "Jpeg|*.jpg"
            If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If
            Dim wjm As String = dhk.FileName : dhk = Nothing
            If wjm = "" Then
                Exit Sub
            End If
            MsChartName.SaveImage(wjm, DataVisualization.Charting.ChartImageFormat.Jpeg)
            MsgBox("图形保存成功！")
        Catch ex As Exception
            MsgBox("图形保存失败！")
        End Try

    End Sub
End Class
