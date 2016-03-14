Public Class Frtb_b959t
    Dim dt As DataTable
    Public old(11, 1) As String
    Public old2(2, 1) As String '这里定义的是原料罐
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub Frtb_b959t_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        Dim czid As String = Labelid.Text

        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            gh.Visible = False : tb_b959t_gh.Visible = False
        End If
        '   Gs_showsj2(Labeltb.Text, Me, "tb_b959t_num2") '显示最后一条记录的明细
        GS_wlbktlr(tb_b959t_gh, 1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        ''''''''''''''''''''''''''''''''''''''''''这里是为了修改而保存的原始值

        setvalue("tb_b959t_v730n", 0)
        setvalue("tb_b959t_f119x", 1)
        setvalue("tb_b959t_j286b", 2)
        setvalue("tb_b959t_gasnph", 3)
        setvalue("tb_b959t_lseqjph", 4)
        setvalue("tb_b959t_lsmph", 5)
        setvalue("tb_b959t_nhgph", 6)
        setvalue("tb_b959t_tsqnph", 7)
        setvalue("tb_b959t_lsnph", 8)
        setvalue("tb_b959t_t665l", 9)
        setvalue("tb_b959t_mph", 10)
        setvalue("tb_b959t_vph", 11)
    End Sub
    Private Sub setvalue(ylph As String, wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
    Private Sub modfikucun() '更新库存
        '''''''''''''''''''''''''''''''''''扣除原料
        GS_kcylkc(tb_b959t_v730n, Me) '更新原料库存
        GS_kcylkc(tb_b959t_f119x, Me) '更新原料库存
        GS_kcylkc(tb_b959t_j286b, Me) '更新原料库存
        GS_kcylkc(tb_b959t_gasnph, Me) '更新原料库存
        GS_kcylkc(tb_b959t_lseqjph, Me) '更新原料库存
        GS_kcylkc(tb_b959t_lsmph, Me) '更新原料库存
        GS_kcylkc(tb_b959t_nhgph, Me) '更新原料库存
        GS_kcylkc(tb_b959t_tsqnph, Me) '更新原料库存
        GS_kcylkc(tb_b959t_lsnph, Me) '更新原料库存
        GS_kcylkc(tb_b959t_t665l, Me) '更新原料库存
        GS_kcylkc(tb_b959t_mph, Me) '更新原料库存
        GS_kcylkc(tb_b959t_vph, Me) '更新原料库存
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click

        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填''''''''''''备注，消泡剂批号、消泡剂重量可不填写

        'If GF_YZSJ(Me, "tb_b959t_bz,tb_b959t_f119x,tb_b959t_f119xt,tb_b959t_mph,tb_b959t_mpht,tb_b959t_vph,tb_b959t_vpht") = False Then '验证控件
        '    Exit Sub
        'End If
        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_b959t_t665l, tb_b959t_z898r, Me)
        GS_hjkcylkc(tb_b959t_v730n, tb_b959t_k334c, Me)
        GS_hjkcylkc(tb_b959t_f119x, tb_b959t_g176y, Me)
        GS_hjkcylkc(tb_b959t_j286b, tb_b959t_a948s, Me)
        GS_hjkcylkc(tb_b959t_gasnph, tb_b959t_gasnphzl, Me)
        GS_hjkcylkc(tb_b959t_lseqjph, tb_b959t_lseqjphzl, Me)
        GS_hjkcylkc(tb_b959t_lsmph, tb_b959t_lsmphzl, Me)
        GS_hjkcylkc(tb_b959t_nhgph, tb_b959t_nhgphzl, Me)
        GS_hjkcylkc(tb_b959t_tsqnph, tb_b959t_tsqnphzl, Me)
        GS_hjkcylkc(tb_b959t_lsnph, tb_b959t_lsnphzl, Me)
        GS_hjkcylkc(tb_b959t_mph, tb_b959t_mphzl, Me)
        GS_hjkcylkc(tb_b959t_vph, tb_b959t_vphzl, Me)
        ''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            'If GF_storelog1("修改二级罐") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限

            ''''''''''''''''''''
            GS_sancusql(old) ''''还原原料
            ''''''''''''''''''''''''判断原料库存是否够
            Dim ylstr As String = Gf_pdylkc(tb_b959t_t665l, Me) & Gf_pdylkc(tb_b959t_v730n, Me)
            ylstr &= Gf_pdylkc(tb_b959t_f119x, Me) & Gf_pdylkc(tb_b959t_j286b, Me)
            ylstr &= Gf_pdylkc(tb_b959t_gasnph, Me) & Gf_pdylkc(tb_b959t_lseqjph, Me)
            ylstr &= Gf_pdylkc(tb_b959t_lsmph, Me) & Gf_pdylkc(tb_b959t_nhgph, Me)
            ylstr &= Gf_pdylkc(tb_b959t_tsqnph, Me) & Gf_pdylkc(tb_b959t_lsnph, Me)
            ylstr &= Gf_pdylkc(tb_b959t_mph, Me) & Gf_pdylkc(tb_b959t_vph, Me)
            If ylstr <> "" Then
                GS_hycusql(old) '反还原原料
                GS_hycusql2(old2) '反还原原料罐
                MsgBox(ylstr) : Exit Sub
            End If
            ''''''''''''''''''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                GS_hycusql(old) '反还原原料
                MsgBox("请检查输入项目及数据")
                Exit Sub
            Else
                modfikucun() '更新库存
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
                GS_storelog3("修改二级罐：" & tb_b959t_num.Text.Trim, "修改二级罐") '储存到日志
            End If
        Else
            '''''''''''''''''''''''''''''
            'If GF_storelog1("添加二级罐") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            Else
                modfikucun() '更新库存
                Dim ta As String = "二级罐" & tb_b959t_gh.Text
                ClassPhgn.ClassPhgn_SetDqz2(ta) '使当前批号+1
                GS_gengsb(Labeltb2.Text, Labelid2.Text, Labeltb.Text, jj)
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
                GS_storelog3("添加二级罐：" & tb_b959t_num.Text.Trim, "添加二级罐") '储存到日志
            End If
        End If
        Me.Close()
    End Sub
#Region "原料添加"
    Private Sub tb_b959t_tsqnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_tsqnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.007'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "碳酸氢钠")
    End Sub

    Private Sub tb_b959t_lsnph_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b959t_lsnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.011'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "硫酸钠")
    End Sub


    Private Sub tb_b959t_gasnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_gasnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.004'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "谷氨酸钠")
    End Sub

    Private Sub tb_b959t_lseqjph_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b959t_lseqjph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.006'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "磷酸二氢钾")
    End Sub

    Private Sub tb_b959t_lsmph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_lsmph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.005'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "硫酸镁")
    End Sub

    Private Sub tb_b959t_nhgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_nhgph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.008'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氯化钙")
    End Sub

    Private Sub tb_b959t_j286b_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_j286b.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氯化钠")
    End Sub
    Private Sub tb_b959t_v730n_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_v730n.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.002'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "酵母浸膏")
    End Sub

    Private Sub tb_b959t_f119x_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_f119x.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.022'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "消泡剂")
    End Sub
    Private Sub tb_b959t_t665l_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_t665l.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.001'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "糖罐")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "糖罐")
    End Sub
    Private Sub tb_b959t_mph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_mph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.012,2.07.013,2.07.014,2.07.015,2.07.017,2.07.018,2.07.019'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "M（微量金属溶液）")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.001'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "M溶液")
    End Sub

    Private Sub tb_b959t_vph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b959t_vph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.010,2.07.016,2.07.020,2.07.016,2.07.021'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "V（微量维生素溶液）")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.002'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "M溶液")
    End Sub
#End Region




    Private Sub tb_b959t_gh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b959t_gh.SelectedIndexChanged
        If Labelid.Text = "" Then '修改时候批号不能修改
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("二级罐" & tb_b959t_gh.Text, "-") '得到当前批号+1的批号
            If qztemp = "" Then
                MsgBox("批号设定不正确") : Exit Sub
            End If
            tb_b959t_num.Text = qztemp
        End If
    End Sub
  
End Class