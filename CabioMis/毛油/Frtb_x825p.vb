Public Class Frtb_x825p
    Dim dt As DataTable
    Public old(2, 1) As String
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_i234a_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='毛油' and tb_cpdmhz_cplx='DOGC'")
        GS_bcfbd(dt2, 2, tb_x825p_mingc)

        GS_qhjd(Me) '回车键切换焦点，备注除外
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj("tb_x825p", Me, Labelid.Text)
        Else
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("毛油", "-") '得到当前批号+1的批号
            If qztemp = "" Then
                MsgBox("批号设定不正确") : Exit Sub
            End If

            tb_x825p_num.Text = qztemp
        End If
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        ''''''''''''''''''''''''''''''''''''''''''这里是为了修改而保存的原始值
        setvalue("tb_x825p_jwph", 0)
        setvalue("tb_x825p_ycph", 1)
        setvalue("tb_x825p_nhnph", 2)
    End Sub
    Private Sub tb_x832p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x825p_mingc.SelectedIndexChanged
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='毛油' and tb_cpdmhz_cplx='DOGC' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt2, 3, tb_x825p_jiagdm)
    End Sub



    Private Sub setvalue(ylph As String, wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
    Private Sub modfikucun() '更新库存
        '''''''''''''''''''''''''''''''''''扣除原料
        GS_kcylkc(tb_x825p_jwph, Me) '更新原料库存
        GS_kcylkc(tb_x825p_ycph, Me) '更新原料库存
        GS_kcylkc(tb_x825p_nhnph, Me) '更新原料库存
  
    End Sub
#Region "原料"

    Private Sub tb_x825p_ycph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x825p_ycph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.032'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "乙醇")
    End Sub



    Private Sub tb_x825p_nhnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x825p_nhnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氯化钠")
    End Sub

    Private Sub tb_x825p_jwph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x825p_jwph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.024'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "己烷")
    End Sub



#End Region
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        'TODO:
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''
        Dim nofillcontrol As String = "" '不需要填的控件
        nofillcontrol = "tb_i234a_bz,tb_x825p_ycph,tb_x825p_ycpht"
        'If GF_YZSJ(Me, nofillcontrol) = False Then '验证控件
        '    Exit Sub
        'End If
        '''''''''''''''
        ''''''''''''''''''''合计汇总

        GS_hjkcylkc(tb_x825p_jwph, tb_x825p_jwphzl, Me)
        GS_hjkcylkc(tb_x825p_ycph, tb_x825p_ycphzl, Me)
        GS_hjkcylkc(tb_x825p_nhnph, tb_x825p_nhnphzl, Me)
        ''''''''''''''''''''''''
        If Labelid.Text <> "" Then
            If GF_storelog1("修改毛油") = False Then
                Exit Sub
            End If ' 判断是否有权限
            ''''''''''''''''''''
            GS_sancusql(old) ''''还原原料
            ''''''''''''''''''''''''判断原料库存是否够
            Dim ylstr As String = Gf_pdylkc(tb_x825p_jwph, Me) & Gf_pdylkc(tb_x825p_ycph, Me)
            ylstr = ylstr & Gf_pdylkc(tb_x825p_nhnph, Me)

            If ylstr <> "" Then
                GS_hycusql(old) '反还原原料
                MsgBox(ylstr) : Exit Sub
            End If
            ''''''''''''''''''''
            If GF_modsj("tb_x825p", Me, Labelid.Text) = False Then '修改数据
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            modfikucun() '更新库存
            GS_modczsj("tb_x825p", "tb_x825p_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改毛油：" & tb_x825p_num.Text.Trim, "修改毛油") '储存到日志
        Else
            '''''''''''''''''''''''''''''
            If GF_storelog1("添加毛油") = False Then
                Exit Sub
            End If ' 判断是否有权限

            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If

            modfikucun() '更新库存
            ''''''''''''''
            GS_gengsb(Labeltb2.Text, Labelid2.Text, Labeltb.Text, jj)
            Dim ta As String = "毛油"
            ClassPhgn.ClassPhgn_SetDqz2(ta) '使当前批号+1
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            'ywtjg() '改变糖碱罐的状态
            GS_storelog3("添加毛油：" & tb_x825p_num.Text.Trim, "添加毛油") '储存到日志
        End If

        Me.Close()
    End Sub

    Private Sub tb_x825p_s640k_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x825p_s640k.TextChanged
        Try
            Dim sl As Double = Double.Parse(tb_x825p_s640k.Text)
            tb_x825p_hblsrkzl.Text = sl
        Catch ex As Exception
            MessageBox.Show("请输入数字！")
        End Try
    End Sub
End Class