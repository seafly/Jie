Public Class Frgysadd
    Public id As Integer
    Private Sub Frgys_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        If id <> 0 Then
            Gs_showsj("tb_GysTwo", Me, id)
        End If
        tb_GysTwo_czrgh.Text = G_dlrgh

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If GF_YZSJ(Me, "tb_GysTwo_wbz,tb_GysTwo_gg") = False Then '验证控件
            Exit Sub
        End If
         Dim jj As String=""
        If id = 0 Then
            jj = GF_addsj("tb_GysTwo", Me, G_cnnstr)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
        Else
            If GF_modsj("tb_GysTwo", Me, id, G_cnnstr) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            jj = id
        End If
        Dim sql As String = "update tb_i259b set tb_i259b_zhbzq=DATEADD(mm," & tb_GysTwo_bzq.Text & ",tb_i259b_scrq) where tb_i259b_gysbs='" & jj & "'"
        sql.YanDbExe

        MessageBox.Show("更新成功！")
        me.DialogResult=DialogResult.OK
    End Sub
End Class