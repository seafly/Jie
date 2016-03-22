Public Class frMOCss

    Private Sub frMOCss_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian)
    End Sub
    Private Sub nian_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian.SelectedValueChanged
        showGrid(nian.Text)
    End Sub
    Private Sub showGrid(ByVal str As Integer)

        Dim sj() As String = Split(GF_yuefen(str), ",")
        Dim MOCdb As DataTable = New DataTable
        Dim db2 As DataTable
        Dim aaRow As DataRow
        For i As Integer = 0 To sj.Length - 1 Step 2
            db2 = yiyue(sj(i), sj(i + 1))
            If i = 0 Then
                MOCdb = db2.Clone
                '设置列的默认值为0
                For ii As Integer = 1 To MOCdb.Columns.Count - 1
                    MOCdb.Columns(ii).DefaultValue = 0
                Next
            End If
            aaRow = MOCdb.NewRow()
            For j As Integer = 0 To db2.Columns.Count - 1
                If db2.Rows(0)(j) Is DBNull.Value Then
                    aaRow(j) = 0
                Else
                    aaRow(j) = db2.Rows(0)(j)
                End If
            Next
            MOCdb.Rows.Add(aaRow)
        Next
        MOCdb = GF_DataTableChange(MOCdb)
        aaRow = MOCdb.NewRow()
        aaRow(0) = "月度合计"
        For i As Integer = 1 To MOCdb.Columns.Count - 1
            aaRow(i) = GF_jsColumnTotal(MOCdb, i, 0, MOCdb.Rows.Count - 1)
        Next
        MOCdb.Rows.Add(aaRow)

        Call GS_useviewbydb2(ListView1, MOCdb, -1, 70)
        ListView1.Columns(0).Width = 100
        '设置行高
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '分别是宽和高
        ListView1.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大
    End Sub
    Private Function yiyue(ByVal str1 As Date, ByVal str2 As Date) As DataTable
        Dim sql As String
        Dim db0 As DataTable
        sql = "select '" & Format(str2, "yyyy-MM") & "' AS '月份',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='粉剂1' THEN 1 ELSE 0 END)AS '粉剂1 1st powder plant',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='粉剂2' THEN 1 ELSE 0 END)AS '粉剂2 2nd powder plant',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='预处理' THEN 1 ELSE 0 END)AS '预处理Biomass drying and extraction',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='油剂' THEN 1 ELSE 0 END)AS '油剂Oil workshop',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='浸出' THEN 1 ELSE 0 END)AS 浸出,"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='发酵' THEN 1 ELSE 0 END)AS '发酵Fermentation',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='采购部' THEN 1 ELSE 0 END)AS '采购部Purshasing Dept.',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='设备动力部' THEN 1 ELSE 0 END)AS '设备动力部Maintenance Department',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='QC' THEN 1 ELSE 0 END)AS QC,"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='QA' THEN 1 ELSE 0 END)AS QA,"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='EHS' THEN 1 ELSE 0 END)AS EHS,"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='运行部' THEN 1 ELSE 0 END)AS '运行部Operation Dept.',"
        'sql = sql & "SUM(CASE WHEN tb_tz_fsqy='销售部' THEN 1 ELSE 0 END)AS '销售部Sale Dept.' "
        sql = sql & gzsql() & " from tb_tz "
        sql = sql & "where tb_tz_rq between '" & str1 & "' and '" & str2 & "'"

        db0 = GF_CreateDataSource(G_cnnstr, sql)
        yiyue = db0
    End Function
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian.Text & "年MOC实施统计", Me)
    End Sub
    Private Function gzsql() As String
        ' Dim gd As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_bmgd")'工段
        Dim Sql1 As String = ""
        For i As Integer = 0 To G_bm.Rows.Count - 1
            If G_bm.Rows(i)(1) = "副总经理" Or G_bm.Rows(i)(1) = "总经理" Or G_bm.Rows(i)(1) = "项目组" Or G_bm.Rows(i)(1) = "工厂" Or G_bm.Rows(i)(1) = "生产运营部" Or G_bm.Rows(i)(1) = "市场营销部" Then
                GoTo xxxx
            End If
            If G_bm.Rows(i)(1) = "粉剂生产部" Then
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='粉剂生产部' and tb_tz_gd='粉剂一车间' THEN 1 ELSE 0 END)AS '粉剂生产部/粉剂一车间',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='粉剂生产部' and tb_tz_gd='粉剂二车间' THEN 1 ELSE 0 END)AS '粉剂生产部/粉剂二车间',"
            ElseIf G_bm.Rows(i)(1) = "油剂生产部" Then
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='油剂生产部' and tb_tz_gd='预处理工段' THEN 1 ELSE 0 END)AS '油剂生产部/预处理工段',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='油剂生产部' and tb_tz_gd='油剂工段' THEN 1 ELSE 0 END)AS '油剂生产部/油剂工段',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='油剂生产部' and tb_tz_gd='发酵工段' THEN 1 ELSE 0 END)AS '油剂生产部/发酵工段',"
            Else
                Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='" & G_bm.Rows(i)(1) & "' THEN 1 ELSE 0 END)AS '" & G_bm.Rows(i)(1) & "',"
            End If
xxxx:
        Next
        Sql1 = GF_removedh(Sql1)
        gzsql = Sql1
    End Function
    'Private Function gzsql() As String
    '    Dim Sql1 As String = ""
    '    For i As Integer = 0 To G_bm.Rows.Count - 1
    '        Sql1 = Sql1 & " SUM(CASE WHEN tb_tz_fsqy='" & G_bm.Rows(i)(1) & "' THEN 1 ELSE 0 END)AS '" & G_bm.Rows(i)(1) & " '" & ","
    '    Next
    '    Sql1 = GF_removedh(Sql1)
    '    gzsql = Sql1
    'End Function
End Class