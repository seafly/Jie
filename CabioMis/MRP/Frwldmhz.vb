Public Class Frwldmhz

    Private Sub Frwldmhz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj()
    End Sub
  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt1 As New DataTable
        dt1 = DeepCode.DeepDoGridView.ToDataTable(show1)
        Dim bds As String = "1=1"
        Dim cxzd1 As String = ComboBox2.Text '时间字段
        If cxzd1 <> "" And TextBox1.Text.Trim <> "" Then
            bds &= " and  [" & cxzd1 & "] like '%" & TextBox1.Text.Trim & "%'"
        End If
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(dt1, bds) '查询并得到结果DB
        show1.DataSource = dt2
    End Sub
    Private Sub showsj()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("请购类别", GetType(String)) : dt.Columns.Add("物料代码", GetType(String))
        dt.Columns.Add("物料名称", GetType(String)) : dt.Columns.Add("单位", GetType(String))
        dt.Columns.Add("规格", GetType(String))
        dt.Columns.Add("安全库存", GetType(Double)) : dt.Columns.Add("经济采购量", GetType(Double))
        dt.Columns.Add("采购周期", GetType(Double)) : dt.Columns.Add("检验周期", GetType(String))
        dt.Columns.Add("仓库存量", GetType(Double)) : dt.Columns.Add("是否", GetType(String))


        Dim sql1 As String = "select tb_i259b_i231a ,sum(tb_i259b_ckcl) from tb_i259b group by tb_i259b_i231a "
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql1)
        For i As Integer = 0 To dt1.Rows.Count - 1
            Dim mm As DataRow = dt.NewRow
            mm(1) = dt1.Rows(i)(0) '物料代码
            mm(9) = Null2zero(dt1.Rows(i)(1)) '仓库存量


            Dim sql2 As String = "select tb_i259b_r596j ,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_gg from tb_i259b where tb_i259b_i231a= '" & dt1.Rows(i)(0) & "'"
            Dim dt2 As DataTable = GF_CreateDataSource(G_cnnstr, sql2)
            mm(0) = Null2String(dt2.Rows(0)("tb_i259b_r596j")) '请购类别
            mm(2) = Null2String(dt2.Rows(0)("tb_i259b_c24u")) '物料名称
            mm(3) = Null2String(dt2.Rows(0)("tb_i259b_h200z")) '单位
            mm(4) = Null2String(dt2.Rows(0)("tb_i259b_gg")) '规格


            Dim sql3 As String = " select tb_wp_aqkc,tb_wp_jjcgl,tb_wp_cgzq,tb_wp_njzq from tb_wp where tb_wp_dm= '" & dt1.Rows(i)(0) & "' "
            Dim dt3 As DataTable = GF_CreateDataSource(G_cnnstr, sql3)

            If dt3.Rows.Count - 1 < 0 Then
                mm(5) = "0"
                mm(6) = "0"
                mm(7) = "0"
                mm(8) = ""
            Else
                mm(5) = Null2zero(dt3.Rows(0)("tb_wp_aqkc")) '安全库存
                mm(6) = Null2zero(dt3.Rows(0)("tb_wp_jjcgl")) '经济采购量
                mm(7) = Null2zero(dt3.Rows(0)("tb_wp_cgzq")) '采购周期
                mm(8) = Null2String(dt3.Rows(0)("tb_wp_njzq")) '检验周期
            End If
          

            If mm(9) - mm(5) <= 0 Then
                mm(10) = "是"
            Else
                mm(10) = "否"
            End If
            dt.Rows.Add(mm)
        Next
        For i As Integer = 0 To dt.Columns.Count - 1 '这里填充筛选框
            Select Case dt.Columns(i).DataType.ToString
                Case "System.String" : ComboBox2.Items.Add(dt.Columns(i).ColumnName)
            End Select
        Next
        GS_DataGridViewbyDb(show1, dt, True, True)
        ChangeColor(show1)

    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GS_toexcel(show1, Me.Text, Me)
    End Sub

    Private Sub ToolStripclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripclose.Click
        Me.Close()
    End Sub
    Private Sub wz()
        GroupBox2.Width = Me.Width - 30
        GroupBox2.Height = Me.Height - GroupBox2.Top - 50
    End Sub
    Private Sub Frwldmhz_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub
    Private Sub ChangeColor(ByVal DateGridName As DataGridView)
        With DateGridName
            For i As Integer = 0 To .Rows.Count - 1

                Dim sf As String = Null2String(.Rows(i).Cells(10).Value)
                If sf = "是" Then
                    .Rows(i).Cells(10).Style.BackColor = Color.Red
                End If
            Next
        End With
    End Sub
    Private Sub RemoveIndex(ByVal DateGridName As DataGridView)

        With DateGridName
            Dim dd As String = ""
            For i As Integer = 0 To .Rows.Count - 1
                Dim ckzl As Double = Null2zero(.Rows(i).Cells(9).Value)
                'Dim xql As Double = Null2zero(.Rows(i).Cells(7).Value)
                If ckzl = "0" Then
                    dd = dd & i & ","
                End If
            Next
            dd = DeepCode.DeepDoStr.GF_removedh(dd)
            Dim crlrsz() As String = dd.Split(",")
            For j As Integer = 0 To UBound(crlrsz)
                Dim sy As Integer = crlrsz(j) - j
                .Rows.RemoveAt(sy)
            Next
        End With
    End Sub

End Class