Public Class Frtb_b970t
    Dim dt As DataTable
    Public old(11, 1) As String '这里定义的是原料
    Public old2(2, 1) As String '这里定义的是原料罐
    '得到某原料代码对应的罐，共享的过程，适合任何原料罐，如2.07.001就是糖罐
    Public Shared Function getGAtable(ByVal yldm As String) As DataTable
        Dim sql As String = "select  tb_tg_ID,tb_tg_yldm,tb_tg_rq,tb_tg_yw,tb_tg_hsgx,tb_tg_num,tb_tg_tj,tb_tg_ph,tb_tg_pht"
        sql &= " from tb_tg where tb_tg_tj>0 and tb_tg_zl>0 and tb_tg_yw='否' and tb_tg_yldm=" & yldm & ""
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Return dt1
    End Function
    Private Sub Frtb_b970t_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外
        '     Gs_showsj2(Labeltb.Text, Me, "") '显示最后一条记录的明细
        GS_wlbktlr(tb_b970t_gh, 1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic) '罐下拉
        Dim czid As String = Labelid.Text
        If czid <> "" Then '修改时候批号/罐号不能修改
            Gs_showsj(Labeltb.Text, Me, Labelid.Text) : tb_b970t_num.ReadOnly = True
            gh.Visible = False : tb_b970t_gh.Visible = False
        End If
    
        Dim sql As String = "select * from tb_i259b where " & cl_getWhere.有效物料 '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        ''''''''''''''''''''''''''''''''''''''''''这里是为了修改而保存的原始值
        'setvalue("tb_b970t_p532i", 0)
        setvalue("tb_b970t_q557i", 0)
        setvalue("tb_b970t_i255a", 1)
        setvalue("tb_b970t_k303c", 2)
        setvalue("tb_b970t_gasnph", 3)
        setvalue("tb_b970t_lseqjph", 4)
        setvalue("tb_b970t_lsmph", 5)
        setvalue("tb_b970t_nhgph", 6)
        setvalue("tb_b970t_tsqnph", 7)
        setvalue("tb_b970t_lsnph", 8)
        setvalue("tb_b970t_p532i", 9)
        setvalue("tb_b970t_mph", 10)
        setvalue("tb_b970t_vph", 11)
        ''''''''''''''''''''''''''''''''''''''''''''
    End Sub
    Private Sub setvalue(ylph As String, wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
    Private Sub modfikucun() '更新原料库存
        '''''''''''''''''''''''''''''''''''扣除原料
        'GS_kcylkc(tb_b970t_p532i, Me) '更新原料库存
        GS_kcylkc(tb_b970t_q557i, Me) '更新原料库存
        GS_kcylkc(tb_b970t_i255a, Me) '更新原料库存
        GS_kcylkc(tb_b970t_k303c, Me) '更新原料库存
        GS_kcylkc(tb_b970t_gasnph, Me) '更新原料库存
        GS_kcylkc(tb_b970t_lseqjph, Me) '更新原料库存
        GS_kcylkc(tb_b970t_lsmph, Me) '更新原料库存
        GS_kcylkc(tb_b970t_nhgph, Me) '更新原料库存
        GS_kcylkc(tb_b970t_tsqnph, Me) '更新原料库存
        GS_kcylkc(tb_b970t_lsnph, Me) '更新原料库存
        GS_kcylkc(tb_b970t_p532i, Me) '更新原料库存
        GS_kcylkc(tb_b970t_mph, Me) '更新原料库存
        GS_kcylkc(tb_b970t_vph, Me) '更新原料库存
    End Sub
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填''''''''''''备注，消泡剂批号、消泡剂重量可不填写

        'If GF_YZSJ(Me, "tb_b970t_bz,tb_b970t_k303c,tb_b970t_k303ct,tb_b970t_mph,tb_b970t_mpht,tb_b970t_vph,tb_b970t_vpht") = False Then '验证控件
        '    Exit Sub
        'End If

      
        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_b970t_p532i, tb_b970t_c17u, Me)
        GS_hjkcylkc(tb_b970t_q557i, tb_b970t_a955t, Me)
        GS_hjkcylkc(tb_b970t_i255a, tb_b970t_s633k, Me)
        GS_hjkcylkc(tb_b970t_k303c, tb_b970t_b971t, Me)
        GS_hjkcylkc(tb_b970t_gasnph, tb_b970t_gasnphzl, Me)
        GS_hjkcylkc(tb_b970t_lseqjph, tb_b970t_lseqjphzl, Me)
        GS_hjkcylkc(tb_b970t_lsmph, tb_b970t_lsmphzl, Me)
        GS_hjkcylkc(tb_b970t_nhgph, tb_b970t_nhgphzl, Me)
        GS_hjkcylkc(tb_b970t_tsqnph, tb_b970t_tsqnphzl, Me)
        GS_hjkcylkc(tb_b970t_lsnph, tb_b970t_lsnphzl, Me)
        GS_hjkcylkc(tb_b970t_mph, tb_b970t_mphzl, Me)
        GS_hjkcylkc(tb_b970t_vph, tb_b970t_vphzl, Me)


        '’‘’‘’‘’‘’‘’‘’‘’
        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            'If GF_storelog1("修改一级罐") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            '''''''''''''''''''''
            GS_sancusql(old) ''''还原原料
            GS_sancusql2(old2) '还原原料罐
            ''''''''''''''''''''''''判断原料库存是否够
            Dim ylstr As String = Gf_pdylkc(tb_b970t_q557i, Me)
            ylstr &= Gf_pdylkc(tb_b970t_i255a, Me) & Gf_pdylkc(tb_b970t_k303c, Me)
            ylstr &= Gf_pdylkc(tb_b970t_gasnph, Me) & Gf_pdylkc(tb_b970t_lseqjph, Me)
            ylstr &= Gf_pdylkc(tb_b970t_lsmph, Me) & Gf_pdylkc(tb_b970t_nhgph, Me)
            ylstr &= Gf_pdylkc(tb_b970t_tsqnph, Me) & Gf_pdylkc(tb_b970t_lsnph, Me)
            ylstr &= Gf_pdylkc(tb_b970t_mph, Me) & Gf_pdylkc(tb_b970t_vph, Me)
            ylstr &= Gf_pdylkc(tb_b970t_p532i, Me)
            If ylstr <> "" Then
                GS_hycusql(old) '反还原原料
                MsgBox(ylstr) : Exit Sub
            End If
            '’‘’‘’‘’‘’‘’‘’‘’‘’‘’‘’
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                GS_hycusql(old) '反还原原料
                MsgBox("请检查输入项目及数据") : Exit Sub
            Else
                modfikucun() '更新库存扣除原料
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
                ''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''
                GS_storelog3("修改一级罐：" & tb_b970t_num.Text.Trim, "修改一级罐") '储存到日志
            End If
            '''''''''''''''''''''
        Else
            '''''''''''''''''''''''''''''
            'If GF_storelog1("添加一级罐") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            '''''''''''''''''''''

            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            Else
                modfikucun() '更新库存扣除原料
                ''''''''''''''
                Dim ta As String = "一级罐" & tb_b970t_gh.Text
                ClassPhgn.ClassPhgn_SetDqz2(ta) '使当前批号+1
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
                ''''''''''''''''''''储存到日志
                GS_storelog3("添加一级罐：" & tb_b970t_num.Text.Trim, "添加一级罐")
                '''''''''''''''''''''
            End If

        End If
        Me.Close()
    End Sub
#Region "原料添加"
    Private Sub tb_b970t_tsqnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b970t_tsqnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.007'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "碳酸氢钠")
    End Sub

    Private Sub tb_b970t_lsnph_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b970t_lsnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.011'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "硫酸钠")
    End Sub


    Private Sub tb_b970t_gasnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b970t_gasnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.004'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "谷氨酸钠")
    End Sub

    Private Sub tb_b970t_lseqjph_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b970t_lseqjph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.006'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "磷酸二氢钾")
    End Sub

    Private Sub tb_b970t_lsmph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b970t_lsmph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.005'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "硫酸镁")
    End Sub

    Private Sub tb_b970t_nhgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b970t_nhgph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.008'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氯化钙")
    End Sub


    Private Sub tb_b970t_q557i_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b970t_q557i.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氯化钠")
    End Sub

    Private Sub tb_b970t_i255a_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b970t_i255a.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.002'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "酵母浸膏")
    End Sub

    Private Sub tb_b970t_k303c_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b970t_k303c.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.022'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "消泡剂")
    End Sub
    Private Sub tb_b970t_p532i_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b970t_p532i.DoubleClick
        'Dim dt1 As DataTable = getGAtable("'2.07.001'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "糖罐")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "糖罐")
    End Sub
    Private Sub tb_b970t_mph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b970t_mph.DoubleClick
        'Dim dt1 As DataTable = getGAtable("'2.07.012,2.07.013,2.07.014,2.07.015,2.07.017,2.07.018,2.07.019'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "M（微量金属溶液）")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.001'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "M溶液")
    End Sub

    Private Sub tb_b970t_vph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_b970t_vph.DoubleClick
        'Dim dt1 As DataTable = getGAtable("'2.07.010,2.07.016,2.07.020,2.07.016,2.07.021'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "V（微量维生素溶液）")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.002'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "V溶液")
    End Sub
#End Region

    '批号自动设定
    Private Sub tb_b970t_gh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_b970t_gh.SelectedIndexChanged
        If Labelid.Text = "" Then '修改时候批号不能修改
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("一级罐" & tb_b970t_gh.Text, "-") '得到当前批号+1的批号
            If qztemp = "" Then
                MsgBox("批号设定不正确") : Exit Sub
            End If
            tb_b970t_num.Text = qztemp
        End If
    End Sub
End Class