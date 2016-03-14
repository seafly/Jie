Public Class Frtb_meijieQC
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_meijieQC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        tb_meijie_qcsh.SelectedIndex = 0
        tb_meijie_jj.SelectedIndex = 0
        Dim czid As String = Labelid.Text
        If czid <> "" Then '修改时候批号/罐号不能修改
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            'tb_meijie_qcsh.Visible = False
        End If
        G_S_TURNTAB(Me, 1) '控件TAB顺序
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        'If tb_meijie_qcrq.Text = "" Then
        '    MsgBox("请检查输入项目及数据") : Exit Sub
        'End If

        ''''''''''''''''''''日志与权限判断
        'If GF_storelog1("修改QC") = False Then
        '    Exit Sub
        'End If ' 判断是否有权限
        '''''''''''''''''''''
        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
            MsgBox("请检查输入项目及数据") : Exit Sub
        End If
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_qcczrgh", Labelid.Text, G_dlrgh) '更新操作人工号

        GS_storelog3("修改酶解罐QC：" & tb_meijie_num.Text.Trim, "修改QC") '储存到日志

        Me.Close()
    End Sub

End Class