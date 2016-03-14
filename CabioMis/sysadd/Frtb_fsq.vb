Public Class Frtb_fsq

    Private Sub Frtb_fsq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Dim czid As String = Labelid.Text
        '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘
        GS_wlbktlr(tb_fsq_wcyf, Date.Today.Month, 1, 12)
        'Dim sz1 As String() = {"A", "B", "C"}
        'GS_wlbktlr3(tb_fsq_yxj, sz1, "")
        Dim sz2 As String() = {"/", "Done"}
        GS_wlbktlr3(tb_fsq_wcqk, sz2, "")
        '''''''''''''''''''''''''''''''''''''''''''''
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            SSSDEL.Visible = True
        End If
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''备注可以不填
        If GF_YZSJ(Me, "tb_fsq_bz") = False Then '验证控件
            Exit Sub
        End If
        '''''''''''''''
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''
            If GF_storelog1("修改查询FSQ内审") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            ''''''''''''''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改查询FSQ内审", "修改查询FSQ内审，类别：" & tb_fsq_lb.Text.Trim) '储存到日志
        Else
            ''''''''''''''''''''''''''''
            If GF_storelog1("添加查询FSQ内审") = False Then
                Exit Sub
            End If ' 判断是否有权限
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加查询FSQ内审", "添加查询FSQ内审，类别：" & tb_fsq_lb.Text.Trim) '储存到日志
        End If
        Me.Close()
    End Sub

    Private Sub SSSDEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSDEL.Click
        If MsgBox("你确定删除本条记录吗?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ''''''''''''''''''''日志权限判断
            ''''''''''''''''''''''''''''
            If GF_storelog1("删除查询FSQ内审") = False Then
                Exit Sub
            End If ' 判断是否有权限
            If GF_qdxgjsqx(Labelid.Text, Labeltb.Text, G_js, G_dlrgh) = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim sql As String = "delete  from " & Labeltb.Text & " where " & Labeltb.Text & "_ID=" & Labelid.Text
            GS_upztxx(G_cnnstr, sql)
            GS_storelog3("删除查询FSQ内审", "删除查询FSQ内审，类别：" & tb_fsq_lb.Text.Trim) '储存到日志
            Me.Close()
        End If
        '''''''''''''''''''''''''''

        'Dim n As String = "tb_x832p.tb_x832p_y864q,tb_x832p.tb_x832p_l349d,tb_x832p.tb_x832p_i232a,tb_x832p.tb_x832p_qarq,tb_x832p.tb_x832p_qaspjg,tb_x832p.tb_x832p_qajgsm,tb_x832p.tb_x832p_czrgh,tb_x832p.tb_x832p_bz,tb_x832p.tb_x832p_qaczrgh,tb_x832p.tb_x832p_qcrq,tb_x832p.tb_x832p_cplb,tb_x832p.tb_x832p_d65v,tb_x832p.tb_x832p_a948s,tb_x832p.tb_x832p_n422f,tb_x832p.tb_x832p_s624k,tb_x832p.tb_x832p_s644l,tb_x832p.tb_x832p_c995u,tb_x832p.tb_x832p_s613k,tb_x832p.tb_x832p_m381e,tb_x832p.tb_x832p_j284b,tb_x832p.tb_x832p_c12u,tb_x832p.tb_x832p_f119x,tb_x832p.tb_x832p_s626k,tb_x832p.tb_x832p_e106x,tb_x832p.tb_x832p_n446f,tb_x832p.tb_x832p_h199z,tb_x832p.tb_x832p_o468g,tb_x832p.tb_x832p_u691m,tb_x832p.tb_x832p_c16u,tb_x832p.tb_x832p_k308c,tb_x832p.tb_x832p_r599j,tb_x832p.tb_x832p_d39v,tb_x832p.tb_x832p_qcczrgh,tb_x832p.tb_x832p_yg,tb_x832p.tb_x832p_bzxs,tb_x832p.tb_x832p_cfdd,tb_x832p.tb_x832p_rkts,tb_x832p.tb_x832p_rkbz,tb_x832p.tb_x832p_kczl,tb_x832p.tb_x832p_sykczl,tb_x832p.tb_x832p_jgrq,tb_x832p.tb_x832p_qcsh,tb_x832p.tb_x832p_lzlt,tb_x832p.tb_x832p_ltzl,tb_x832p.tb_x832p_bf,tb_x832p.tb_x832p_bfmx,tb_x832p.tb_x832p_a920s,tb_x832p.tb_x832p_z886r,tb_x832p.tb_x832p_ckcl,tb_x832p.tb_x832p_kdlk,tb_x832p.tb_x832p_bfb,tb_x832p.tb_x832p_scdm"
        'n &= ""
    End Sub
End Class