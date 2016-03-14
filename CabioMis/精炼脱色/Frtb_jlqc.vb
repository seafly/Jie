Public Class Frtb_jlqc

    Private Sub Frtb_jlqc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Me.tb_k306c_qcsh.SelectedIndex = 1
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        G_S_TURNTAB(Me, 1) '控件TAB顺序
    End Sub
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        ''''''''''''''''''''''''''''''''''''''''''
        '二次脱臭ARA含量(％)/碱炼油酸价(mgKOH/g)/含磷量（ppm）可以不填写
        'If GF_YZSJ(Me, "tb_k306c_r591j,tb_k306c_f133x,tb_k306c_p508h,tb_k306c_w798p") = False Then '验证控件
        '    MsgBox("二次脱臭ARA含量(％)/碱炼油酸价(mgKOH/g)/含磷量（ppm）/残溶（ppm）可以不填写") : Exit Sub
        'End If
        '''''''''''''''
        ''''''''''''''''''''
        If GF_storelog2("添加精炼QC：" & tb_k306c_num.Text.Trim, "添加QC") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
            MsgBox("请检查输入项目及数据")
        End If
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_qcczrgh", Labelid.Text, G_dlrgh) '更新操作人工号
        Me.Close()
    End Sub

End Class