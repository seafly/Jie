Public Class Frylcybj

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dhk As New OpenFileDialog
        dhk.Filter = "EXCEL电子表格|*.XLS"
        If dhk.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
        Dim wjm As String = dhk.FileName : dhk = Nothing
        If wjm = "" Then
            Exit Sub
        End If
        Dim ljc As String = "provider=Microsoft.Jet.OLEDB.4.0; data source=" & wjm & ";Extended Properties=Excel 8.0;"
        Dim sql As String = "select * from [即时库存$]"
        Dim dt1 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(ljc, sql) '得到K3库存

        'With dt1
        '    dt1.Columns.Add("K3", GetType(String))
        '    For i As Integer = 0 To .Rows.Count - 1
        '        .Rows(i)("K3") = "K3"
        '    Next
        'End With
        'showl.DataSource = dt1
        sql = "select tb_i259b_i231a,tb_i259b_c24u,tb_i259b_num,tb_i259b_p518h from tb_i259b "
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_CreateDataSource(G_cnnstr, sql) '得到本机库存
        showl.DataSource = dt2
        Dim dt3 As New DataTable
        dt3.Columns.Add("代码", GetType(String))
        dt3.Columns.Add("名称", GetType(String))
        dt3.Columns.Add("批号", GetType(String))
        dt3.Columns.Add("本系统重量", GetType(Double))
        dt3.Columns.Add("K3重量", GetType(Double))
        dt3.Columns.Add("差异", GetType(Double))
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Call getcy(dt2, dt1, dt3)
        '''''''''''''''''''''''''''''''''''
        showl.DataSource = dt3
        GroupBox1.Text = "相同数据" & dt3.Rows.Count
        '''''''''''''''''''''''''''''''''''''''''''''''''
        DataGridView1.DataSource = dt1
        GroupBox2.Text = "K3系统剩余数据" & dt1.Rows.Count
        '''''''''''''''''''''''''''''''''''''''''
        GS_DataGridViewbyDb(DataGridView2, dt2, True, False)
        GroupBox3.Text = "本系统剩余数据" & dt2.Rows.Count
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        GroupBox1.Visible = True : GroupBox2.Visible = True : GroupBox3.Visible = True
        GS_DataGridViewaddmenu(showl) '增加查看明细菜单
        GS_DataGridViewaddmenu(DataGridView1) '增加查看明细菜单
        GS_DataGridViewaddmenu(DataGridView2) '增加查看明细菜单
    End Sub
    Private Sub getcy(ByVal db1 As DataTable, ByVal db2 As DataTable, ByVal outdb As DataTable)
        Dim scsy1 As String = "" : Dim scsy2 As String = ""
        With db1
            For i As Integer = 0 To .Rows.Count - 1
                Dim t1 As String = .Rows(i)(0) : Dim t2 As String = .Rows(i)(1) : Dim t3 As String = .Rows(i)(2)
                Dim t0 As Double = DeepCode.DeepDoStr.Null2zero(.Rows(i)(3))
                With db2
                    For j As Integer = 0 To .Rows.Count - 1
                        Dim t11 As String = .Rows(j)(0) : Dim t21 As String = .Rows(j)(1) : Dim t31 As String = .Rows(j)(2)
                        Dim t01 As Double = DeepCode.DeepDoStr.Null2zero(.Rows(j)(3))
                        If t1 = t11 And t2 = t21 And t3 = t31 Then
                            Dim z As DataRow = outdb.NewRow
                            z(0) = t1 : z(1) = t2 : z(2) = t3 : z(3) = t0 : z(4) = t01 : z(5) = t0 - t01
                            outdb.Rows.Add(z)
                            scsy1 &= i & ","
                            scsy2 &= j & ","
                        End If
                    Next

                End With
            Next
        End With
        'scsy1 = DeepCode.DeepDoStr.GF_removedh(scsy1)
        'scsy2 = DeepCode.DeepDoStr.GF_removedh(scsy2)
        'DeepCode.DeepDoDataTable.DelDataRowAtIndex(db1, scsy1)
        'DeepCode.DeepDoDataTable.DelDataRowAtIndex(db2, scsy2
        If scsy1 <> "" Then
            scsy1 = DeepCode.DeepDoStr.GF_removedh(scsy1)

            DeepCode.DeepDoDataTable.DelDataRowAtIndex(db1, scsy1)
        End If
        If scsy2 <> "" Then

            scsy2 = DeepCode.DeepDoStr.GF_removedh(scsy2)
            DeepCode.DeepDoDataTable.DelDataRowAtIndex(db2, scsy2)
        End If
        'MsgBox(scsy1 & vbCrLf & scsy2)
    End Sub

    Private Sub Frylcybj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        wz()
    End Sub
    Private Sub wz()
        Dim gd As Integer = Me.Height - GroupBox1.Top
        gd = Int(gd / 2)
        GroupBox1.Height = gd
        GroupBox1.Width = Me.Width - GroupBox1.Left - 20
        GroupBox2.Top = GroupBox1.Top + GroupBox1.Height + 5
        Dim kd As Integer = Me.Width - GroupBox2.Left
        kd = Int(kd / 2)
        GroupBox2.Width = kd
        GroupBox2.Height = Me.Height - GroupBox2.Top - 10
        GroupBox3.Top = GroupBox2.Top
        GroupBox3.Left = Me.Width - GroupBox2.Left - GroupBox2.Width + 5
        GroupBox3.Height = GroupBox2.Height
        GroupBox3.Width = Me.Width - GroupBox3.Left - 20
    End Sub

    Private Sub Frylcybj_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        wz()
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub


    Private Sub showl_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles showl.MouseDoubleClick
        With showl
            If .SelectedRows.Count = 0 Then
                Return
            End If
            Dim ph, dm, mc As String '批号，代码，名称
            Dim aa As New Frylcybj2
            dm = .SelectedRows(0).Cells(0).Value '代码
            mc = .SelectedRows(0).Cells(1).Value '名称
            ph = .SelectedRows(0).Cells(2).Value '批号
            aa.TextBox1.Text = .SelectedRows(0).Cells(3).Value '数量
            aa.Label1.Text = dm & mc & ph & "库存"
            aa.xghc = "top"
            Me.AddOwnedForm(aa) : aa.ShowDialog()
        End With
    End Sub
    Private Sub DataGridView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseDoubleClick
        With DataGridView2
            If .SelectedRows.Count = 0 Then
                Return
            End If
            Dim ph, dm, mc As String '批号，代码，名称
            Dim aa As New Frylcybj2
            dm = .SelectedRows(0).Cells(0).Value '代码
            mc = .SelectedRows(0).Cells(1).Value '名称
            ph = .SelectedRows(0).Cells(2).Value '批号
            aa.TextBox1.Text = .SelectedRows(0).Cells(3).Value '数量
            aa.Label1.Text = dm & mc & ph & "库存"
            aa.xghc = "right"
            Me.AddOwnedForm(aa) : aa.ShowDialog()
        End With
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(showl, sender.Text, Me)
    End Sub

    Private Sub ToExcel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel2.Click
        GS_toexcel(DataGridView1, sender.Text, Me)
    End Sub

    Private Sub ToExcel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel3.Click
        GS_toexcel(DataGridView2, sender.Text, Me)
    End Sub
End Class