Public Class Frtb_i234a
    Dim dt As DataTable
    Public old(18, 1) As String
    Public old2(5, 1) As String '这里定义的是原料罐
    Private Sub Frtb_x825p_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_wlbktlr(tb_i234a_gh, 4, 4, 6)
        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
            gh.Visible = False : tb_i234a_gh.Visible = False
        End If
        GS_wlbktlr(tb_i234a_gh, 4, 4, 6)
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格'  and tb_i259b_yxx='有效' " '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表

        ''''''''''''''''''''''''''''''''''''''''''这里是为了修改而保存的原始值
        setvalue("tb_i234a_j276b", 0)
        setvalue("tb_i234a_k303c", 1)
        setvalue("tb_i234a_l344d", 2)
        setvalue("tb_i234a_u704m", 3)
        setvalue("tb_i234a_j281b", 4)
        setvalue("tb_i234a_lsmph", 5)
        setvalue("tb_i234a_nhgph", 6)
        setvalue("tb_i234a_tsqnph", 7)
        setvalue("tb_i234a_lsnph", 8)
        setvalue("tb_i234a_pttph", 9)
        setvalue("tb_i234a_lmsph", 10)
        setvalue("tb_i234a_gasnph", 11)
        setvalue("tb_i234a_xpjph", 12)

        ''''''''''''''''''''''''''''''''''''''''''''
        setvalue("tb_i234a_tgph", 13)
        setvalue("tb_i234a_mph", 14)
        setvalue("tb_i234a_vph", 15)
        setvalue("tb_i234a_suanph", 16)
        setvalue("tb_i234a_dygph", 17)
        setvalue("tb_i234a_xpjgph", 18)
    End Sub
    Private Sub setvalue(ylph As String, wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
    Private Sub modfikucun() '更新库存
        '''''''''''''''''''''''''''''''''''扣除原料
        GS_kcylkc(tb_i234a_j276b, Me) '更新原料库存
        GS_kcylkc(tb_i234a_k303c, Me) '更新原料库存
        GS_kcylkc(tb_i234a_l344d, Me) '更新原料库存
        GS_kcylkc(tb_i234a_u704m, Me) '更新原料库存
        GS_kcylkc(tb_i234a_j281b, Me) '更新原料库存
        GS_kcylkc(tb_i234a_lsmph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_nhgph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_tsqnph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_lsnph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_pttph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_lmsph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_gasnph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_xpjph, Me) '更新原料库存

        GS_kcylkc(tb_i234a_tgph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_mph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_vph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_suanph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_dygph, Me) '更新原料库存
        GS_kcylkc(tb_i234a_xpjgph, Me) '更新原料库存
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''''''''''''备注、消泡计、浓度、体积、PH、糖灌、碱灌可以不填写
        Dim nofillcontrol As String = "" '不需要填的控件
        nofillcontrol = "tb_i234a_bz,tb_i234a_l344d,tb_i234a_l344dt,tb_i234a_nd,"
        nofillcontrol &= "tb_i234a_tj,tb_i234a_x805p,tb_i234a_j276b,tb_i234a_j276bt,"
        nofillcontrol &= "tb_i234a_a929s,tb_i234a_tgph,tb_i234a_tgpttph,tb_i234a_jgph,"
        nofillcontrol &= "tb_i234a_jgqyhnph,tb_b970t_mph,tb_b970t_mpht,tb_b970t_vph,tb_b970t_vpht"
        'If GF_YZSJ(Me, nofillcontrol) = False Then '验证控件
        '    Exit Sub
        'End If
        '''''''''''''''

        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_i234a_k303c, tb_i234a_s612k, Me)
        GS_hjkcylkc(tb_i234a_u704m, tb_i234a_l170d, Me)
        GS_hjkcylkc(tb_i234a_l344d, tb_i234a_s621k, Me)
        GS_hjkcylkc(tb_i234a_j276b, tb_i234a_a929s, Me)
        GS_hjkcylkc(tb_i234a_j281b, tb_i234a_f137x, Me)
        GS_hjkcylkc(tb_i234a_lsmph, tb_i234a_lsmphzl, Me)
        GS_hjkcylkc(tb_i234a_nhgph, tb_i234a_nhgphzl, Me)
        GS_hjkcylkc(tb_i234a_tsqnph, tb_i234a_tsqnphzl, Me)
        GS_hjkcylkc(tb_i234a_lsnph, tb_i234a_lsnphzl, Me)
        ''
        GS_hjkcylkc(tb_i234a_pttph, tb_i234a_pttphzl, Me)
        GS_hjkcylkc(tb_i234a_lmsph, tb_i234a_lmsphzl, Me)
        GS_hjkcylkc(tb_i234a_gasnph, tb_i234a_gasnphzl, Me)
        GS_hjkcylkc(tb_i234a_xpjph, tb_i234a_xpjphzl, Me)
        ''
        GS_hjkcylkc(tb_i234a_mph, tb_i234a_mphzl, Me)
        GS_hjkcylkc(tb_i234a_vph, tb_i234a_vphzl, Me)
        GS_hjkcylkc(tb_i234a_tgph, tb_i234a_tgphzl, Me)
        GS_hjkcylkc(tb_i234a_suanph, tb_i234a_suanphzl, Me)
        GS_hjkcylkc(tb_i234a_dygph, tb_i234a_dygphzl, Me)
        GS_hjkcylkc(tb_i234a_xpjgph, tb_i234a_xpjgphzl, Me)
        '''''''''''''''''''''''''''''''''''

        If Labelid.Text <> "" Then
            '''''''''''''''''''''''''''''
            'If GF_storelog1("修改发酵罐") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            ''''''''''''''''''''
            GS_sancusql(old) ''''还原原料
            GS_sancusql2(old2) '还原原料罐
            ''''''''''''''''''''''''判断原料库存是否够
            Dim ylstr As String = Gf_pdylkc(tb_i234a_k303c, Me) & Gf_pdylkc(tb_i234a_u704m, Me)
            ylstr = ylstr & Gf_pdylkc(tb_i234a_l344d, Me) & Gf_pdylkc(tb_i234a_j276b, Me)
            ylstr = ylstr & Gf_pdylkc(tb_i234a_j281b, Me)
            ylstr &= Gf_pdylkc(tb_i234a_lsmph, Me) & Gf_pdylkc(tb_i234a_nhgph, Me)

            ylstr &= Gf_pdylkc(tb_i234a_tsqnph, Me) & Gf_pdylkc(tb_i234a_lsnph, Me)
            ylstr &= Gf_pdylkc(tb_i234a_pttph, Me) & Gf_pdylkc(tb_i234a_lmsph, Me)
            ylstr &= Gf_pdylkc(tb_i234a_gasnph, Me) & Gf_pdylkc(tb_i234a_xpjph, Me)
            ylstr &= Gf_pdylkc(tb_i234a_mph, Me) & Gf_pdylkc(tb_i234a_vph, Me)
            ylstr = ylstr & Gf_pdylkc(tb_i234a_tgph, Me)
            ylstr = ylstr & Gf_pdylkc(tb_i234a_suanph, Me)
            ylstr = ylstr & Gf_pdylkc(tb_i234a_dygph, Me)
            ylstr = ylstr & Gf_pdylkc(tb_i234a_xpjgph, Me)
            If ylstr <> "" Then
                GS_hycusql(old) '反还原原料
                MsgBox(ylstr) : Exit Sub
            End If
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                GS_hycusql(old) '反还原原料
                MsgBox("请检查输入项目及数据")
                Exit Sub
            Else
                modfikucun() '更新库存
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
                'ywtjg() '改变糖碱罐的状态
                GS_storelog3("修改发酵罐：" & tb_i234a_num.Text.Trim, "修改发酵罐") '储存到日志
            End If

        Else
            '''''''''''''''''''''''''''''
            'If GF_storelog1("添加发酵罐") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限

            '''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If

            modfikucun() '更新库存
            ''''''''''''''
            GS_gengsb(Labeltb2.Text, Labelid2.Text, Labeltb.Text, jj)
            Dim ta As String = "发酵罐" & tb_i234a_gh.Text
           ClassPhgn.ClassPhgn_SetDqz2(ta) '使当前批号+1
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            'ywtjg() '改变糖碱罐的状态
            GS_storelog3("添加发酵罐：" & tb_i234a_num.Text.Trim, "添加发酵罐") '储存到日志
        End If

        Me.Close()
    End Sub

#Region "原料"
    Private Sub tb_i234a_pttph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_pttph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.001' or tb_i259b_i231a='2.04.001' ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "葡萄糖")
    End Sub

    Private Sub tb_i234a_lmsph_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_i234a_lmsph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "(tb_i259b_i231a='2.06.002' or  tb_i259b_i231a ='2.07.045' ) ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "柠檬酸")
    End Sub
    Private Sub tb_i234a_gasnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_gasnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.004'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "谷氨酸钠")
    End Sub

    Private Sub tb_i234a_xpjph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_xpjph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.022'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "消泡剂")
    End Sub
    Private Sub tb_i234a_tsqnph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_tsqnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.007'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "碳酸氢钠")
    End Sub

    Private Sub tb_i234a_lsnph_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_i234a_lsnph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.011'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "硫酸钠")
    End Sub
    Private Sub tb_i234a_lsmph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_lsmph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.005'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "硫酸镁")
    End Sub

    Private Sub tb_i234a_nhgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_nhgph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.008'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氯化钙")
    End Sub

    Private Sub tb_i234a_k303c_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_k303c.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.023'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "硫酸铵")
    End Sub

    Private Sub tb_i234a_j276b_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_i234a_j276b.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.05.009' or tb_i259b_i231a='2.07.044')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氢氧化钠")
    End Sub

    Private Sub tb_i234a_u704m_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_u704m.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氯化钠")
    End Sub

    Private Sub tb_i234a_l344d_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_l344d.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.009'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氯化钾")
    End Sub

    Private Sub tb_i234a_j281b_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_j281b.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.006'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "磷酸二氢钾")
    End Sub
    Private Sub tb_i234a_tgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_tgph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.001'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "糖罐")

        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.003'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "糖罐")
    End Sub
    Private Sub tb_i234a_mph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_mph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.012,2.07.013,2.07.014,2.07.015,2.07.017,2.07.018,2.07.019'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "M（微量金属溶液）")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.001'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "M溶液")
    End Sub

    Private Sub tb_i234a_vph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_vph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.010,2.07.016,2.07.020,2.07.016,2.07.021'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "V（微量维生素溶液）")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.002'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "V溶液")
    End Sub
    Private Sub tb_i234a_suanph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_suanph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.06.002'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "酸罐")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.004'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "酸罐")
    End Sub
    Private Sub tb_i234a_dygph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_dygph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.004'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "氮源罐")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.005'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氮源罐")
    End Sub

    Private Sub tb_i234a_xpjgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_i234a_xpjgph.DoubleClick
        'Dim dt1 As DataTable = Frtb_b970t.getGAtable("'2.07.022'")
        'GS_TCYLLIST2(Me, dt1, CType(sender, Control).Name, "消泡剂罐")
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='1.01.006'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "消泡剂罐")
    End Sub
#End Region



    Private Sub tb_i234a_gh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_i234a_gh.SelectedIndexChanged
        If Labelid.Text = "" Then '修改时候批号不能修改
            Dim qztemp As String = ClassPhgn.ClassPhgn_Get("发酵罐" & tb_i234a_gh.Text, "-") '得到当前批号+1的批号
            If qztemp = "" Then
                MsgBox("批号设定不正确") : Exit Sub
            End If
            tb_i234a_num.Text = qztemp
        End If
    End Sub

    'Private Sub tb_i234a_tgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim aa As New frtangjiang : Me.AddOwnedForm(aa)
    '    Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_tg where tb_tg_yw='否' order by tb_tg_rq desc")
    '    Call ltcsh2(dt1, aa.ListView1, "葡萄糖", tb_i234a_tgph.Text, tb_i234a_tgpttt.Text)
    '    aa.ShowDialog()
    '    tb_i234a_tgpttph.Text = ph.Text : tb_i234a_tgpttt.Text = zl.Text : tb_i234a_tgph.Text = guanph.Text
    '    ph.Text = "" : zl.Text = "" : guanph.Text = ""
    'End Sub
    'Private Sub ywtjg() '改变糖碱罐的状态
    '    'If tgold <> "" Then '原糖罐记录不为空
    '    '    Dim tgph As String = GF_zhzfccx(tgold)
    '    '    Dim sql As String = "update tb_tg set tb_tg_yw='否' where tb_tg_num in(" & tgph & " )"
    '    '    GS_upztxx(G_cnnstr, sql)
    '    'End If
    '    'If jgold <> "" Then '原碱罐记录不为空
    '    '    Dim tgph As String = GF_zhzfccx(jgold)
    '    '    Dim sql As String = "update tb_jg set tb_jg_yw='否' where tb_jg_num in(" & tgph & " )"
    '    '    GS_upztxx(G_cnnstr, sql)
    '    'End If
    '    'If tb_i234a_tgph.Text <> "" Then '现糖罐记录不为空
    '    '    Dim tgph As String = GF_zhzfccx(tb_i234a_tgph.Text)
    '    '    Dim sql As String = "update tb_tg set tb_tg_yw='是' where tb_tg_num in(" & tgph & " )"
    '    '    GS_upztxx(G_cnnstr, sql)
    '    'End If
    '    'If tb_i234a_jgph.Text <> "" Then '现碱罐记录不为空
    '    '    Dim tgph As String = GF_zhzfccx(tb_i234a_jgph.Text)
    '    '    Dim sql As String = "update tb_jg set tb_jg_yw='是' where tb_jg_num in(" & tgph & ")"
    '    '    GS_upztxx(G_cnnstr, sql)
    '    'End If
    'End Sub
    'Private Sub tb_i234a_jgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim aa As New frtangjiang : Me.AddOwnedForm(aa)
    '    Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, "select * from tb_jg where tb_jg_yw='否'  order by tb_jg_rq desc")
    '    Call ltcsh2(dt1, aa.ListView1, "氢氧化钠", tb_i234a_jgph.Text, tb_i234a_jgqyhnpht.Text)
    '    aa.ShowDialog()
    '    tb_i234a_jgqyhnph.Text = ph.Text : tb_i234a_jgqyhnpht.Text = zl.Text : tb_i234a_jgph.Text = guanph.Text
    '    ph.Text = "" : zl.Text = "" : guanph.Text = ""
    'End Sub
    '提取原料重量的ListView
    ' Call ltcsh(dt1, aa.ListView1, "葡萄糖", 批号textbox, 重量textbox)
    '    Private Sub ltcsh2(ByVal db1 As DataTable, ByVal frlv1 As ListView, ByVal str0 As String, ByVal str3 As String, ByVal str4 As String)
    '        Dim strph() As String = Split(str3, ",")
    '        Dim strzl() As String = Split(str4, ",")
    '        With frlv1
    '            .CheckBoxes = True
    '            .Clear() : .Visible = True : .CausesValidation = False : .View = View.Details : .LabelEdit = True
    '            .BeginUpdate()
    '            '.Columns.Add("提取" & str0 & "重量", CType(.Width / 4 - 4, Integer), HorizontalAlignment.Center)
    '            .Columns.Add("罐批号", CType(.Width / 3, Integer), HorizontalAlignment.Center)
    '            .Columns.Add(str0 & "批号", CType(.Width / 3, Integer), HorizontalAlignment.Center)
    '            .Columns.Add(str0 & "重量", CType(.Width / 3, Integer), HorizontalAlignment.Center)
    '            For i As Integer = 0 To db1.Rows.Count - 1
    '                .Items.Add(db1.Rows(i)(1))
    '                .Items(i).SubItems.Add(db1.Rows(i)(3))
    '                .Items(i).SubItems.Add(db1.Rows(i)(5))
    '            Next
    '            .EndUpdate()
    '            For i As Integer = 0 To strph.Length - 1
    '                For j As Integer = 0 To .Items.Count - 1
    '                    If .Items(j).SubItems(0).Text = strph(i) Then
    '                        .Items(j).Checked = True
    '                        GoTo XXX
    '                    End If
    '                Next
    'XXX:
    '            Next
    '        End With
    '    End Sub

   
End Class