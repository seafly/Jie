Public Class Frtbfj_qc
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtbfj_qc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Me.tb_x832p_qcsh.SelectedIndex = 1
        Me.tb_x832p_o468g.SelectedIndex = 0
        Dim czid As String = Labelid.Text
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        If tb_x832p_qcrq.Text = "" Then
            tb_x832p_h199z.Text = "0/5×10g"
        End If
        G_S_TURNTAB(Me, 1) '控件TAB顺序
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        ''''''''''''''''''''''''''''''''''''''''''
        'If GF_YZSJ(Me, "tb_x832p_s613k,tb_x832p_u691m,tb_x832p_c16u,tb_x832p_remark") = False Then '验证控件焦粒子，霉菌，酵母可以不填写
        '    Exit Sub
        'End If
        ''''''''''''''''''''
        If GF_storelog2("添加成品粉QC：" & tb_x832p_num.Text.Trim, "添加QC") = False Then
            Exit Sub
        End If
        '''''''''''''''''''''
        If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
            MsgBox("请检查输入项目及数据")
        End If
        '''''''''''''''更新成品粉库存QC有关信息
        Dim sql As String = "select * from tb_x832pkc  where tb_x832pkc_num = '" & tb_x832p_num.Text.Trim & "'"
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        If dt.Rows.Count > 0 Then
            Dim sql1 As String = "update tb_x832pkc set tb_x832pkc_qcrq= '" & tb_x832p_qcrq.Text & "',tb_x832pkc_num= '" & tb_x832p_num.Text & "',tb_x832pkc_d65v= " & tb_x832p_d65v.Text & ",tb_x832pkc_a948s= " & tb_x832p_a948s.Text & ", "
            sql1 &= "tb_x832pkc_n422f= '" & tb_x832p_n422f.Text & "',tb_x832pkc_s624k= " & tb_x832p_s624k.Text & ",tb_x832pkc_s644l= " & tb_x832p_s644l.Text & ",tb_x832pkc_c995u= " & tb_x832p_c995u.Text & ", "
            sql1 &= "tb_x832pkc_s613k= '" & tb_x832p_s613k.Text & "',tb_x832pkc_m381e= " & tb_x832p_m381e.Text & ",tb_x832pkc_j284b= " & tb_x832p_j284b.Text & ",tb_x832pkc_c12u= " & tb_x832p_c12u.Text & ", "
            sql1 &= "tb_x832pkc_f119x= " & tb_x832p_f119x.Text & ",tb_x832pkc_s626k= " & tb_x832p_s626k.Text & ",tb_x832pkc_e106x= '" & tb_x832p_e106x.Text & "',tb_x832pkc_n446f= '" & tb_x832p_n446f.Text & "', "
            sql1 &= "tb_x832pkc_c16u= '" & tb_x832p_c16u.Text & "',tb_x832pkc_k308c= " & tb_x832p_k308c.Text & ",tb_x832pkc_r599j= " & tb_x832p_r599j.Text & ",tb_x832pkc_d39v= '" & tb_x832p_d39v.Text & "', "
            sql1 &= "tb_x832pkc_sjqa= '" & tb_x832p_sjqa.Text & "',tb_x832pkc_kss= '" & tb_x832p_kss.Text & "',tb_x832pkc_nxam= '" & tb_x832p_nxam.Text & "',tb_x832pkc_qcsh= '" & tb_x832p_qcsh.Text & "', "
            sql1 &= "tb_x832pkc_h199z= '" & tb_x832p_h199z.Text & "',tb_x832pkc_o468g= '" & tb_x832p_o468g.Text & "',tb_x832pkc_u691m= '" & tb_x832p_u691m.Text & "' where tb_x832pkc_num= '" & tb_x832p_num.Text.Trim & "' "

            GS_upztxx(G_cnnstr, sql1)

        End If
        ''''''''''''''''
        GS_modczsj(Labeltb.Text, Labeltb.Text & "_qcczrgh", Labelid.Text, G_dlrgh) '更新操作人工号
        Me.Close()

    End Sub

End Class