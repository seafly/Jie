Public Class Fraddelse
    '页面负责部门。工段的添加
    Public biao As String
    Private Sub Fraddelse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        showsj()
    End Sub
    Private Sub showsj()
        Dim sql As String = "select * from  " & biao
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView1, dt, 0, 0)
        GroupBox1.Text = "列表（双击删除）" & GF_getListViewsz(ListView1) & "条记录"
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bm As String = TextBox1.Text.Trim
        If bm = "" Then
            Exit Sub
        End If
        If GF_cxph(biao & "_p512h", bm) = True Then
            MsgBox("数据库内已经存在该数据，请重新输入！") : Exit Sub
        End If
        If GF_storelog2("添加部门:" & bm, "部门管理") = False Then
            MsgBox("您的权限不够！") : Exit Sub
        End If   '生成日志
        Dim sql As String = "insert into " & biao & "(" & biao & "_p512h)values('" & bm & "')"
        GS_upztxx(G_cnnstr, sql)
        showsj()
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim biaozd As String = "tb_yg_v753n"
        If biao = "tb_bmgh" Then
            biaozd = "tb_yg_bmgd"
        End If
        Dim bm As String = ListView1.SelectedItems(0).SubItems(1).Text
        If MsgBox("确定删除：" & bm & "吗？", 1, "警告") <> 1 Then
            Exit Sub
        End If
        Dim sql As String = "select  tb_yg_ID from  tb_yg where " & biaozd & "='" & bm & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            MsgBox("该项目已经有了人员，不能删除！") : Exit Sub
        End If
        If GF_storelog2("删除部门:" & bm, "部门管理") = False Then
            MsgBox("您的权限不够！") : Exit Sub
        End If   '生成日志
        sql = "delete from " & biao & " where " & biao & "_p512h='" & bm & "'"
        GS_upztxx(G_cnnstr, sql)
        showsj()


    End Sub

  
End Class