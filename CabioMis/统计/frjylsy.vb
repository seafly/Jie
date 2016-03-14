Public Class frjylsy

    Private Sub fjylsy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MessageBox.Show("in")
        Me.Icon = G_TJicon : Me.BackgroundImage = G_backimg
        Call GS_niansl(nian)
    End Sub

    Private Sub nian_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nian.SelectedValueChanged
        Call showGrid(CInt(nian.Text))
    End Sub

    Private Sub showGrid(ByVal str As Integer)
        Dim zd(8, 1) As String
        zd(0, 0) = "dpzl" : zd(0, 1) = "AA油"
        zd(1, 0) = "z884r" : zd(1, 1) = "麦芽糊精(底料)"
        zd(2, 0) = "g154y" : zd(2, 1) = "麦芽糊精(喷雾)"
        zd(3, 0) = "g180y" : zd(3, 1) = "磷酸三钙"
        zd(4, 0) = "h209z" : zd(4, 1) = "变性淀粉"
        zd(5, 0) = "d66v" : zd(5, 1) = "酪蛋白酸钠"
        zd(6, 0) = "t685m" : zd(6, 1) = "柠檬酸钠"
        zd(7, 0) = "h201z" : zd(7, 1) = "葡萄糖"
        zd(8, 0) = "q535i" : zd(8, 1) = "维生素C钠"
        zd(9, 0) = "rtm" : zd(9, 1) = "乳糖"
        zd(10, 0) = "rqdbfm" : zd(10, 1) = "乳清蛋白粉"
        zd(11, 0) = "pttm" : zd(11, 1) = "葡萄糖浆"
        zd(12, 0) = "llzm" : zd(12, 1) = "卵磷脂"
        Dim sql As String
        '以下为“计划完成项”DataTable：db1
        sql = "select CONVERT(char(7), tb_n441f_jgrq, 120) as 月份,"
        For i As Integer = 0 To UBound(zd, 1)
            sql = sql & "SUM(isnull(tb_n441f_" & zd(i, 0) & ",0.00))AS '" & zd(i, 1) & "月用量',"
            sql = sql & "SUM(CASE WHEN tb_n441f_m382e='1号塔' THEN tb_n441f_" & zd(i, 0) & " ELSE 0 END)AS '" & zd(i, 1) & "1号塔', "
            sql = sql & "SUM(CASE WHEN tb_n441f_m382e='2号塔' THEN tb_n441f_" & zd(i, 0) & " ELSE 0 END)AS '" & zd(i, 1) & "2号塔', "
            sql = sql & "SUM(CASE WHEN tb_n441f_m382e='34号塔'  THEN tb_n441f_" & zd(i, 0) & " ELSE 0 END)AS '" & zd(i, 1) & "3&4号塔',"
        Next
        sql = GF_removedh(sql)
        sql = sql & "from tb_n441f "
        sql = sql & "where DATEPART(yyyy,tb_n441f_jgrq)=" & str & " "
        sql = sql & "GROUP BY CONVERT(char(7), tb_n441f_jgrq, 120)"
        Dim db1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)

        Dim aaRow As DataRow
        '添加“合计”行
        aaRow = db1.NewRow()
        aaRow(0) = "合计"
        For i As Integer = 1 To db1.Columns.Count - 1
            aaRow(i) = GF_jsColumnTotal(db1, i, 0, db1.Rows.Count - 1)
        Next
        db1.Rows.Add(aaRow)
        db1 = GF_DataTableChange(db1)

        Call GS_useviewbydb2(ListView1, db1, -1, 90)
        ListView1.Columns(0).Width = 150
        '设置行高
        Dim imgList As ImageList = New ImageList()
        imgList.ImageSize = New Size(1, 20) '分别是宽和高
        ListView1.SmallImageList = imgList '这里设置listView的SmallImageList ,用imgList将其撑大
        '设置背景色
        With ListView1.Items
            For i As Integer = 0 To .Count - 4 Step 8
                .Item(i).SubItems(0).BackColor = Color.LightSkyBlue
                .Item(i + 1).SubItems(0).BackColor = .Item(i).SubItems(0).BackColor
                .Item(i + 2).SubItems(0).BackColor = .Item(i).SubItems(0).BackColor
                .Item(i + 3).SubItems(0).BackColor = .Item(i).SubItems(0).BackColor
            Next
            For i As Integer = 4 To .Count - 4 Step 8
                .Item(i).SubItems(0).BackColor = Color.LightPink
                .Item(i + 1).SubItems(0).BackColor = .Item(i).SubItems(0).BackColor
                .Item(i + 2).SubItems(0).BackColor = .Item(i).SubItems(0).BackColor
                .Item(i + 3).SubItems(0).BackColor = .Item(i).SubItems(0).BackColor
            Next
        End With
    End Sub
    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView1, nian.Text & "年粉剂原料使用统计", Me)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


End Class