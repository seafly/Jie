Public Class Frxkh
    Public id As String = ""
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Frxkh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = G_backimg : Me.Icon = G_icon
        tb_ddcys_fl.SelectedIndex = 0
        If id <> "" Then
            Gs_showsj("tb_ddcys", Me, id)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        'If GF_YZSJ(Me, "") = False Then '验证控件
        '    Exit Sub
        'End If
        If id <> "" Then
            If GF_modsj("tb_ddcys", Me, id, G_cnnstr) = False Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            GS_storelog3("修改小客户承运商名称：" & tb_ddcys_mc.Text.Trim, "产品加工") '储存到日志
        Else

            Dim jj As String = GF_addsj("tb_ddcys", Me, G_cnnstr)
            If jj = "" Then
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            GS_storelog3("添加小客户承运商名称：：" & tb_ddcys_mc.Text.Trim, "产品加工") '储存到日志

        End If
        Me.Close()
    End Sub


End Class