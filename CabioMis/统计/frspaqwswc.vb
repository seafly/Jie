Public Class frspaqwswc

    Private Sub frspaqwswc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian)
    End Sub
    Private Sub nian_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian.SelectedValueChanged
        showGrid(nian.Text)
    End Sub
    Private Sub showGrid(ByVal str As Integer)
        Dim sj() As String = Split(GF_yuefen(str), ",")
        Dim db1 As DataTable = New DataTable
        Dim db2 As DataTable = New DataTable
        Dim db_temp As DataTable = New DataTable
        Dim aaRow As DataRow
        '计划完成项
        For i As Integer = 0 To sj.Length - 1 Step 2
            db_temp = yiyue(sj(i), sj(i + 1), "计划完成项")
            If i = 0 Then
                db1 = db_temp.Clone
            End If
            aaRow = db1.NewRow()
            For j As Integer = 0 To db_temp.Columns.Count - 1
                aaRow(j) = db_temp.Rows(0)(j)
            Next
            db1.Rows.Add(aaRow)
        Next
        '实际完成项
        For i As Integer = 0 To sj.Length - 1 Step 2
            db_temp = yiyue(sj(i), sj(i + 1), "实际完成项")
            If i = 0 Then
                db2 = db_temp.Clone
            End If
            aaRow = db2.NewRow()
            For j As Integer = 0 To db_temp.Columns.Count - 1
                aaRow(j) = db_temp.Rows(0)(j)
            Next
            db2.Rows.Add(aaRow)
        Next

        '创建db3，用于合并db1和db2；
        Dim db3 As DataTable = New DataTable
        db3.Columns.Add("审核类别", Type.GetType("System.String"))
        For i As Integer = 0 To 11
            db3.Columns.Add(Format(DateAdd(DateInterval.Month, i, CDate("01/" & str)), "yyyy-MM") & "内审", Type.GetType("System.String"))
            db3.Columns.Add(Format(DateAdd(DateInterval.Month, i, CDate("01/" & str)), "yyyy-MM") & "外审", Type.GetType("System.String"))
        Next
        ''设置列的默认值为0
        'For i As Integer = 1 To db3.Columns.Count - 1
        '    db3.Columns(i).DefaultValue = "0"
        'Next

        '以下添加db1中的数据
        'Dim aaRow As DataRow
        aaRow = db3.NewRow()
        aaRow(0) = "计划完成项"
        For n As Integer = 0 To db1.Rows.Count - 1
            For m As Integer = 1 To db3.Columns.Count - 1 Step 2
                If CDate(Microsoft.VisualBasic.Left(db3.Columns(m).Caption, 7)) = CDate(db1.Rows(n)(0)) Then
                    aaRow(m) = db1.Rows(n)(1) '内审计划完成项
                    aaRow(m + 1) = db1.Rows(n)(2) '外审计划完成项
                    GoTo xx
                End If
            Next
xx:
        Next
        db3.Rows.Add(aaRow)
        '以下添加db2中的数据
        aaRow = db3.NewRow()
        aaRow(0) = "实际完成项"
        For n As Integer = 0 To db2.Rows.Count - 1
            For m As Integer = 1 To db3.Columns.Count - 1 Step 2
                If CDate(Microsoft.VisualBasic.Left(db3.Columns(m).Caption, 7)) = CDate(db2.Rows(n)(0)) Then
                    aaRow(m) = db2.Rows(n)(1) '内审实际完成项
                    aaRow(m + 1) = db2.Rows(n)(2) '外审实际完成项
                    GoTo xx2
                End If
            Next
xx2:
        Next
        db3.Rows.Add(aaRow)
        ''设置列的默认值为0
        For i As Integer = 1 To db3.Columns.Count - 1
            db3.Columns(i).DefaultValue = "0"
        Next
        '添加“完成率”行
        aaRow = db3.NewRow()
        aaRow(0) = "完成率(%)"
        For ii As Integer = 1 To db3.Columns.Count - 1
            If db3.Rows(0)(ii) > 0 Then
                aaRow(ii) = Format(db3.Rows(1)(ii) / db3.Rows(0)(ii), "0.00%")
            End If
        Next
        db3.Rows.Add(aaRow)
        '添加“完成率(合计)”行
        aaRow = db3.NewRow()
        aaRow(0) = "完成率合计(%)"
        For ii As Integer = 1 To db3.Columns.Count - 1 Step 2
            If db3.Rows(0)(ii) + db3.Rows(0)(ii + 1) > 0 Then
                aaRow(ii) = Format(db3.Rows(1)(ii) + db3.Rows(1)(ii + 1) / db3.Rows(0)(ii) + db3.Rows(0)(ii + 1), "0.00%")
            Else
                aaRow(ii) = 0
            End If

            aaRow(ii + 1) = aaRow(ii)
        Next
        db3.Rows.Add(aaRow)
        '’
        Call GS_useviewbydb2(ListView1, db3, -1, 90)
        '设置行高
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '分别是宽和高
        ListView1.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大

    End Sub
    Private Function yiyue(ByVal str1 As Date, ByVal str2 As Date, ByVal fx As String) As DataTable
        Dim sql As String = ""
        Dim cc As String
        Dim db0 As DataTable
        If fx = "计划完成项" Then
            '以下为“计划完成项”DataTable：db1
            sql = "select '" & Format(str2, "yyyy-MM") & "' AS '月份',"
            cc = "SUM(CASE WHEN tb_spaqnwsh_nsshlb='内审' THEN tb_spaqnwsh_nsljjhwcx ELSE 0 END)"
            sql = sql & "case when " & cc & " is null then 0 else " & cc & " end AS '内审计划完成项',"
            cc = "SUM(CASE WHEN tb_spaqnwsh_nsshlb='外审' THEN tb_spaqnwsh_nsljjhwcx ELSE 0 END)"
            sql = sql & "case when " & cc & " is null then 0 else " & cc & " end AS '外审计划完成项' "
            sql = sql & "from tb_spaqnwsh "
            sql = sql & "where tb_spaqnwsh_rq between '" & str1 & "' and '" & str2 & "'"
        ElseIf fx = "实际完成项" Then
            '以下为“实际完成项”DataTable：db2
            sql = "select '" & Format(str2, "yyyy-MM") & "' AS '月份',"
            cc = "SUM(CASE WHEN tb_spaqnwsh_nsshlb='内审' THEN tb_spaqnwsh_nsljsjwcx ELSE 0 END)"
            sql = sql & "case when " & cc & " is null then 0 else " & cc & " end AS '内审实际完成项',"
            cc = "SUM(CASE WHEN tb_spaqnwsh_nsshlb='外审' THEN tb_spaqnwsh_nsljsjwcx ELSE 0 END)"
            sql = sql & "case when " & cc & " is null then 0 else " & cc & " end AS '外审实际完成项' "
            sql = sql & "from tb_spaqnwsh "
            sql = sql & "where tb_spaqnwsh_rq between '" & str1 & "' and '" & str2 & "'"
        End If
        db0 = GF_CreateDataSource(G_cnnstr, sql)
        yiyue = db0
    End Function
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian.Text & "年食品安全质量（FSQ）审核改进情况统计表", Me)
    End Sub
End Class