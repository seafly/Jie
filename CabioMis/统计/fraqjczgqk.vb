Public Class fraqjczgqk

    Private Sub fraqjczgqk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian)
    End Sub
    Private Sub nian_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian.SelectedValueChanged
        showGrid(nian.Text)
    End Sub
    Private Sub showGrid(ByVal str As Integer)
        Dim sql As String
        '以下为整改项数DataTable：db1
        sql = "select CONVERT(char(7), tb_jcfxx_rq, 120) as 月份,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='油剂生产部' THEN 1 ELSE 0 END)AS '油剂生产部整改项数',"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='粉剂生产部' THEN 1 ELSE 0 END)AS '粉剂生产部整改项数',"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='采购部' THEN 1 ELSE 0 END)AS 采购部整改项数,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='设备动力部' THEN 1 ELSE 0 END)AS '设备动力部整改项数',"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='QC' THEN 1 ELSE 0 END)AS QC整改项数,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='技术部' THEN 1 ELSE 0 END)AS '技术部整改项数',"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='QA' THEN 1 ELSE 0 END)AS QA整改项数,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='运行部' THEN 1 ELSE 0 END)AS 运行部整改项数,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='EHS' THEN 1 ELSE 0 END)AS EHS整改项数,"
        sql = sql & gzsql("整改项数") & "SUM(1)AS '整改项数月度合计' "
        sql = sql & "from tb_jcfxx "
        sql = sql & "where DATEPART(yyyy,tb_jcfxx_rq)=" & str & " and tb_jcfxx_jcxm='EHS' "
        sql = sql & "GROUP BY CONVERT(char(7), tb_jcfxx_rq, 120)"
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim aaRow As DataRow = db1.NewRow()
        aaRow(0) = "Total"
        For i As Integer = 1 To db1.Columns.Count - 1
            aaRow(i) = GF_jsColumnTotal(db1, i, 0, db1.Rows.Count - 1)
        Next
        db1.Rows.Add(aaRow)
        db1 = GF_DataTableChange(db1)
        '以下为完成数DataTable：db1
        sql = "select CONVERT(char(7), tb_jcfxx_rq, 120) as 月份,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='油剂生产部' THEN 1 ELSE 0 END)AS '油剂生产部完成数',"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='粉剂生产部' THEN 1 ELSE 0 END)AS '粉剂生产部完成数',"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='采购部' THEN 1 ELSE 0 END)AS 采购部完成数,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='设备动力部' THEN 1 ELSE 0 END)AS '设备动力部完成数',"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='QC' THEN 1 ELSE 0 END)AS QC完成数,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='技术部' THEN 1 ELSE 0 END)AS '技术部完成数',"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='QA' THEN 1 ELSE 0 END)AS QA完成数,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='运行部' THEN 1 ELSE 0 END)AS 运行部完成数,"
        'sql = sql & "SUM(CASE WHEN tb_jcfxx_zrbm='EHS' THEN 1 ELSE 0 END)AS EHS完成数,"
        sql = sql & gzsql("完成数") & "SUM(1)AS '完成数月度合计' "
        sql = sql & "from tb_jcfxx "
        sql = sql & "where DATEPART(yyyy,tb_jcfxx_rq)=" & str & " and tb_jcfxx_jcxm='EHS' and tb_jcfxx_wancheng='完成' "
        sql = sql & "GROUP BY CONVERT(char(7), tb_jcfxx_rq, 120)"
        Dim db2 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        aaRow = db2.NewRow()
        aaRow(0) = "Total"
        For i As Integer = 1 To db2.Columns.Count - 1
            aaRow(i) = GF_jsColumnTotal(db2, i, 0, db2.Rows.Count - 1)
        Next
        db2.Rows.Add(aaRow)
        db2 = GF_DataTableChange(db2)
        '创建db3，用于合并db1和db2；
        Dim db3 As DataTable = New DataTable
        db3.Columns.Add("部门/完成情况", Type.GetType("System.String"))
        For i As Integer = 0 To 11
            db3.Columns.Add(Format(DateAdd(DateInterval.Month, i, CDate("01/" & str)), "yyyy-MM"), Type.GetType("System.String"))
        Next
        db3.Columns.Add("Total", Type.GetType("System.String"))
        '设置列的默认值为0
        For i As Integer = 1 To db3.Columns.Count - 1
            db3.Columns(i).DefaultValue = 0
        Next

        For n As Integer = 0 To db1.Rows.Count - 1
            '以下添加一行db1中的数据
            aaRow = db3.NewRow()
            aaRow(0) = db1.Rows(n)(0)
            For ii As Integer = 1 To db3.Columns.Count - 1
                For m As Integer = 1 To db1.Columns.Count - 1
                    If db3.Columns(ii).Caption = db1.Columns(m).Caption Then
                        aaRow(ii) = db1.Rows(n)(m)
                        GoTo ss
                    End If
                Next
ss:
            Next
            db3.Rows.Add(aaRow)
            '以下添加一行db2中的数据
            aaRow = db3.NewRow()
            aaRow(0) = db2.Rows(n)(0)
            For ii As Integer = 1 To db3.Columns.Count - 1
                For m As Integer = 1 To db2.Columns.Count - 1
                    If db3.Columns(ii).Caption = db2.Columns(m).Caption Then
                        aaRow(ii) = db2.Rows(n)(m)
                        GoTo ss2
                    End If
                Next
ss2:
            Next
            db3.Rows.Add(aaRow)
        Next
        '添加“总完成率”行
        Dim hs As Integer = db3.Rows.Count
        aaRow = db3.NewRow()
        aaRow(0) = "总完成率(%)"
        For ii As Integer = 1 To db3.Columns.Count - 1
            If db3.Rows(hs - 1)(ii) > 0 Then
                aaRow(ii) = (db3.Rows(hs - 1)(ii) * 100) / db3.Rows(hs - 2)(ii)
            End If

        Next
        db3.Rows.Add(aaRow)
        '’
        Call GS_useviewbydb2(ListView1, db3, -1, 80)
        ListView1.Columns(0).Width = 190
        '设置背景色
        With ListView1.Items
            'For i As Integer = 0 To 18 Step 4
            '    .Item(i).SubItems(0).BackColor = Color.LightSkyBlue
            '    .Item(i + 1).SubItems(0).BackColor = .Item(i).SubItems(0).BackColor
            'Next
            .Item(19).SubItems(0).BackColor = Color.LightGreen
            .Item(20).SubItems(0).BackColor = .Item(19).SubItems(0).BackColor
            .Item(18).SubItems(0).BackColor = .Item(19).SubItems(0).BackColor
        End With
        '设置行高
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '分别是宽和高
        ListView1.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大

    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian.Text & "年EHS整改情况统计", Me)
    End Sub
    Private Function gzsql(ByVal str As String) As String
        ' Dim gd As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_bmgd")'工段
        Dim Sql1 As String = ""
        For i As Integer = 0 To G_bm.Rows.Count - 1
            If G_bm.Rows(i)(1) = "副总经理" Or G_bm.Rows(i)(1) = "总经理" Or G_bm.Rows(i)(1) = "项目组" Or G_bm.Rows(i)(1) = "工厂" Or G_bm.Rows(i)(1) = "生产运营部" Or G_bm.Rows(i)(1) = "市场营销部" Then
                GoTo xxxx
            End If
            If G_bm.Rows(i)(1) = "粉剂生产部" Then
                Sql1 = Sql1 & " SUM(CASE WHEN tb_jcfxx_zrbm='粉剂生产部' and tb_jcfxx_gd='粉剂一车间' THEN 1 ELSE 0 END)AS '粉剂生产部/粉剂一车间 " & str & "',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_jcfxx_zrbm='粉剂生产部' and tb_jcfxx_gd='粉剂二车间' THEN 1 ELSE 0 END)AS '粉剂生产部/粉剂二车间 " & str & "',"
            ElseIf G_bm.Rows(i)(1) = "油剂生产部" Then
                Sql1 = Sql1 & " SUM(CASE WHEN tb_jcfxx_zrbm='油剂生产部' and tb_jcfxx_gd='预处理工段' THEN 1 ELSE 0 END)AS '油剂生产部/预处理工段 " & str & "',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_jcfxx_zrbm='油剂生产部' and tb_jcfxx_gd='油剂工段' THEN 1 ELSE 0 END)AS '油剂生产部/油剂工段 " & str & "',"
                Sql1 = Sql1 & " SUM(CASE WHEN tb_jcfxx_zrbm='油剂生产部' and tb_jcfxx_gd='发酵工段' THEN 1 ELSE 0 END)AS '油剂生产部/发酵工段 " & str & "',"
            Else
                Sql1 = Sql1 & " SUM(CASE WHEN tb_jcfxx_zrbm='" & G_bm.Rows(i)(1) & "' THEN 1 ELSE 0 END)AS '" & G_bm.Rows(i)(1) & str & " '" & ","
            End If
xxxx:
        Next
        gzsql = Sql1
    End Function

End Class