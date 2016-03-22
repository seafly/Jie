Public Class Frtb_elsecheck

    Private Sub Frtb_elsecheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_wlbktlr2(tb_elsecheck_bm, G_bm, 1, "")
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            Button1.Visible = True

        End If

        GS_qhjd(Me) '回车键切换焦点，备注除外
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''
        If GF_YZSJ(Me, "tb_elsecheck_jg,tb_elsecheck_p520h,tb_elsecheck_b957t,tb_elsecheck_n422f,tb_elsecheck_d48v,tb_elsecheck_d64v,tb_elsecheck_t654l,tb_elsecheck_a927s,tb_elsecheck_v729n,tb_elsecheck_e77w,tb_elsecheck_s647l,tb_elsecheck_x809p,tb_elsecheck_z916s") = False Then '验证控件
            Exit Sub
        End If
        '''''''''''''''
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            If GF_storelog1("修改QC") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改QC其它检测：" & tb_elsecheck_ypmc.Text, "修改QC") '储存到日志
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("添加QC") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加QC其它检测：" & tb_elsecheck_ypmc.Text, "添加QC") '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            If GF_storelog2("删除QC其它检测：" & tb_elsecheck_ypmc.Text, "删除QC") = False Then
                Exit Sub
            End If
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql) : Me.Close()
        End If
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

End Class