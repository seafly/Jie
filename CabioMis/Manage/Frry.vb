Public Class Frry

    Private Sub Frry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        ComboBox1.SelectedIndex = 0
        Call cshfr()
    End Sub
    Private Sub cshfr()
        Dim what As String = ""
        Select Case ComboBox1.SelectedIndex
            Case 0
                what = "select tb_yg_id as ID,tb_yg_n430f as 工号,tb_yg_w779o as 姓名,tb_yg_v753n as 部门,tb_yg_bmgd as 工段,tb_yg_js as 角色,tb_yg_zt as 注销 from tb_yg where tb_yg_yx='有效'and tb_yg_zt='正常'order by tb_yg_w779o"
            Case 1
                what = "select tb_yg_id as ID,tb_yg_n430f as 工号,tb_yg_w779o as 姓名,tb_yg_v753n as 部门,tb_yg_bmgd as 工段,tb_yg_js as 角色,tb_yg_zt as 注销 from tb_yg where tb_yg_yx='无效' and tb_yg_zt='正常'order by tb_yg_w779o"
            Case 2
                what = "select tb_yg_id as ID,tb_yg_n430f as 工号,tb_yg_w779o as 姓名,tb_yg_v753n as 部门,tb_yg_bmgd as 工段,tb_yg_js as 角色,tb_yg_zt as 注销 from tb_yg where tb_yg_zt='正常'order by tb_yg_w779o"
            Case 3
                what = "select tb_yg_id as ID,tb_yg_n430f as 工号,tb_yg_w779o as 姓名,tb_yg_v753n as 部门,tb_yg_bmgd as 工段,tb_yg_js as 角色,tb_yg_zt as 注销 from tb_yg where  tb_yg_zt='注销'order by tb_yg_w779o"
        End Select
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, what)
        GS_DataGridViewbyDb(listview1, dt, "0", True, True)
        Label1.Visible = True
        Label1.Text = "查询结果：" & GF_getListViewsz(ListView1) & "条记录"
    End Sub
    '添加
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aa As New frryAdd
        Me.AddOwnedForm(aa)
        aa.ShowDialog()
        cshfr()
    End Sub

    '修改操作
    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listview1.MouseDoubleClick
        If listview1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Dim aa As New frryAdd

        aa.gh = listview1.SelectedRows(0).Cells(1).Value

        If ComboBox1.SelectedIndex = 0 Then
            aa.tb_yg_zt.Enabled = False
        End If
        aa.ShowDialog()
        cshfr()
    End Sub
    '删除
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If listview1.SelectedRows.Count > 0 Then
            Dim xh As String = listview1.SelectedRows(0).Cells(0).Value
            Dim r As Integer = MsgBox("确定要删除吗?", 1, "确定要删除吗?")
            If r = 1 Then
                If GF_storelog2("删除人员工号:" & listview1.SelectedRows(0).Cells(1).Value, "人员管理") = False Then
                    MsgBox("您的权限不够！") : Exit Sub
                End If   '生成日志
                Dim cnn As New Data.OleDb.OleDbConnection(G_cnnstr)
                cnn.Open()
                Dim myread As New Data.OleDb.OleDbCommand
                myread.Connection = cnn
                Dim Sql As String = "delete from tb_yg where tb_yg_id='" & xh & "'"
                myread.CommandText = Sql : myread.ExecuteNonQuery()
                myread = Nothing : cnn.Close() : cnn = Nothing
                MsgBox("删除成功！", MsgBoxStyle.OkOnly)
                Call cshfr()
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Buttontofile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttontofile.Click
        GS_toexcel(ListView1, Me.Text, Me)
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If listview1.SelectedRows.Count > 0 Then
            Dim xzid As String = listview1.SelectedRows(0).Cells(0).Value
            If MsgBox("确定要使该人员无效吗?", 1, "警告?") <> 1 Then
                Exit Sub
            End If
            If GF_storelog2("无效人员，工号:" & listview1.SelectedRows(0).Cells(1).Value, "人员管理") = False Then
                MsgBox("您的权限不够！") : Exit Sub
            End If   '生成日志
            Dim sql As String = "update tb_yg set tb_yg_yx='无效',tb_yg_dl=null,tb_yg_quan=null,tb_yg_js=null where tb_yg_id=" & xzid
            GS_upztxx(G_cnnstr, sql)
            GS_upztxx(G_cnnstrWH, sql)
            cshfr()

        End If

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If listview1.SelectedRows.Count > 0 Then
            Dim xzid As String = listview1.SelectedRows(0).Cells(0).Value
            If MsgBox("确定要使该人员有效吗?", 1, "警告?") <> 1 Then
                Exit Sub
            End If
            If GF_storelog2("有效人员，工号:" & listview1.SelectedRows(0).Cells(1).Value, "人员管理") = False Then
                MsgBox("您的权限不够！") : Exit Sub
            End If   '生成日志
            Dim sql As String = "update tb_yg set tb_yg_yx='有效' where tb_yg_id=" & xzid
            GS_upztxx(G_cnnstr, sql)
            GS_upztxx(G_cnnstrWH, sql)
            MsgBox("操作完成，请立即设置该人员的角色！")
            cshfr()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        cshfr()
    End Sub

 
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If listview1.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("确定要重置该人员密码吗?", 1, "警告?") <> 1 Then
            Exit Sub
        End If
        Dim psw As String = GF_MD5("888888", 16)
        If GF_storelog2("重置密码，工号：" & listview1.SelectedRows(0).Cells(1).Value, "人员管理") = False Then
            MsgBox("您的权限不够！") : Exit Sub
        End If   '生成日志
        Dim sql As String = "update tb_yg set tb_yg_pass='" & psw & "' where tb_yg_id=" & listview1.SelectedRows(0).Cells(0).Value
        GS_upztxx(G_cnnstr, sql)
        GS_upztxx(G_cnnstrWH, sql)
        MsgBox("操作完成！")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        With ListView1
            If .SelectedRows.Count = 0 Then Return
            Dim gh As String = listview1.SelectedRows(0).Cells(1).Value
            Dim a As New Frzx
            Me.AddOwnedForm(a)
            a.xgid = listview1.SelectedRows(0).Cells(0).Value
            a.tb_yg_n430f.Text = gh
            a.tb_yg_js.Text = Null2String(listview1.SelectedRows(0).Cells(5).Value)
            a.ShowDialog()
        End With
    End Sub
End Class