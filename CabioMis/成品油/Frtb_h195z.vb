Public Class Frtb_h195z
    Dim dt As DataTable
    Public old(4, 1) As String
    Private Sub Frtb_h195z_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        GS_qhjd(Me) '回车键切换焦点，备注除外

        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品油' and tb_cpdmhz_cplx='DOGF'")
        GS_bcfbd(dt2, 2, tb_h195z_mingc)

        Dim czid As String = Labelid.Text

        If czid <> "" Then '修改时候批号不能修改
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        Else
            tb_h195z_num.Text = ClassPhgn.ClassPhgn_Get("成品油", "-") '得到当前批号+1的批号
            AddHandler tb_h195z_num.DoubleClick,
                Sub()
                    ClassPhgn.ClassPhgn_SetDqz2("成品油") '使当前批号+1
                    tb_h195z_num.Text = ClassPhgn.ClassPhgn_Get("成品油", "-") '得到当前批号+1的批号
                End Sub
        End If

        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        ''''''''''''''''''''''''''''''''''''''''''这里是为了修改而保存的原始值

        setvalue("tb_h195z_y878r", 0)
        setvalue("tb_h195z_o460g", 1)
        setvalue("tb_h195z_g179y", 2)
        setvalue("tb_h195z_llzph", 3)
        setvalue("tb_h195z_swcsph", 4)

        tb_h195z_jgrq.BringToFront

        AddHandler tb_h195z_fgfph.DoubleClick, AddressOf addFangongfen
    End Sub
    Private Sub addFangongfen(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql As String = "select 0 as 使用重量,tb_h195zkc_num,tb_h195zkc_cjcl,tb_h195zkc_jgrq,'KG' as 单位,tb_h195zkc_ID,tb_h195zkc_cplb,tb_h195zkc_mingc from tb_h195zkc where " &
         "tb_h195zkc_cjcl>0 and tb_h195zkc_qaytjy='返工'"
        Dim dt As DataTable = sql.YanGetDb

        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = dt
        objClpam.titleText = "返工油"
        objClpam.bsName = "tb_h195z_fgfbs"
        objClpam.phName = "tb_h195z_fgfph"
        objClpam.callbackFn = Function(pTb As DataTable, pfr As frYanPhzl) As Boolean
                                  pfr.setOwnerVa()
                                  If tb_h195z_sbtb.Text = "tb_h195zkc" Then
                                      Me.tb_h195z_sbid.Text = pfr.m_rvBs
                                  End If
                              End Function
        GS_TCYLLIST_yan(Me, objClpam)
    End Sub
    Private Sub tb_x832p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_mingc.SelectedIndexChanged
        Dim dt2 As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品油' and tb_cpdmhz_cplx='DOGF' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt2, 3, tb_h195z_jiagdm)
    End Sub

    Private Sub setvalue(ByVal ylph As String, ByVal wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
    Private Sub modfikucun() '更新库存
        '''''''''''''''''''''''''''''''''''扣除原料
        GS_kcylkc(tb_h195z_y878r, Me) '更新原料库存
        GS_kcylkc(tb_h195z_o460g, Me) '更新原料库存
        GS_kcylkc(tb_h195z_g179y, Me) '更新原料库存
        GS_kcylkc(tb_h195z_llzph, Me) '更新原料库存
        GS_kcylkc(tb_h195z_swcsph, Me) '更新原料库存
    End Sub
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        tb_h195z_hblsrkzl.Text = tb_h195z_m408e.Text
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        ' '''''''''判断必填''''''''''''
        If tb_h195z_num2.Text = "" And tb_h195z_fgfph.Text = "" Then
            MsgBox("没有选择批次的情况下返工油不能为空！", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If GF_YZSJ3(Me, "tb_h195z_num,tb_h195z_m408e") = False Then
            Return
        End If

        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_h195z_o460g, tb_h195z_p495h, Me)
        GS_hjkcylkc(tb_h195z_y878r, tb_h195z_c998u, Me)
        GS_hjkcylkc(tb_h195z_g179y, tb_h195z_b989t, Me)
        GS_hjkcylkc(tb_h195z_llzph, tb_h195z_llzzl, Me)

        GS_hjkcylkc(tb_h195z_swcsph, tb_h195z_swcsphzl, Me)


        If Labelid.Text <> "" Then
            ''''''''''''''''''''
            '''''''''''''''''''''''''''''
            'If GF_storelog1("修改成品油") = False Then
            '    Exit Sub
            'End If ' 判断是否有权限
            GS_sancusql(old) ''''还原原料
            ''''''''''''''''''''''''判断原料库存是否够
            Dim ylstr As String = Gf_pdylkc(tb_h195z_o460g, Me) & Gf_pdylkc(tb_h195z_y878r, Me) & Gf_pdylkc(tb_h195z_g179y, Me) & Gf_pdylkc(tb_h195z_llzph, Me)
            ylstr &= Gf_pdylkc(tb_h195z_swcsph, Me)
            If ylstr <> "" Then
                GS_hycusql(old) ''''反还原原料
                MsgBox(ylstr) : Exit Sub
            End If
            '''''''''''''''''''''
            '09/11/24成品油收率计算公式有变，应该收率Weight=成品油重量*100/(毛油投入重量+返工油重量+调配用油)
            'tb_h195z_u704m.Text = FormatNumber(Null2zero2(tb_h195z_m408e.Text) * 100 / (Null2zero2(tb_h195z_n426f.Text) + Null2zero2(tb_h195z_e95w.Text) + Null2zero2(tb_h195z_tpyy.Text)), 2)
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                GS_hycusql(old) '反还原原料
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            modfikucun()

            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改成品油：" & tb_h195z_num.Text.Trim, "修改成品油") '储存到日志
        Else
            ''''''''''''''''添加成品油'''''''''''''
            If GF_cxph("tb_h195z_num", tb_h195z_num.Text.Trim) = True Then
                MsgBox("数据库内已经存在该批号，请重新输入！") : Exit Sub
            End If

            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            '更新原料库存
            modfikucun()
            '更新返工油库存
            GS_yanUpdatePhzl(Me, "tb_h195zkc_cjcl", tb_h195z_fgfbs, tb_h195z_fgfpht, pBszd:="id")
            ClassPhgn.ClassPhgn_SetDqz2("成品油") '使当前批号+1
            If Labeltb2.Text <> "tb_jch" Then
                GS_gengsb(Labeltb2.Text, Labelid2.Text, Labeltb.Text, jj)   '更新上步流程
            Else
                Dim sql As String = "update tb_jch set tb_jch_fgyph='" & tb_h195z_num.Text.Trim & "' where tb_jch_ID='" & Labelid2.Text & "'"
                Cl_DataMag.GS_upztxx(sql)
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加成品油：" & tb_h195z_num.Text.Trim, "添加成品油") '储存到日志
        End If
        Me.DialogResult = DialogResult.OK
        'Me.Close()
    End Sub

    Private Sub tb_h195z_o460g_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_o460g.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.028' or tb_i259b_i231a='2.07.037'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "葵花籽油")
    End Sub

    Private Sub tb_h195z_g179y_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_g179y.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.07.035' or tb_i259b_i231a='2.07.047' )")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "抗坏血酸棕榈酸酯 ")
    End Sub

    Private Sub tb_h195z_y878r_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_y878r.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.036'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "维生素E")
    End Sub

    Private Sub tb_h195z_llzph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_h195z_llzph.DoubleClick

        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.06.011' or tb_i259b_i231a='2.07.042'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "卵磷脂")
    End Sub

    Private Sub tb_h195z_swcsph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_h195z_swcsph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.043'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "迷失香提取物")
    End Sub

    'Private Sub tb_h195z_ybd5kgph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_h195z_ybd5kgph.DoubleClick
    '    Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='3.08.001'")
    '    GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "油剂铝箔袋")
    'End Sub

    'Private Sub tb_h195z_ypybdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_h195z_ypybdph.DoubleClick
    '    Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='3.08.003'")
    '    GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "1KG粉剂铝箔袋")
    'End Sub


    Private Sub tb_h195z_fgyph_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_h195z_y876r.LostFocus
        '判断输入的返工油批号是否正确
        If tb_h195z_y876r.Text = "" Then
            Return
        End If
        For i As Integer = 0 To tb_h195z_y876r.Text.Split(",").Length - 1
            Dim sql As String = "select * from tb_jch where tb_jch_cz='出' and tb_jch_num='" & tb_h195z_y876r.Text.Split(",")(i) & "' and tb_jch_yt='返工(混入新批中)'"
            Dim dt As DataTable = Cl_DataMag.GF_CreateDataSource(sql)
            If dt.Rows.Count = 0 Then
                MsgBox("没有符合要求的成品油！")
                tb_h195z_e95w.Text=""
                tb_h195z_y876r.Text=""
                Return
            End If
            tb_h195z_e95w.Text &= dt.Rows(0)("tb_jch_sl") & ","

        Next
        tb_h195z_e95w.Text = DeepCode.DeepDoStr.GF_removedh(tb_h195z_e95w.Text)
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub
End Class