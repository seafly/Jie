Public Class frpcfxzgx

    Private Sub frpcfxzgx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg

        Call GS_niansl(nian1) : Call GS_niansl(nian2)
        yue1.Text = "01" : yue2.Text = Format(Now, "MM") '将月份显示为带前导零的数字
        Call yy()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call yy()
    End Sub
    Private Sub yy()
        Dim sj1 As String = nian1.Text & "-" & yue1.Text & "-26"
        Dim sj11 As String = nian1.Text & "-" & yue1.Text & "-25"
        Dim sj2 As String = nian2.Text & "-" & yue2.Text & "-25"
        Dim nianyue1 As String = nian1.Text & "-" & yue1.Text
        Dim nianyue2 As String = nian2.Text & "-" & yue2.Text
        Dim n As Integer
        n = DateDiff("m", CDate(sj1), CDate(sj2))

        Dim sql As String
        sql = "select tb_pctz_bm AS '部门/工段',tb_pctz_gd"
        For i As Integer = 0 To n - 1
            Dim kssj As Date = DateAdd(DateInterval.Month, i, CDate(sj1))
            Dim jssj As Date = DateAdd(DateInterval.Month, i + 1, CDate(sj11))
            If kssj = #1/25/2009# Then
                kssj = #1/21/2009#
            ElseIf kssj = #1/26/2009# Then
                kssj = #1/22/2009#
            End If
            If jssj = #1/25/2009# Then
                jssj = #1/21/2009#
            ElseIf jssj = #1/26/2009# Then
                jssj = #1/22/2009#
            End If
            Dim fxx As String = "SUM(CASE WHEN (tb_pctz_rq between '" & kssj & "' AND '" & jssj & "') THEN 1 ELSE 0 END)" '发现项
            sql = sql & "," & fxx & "AS '" & kssj & "至" & jssj & "当月发现项' "
            Dim zgx As String = "SUM(CASE WHEN (tb_pctz_rq between '" & kssj & "' AND '" & jssj & "') AND tb_pctz_wancheng='完成' THEN 1 ELSE 0 END) " '完成项
            sql = sql & "," & zgx & "AS '" & kssj & "至" & jssj & "整改完成项'"
            sql = sql & ",'0.00%' AS '" & kssj & "至" & jssj & "完成率' "
            'sql = sql & ",CASE WHEN " & fxx & ">0 THEN (" & zgx & "*100)/" & fxx & "  ELSE 0 END AS '" & kssj & "至" & jssj & "完成率' "
        Next
        sql = sql & "from tb_pctz "
        sql = sql & "GROUP BY tb_pctz_bm,tb_pctz_gd"
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Dim aaRow As DataRow = db1.NewRow()
        aaRow(0) = "合计："
        For i As Integer = 1 To db1.Columns.Count - 1
            aaRow(i) = GF_jsColumnTotal(db1, i, 0, db1.Rows.Count - 1)
        Next
        db1.Rows.Add(aaRow)
        '完成率
        For j As Integer = 0 To db1.Rows.Count - 1
            For i As Integer = 0 To db1.Columns.Count - 4 Step 3
                If db1.Rows(j)(i + 2) > 0 Then
                    db1.Rows(j)(i + 4) = Format(db1.Rows(j)(i + 3) / db1.Rows(j)(i + 2), "0.00%")
                End If
            Next
        Next
        Call GS_useviewbydb2(ListView1, db1, -1, 75)
        '设置行高
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '分别是宽和高
        ListView1.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大
        'DataGridView1.DataSource = db1
        'DataGridView1.Columns(0).Frozen = True '冻结时间列
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GS_toexcel(ListView1, nian1.Text & "年" & yue1.Text & "至" & nian2.Text & "年" & yue2.Text & "偏差发现整改项统计表", Me)
    End Sub
End Class