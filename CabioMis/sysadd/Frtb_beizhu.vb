Public Class Frtb_beizhu

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("管理每月重要说明") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            If GF_modsj(labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(labeltb.Text, labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改每月重要说明：" & tb_beizhu_rq.Text, "修改每月重要说明") '储存到日志
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("管理每月重要说明") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(labeltb.Text, labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加每月重要说明：" & tb_beizhu_rq.Text, "添加每月重要说明") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Frtb_beizhu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        If Labelid.Text <> "" Then '显示默认数据
            Call Gs_showsj("tb_beizhu", Me, Labelid.Text)
        End If

    End Sub
End Class