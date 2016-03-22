Public Class Frtb_tuoxiu
    Dim dt As DataTable
    Public old(8, 1) As String '这里定义的是原料
    Public old2(2, 1) As String '这里定义的是原料罐
    '得到某原料代码对应的罐，共享的过程，适合任何原料罐，如2.07.001就是糖罐
    Public Shared Function getGAtable(ByVal yldm As String) As DataTable
        Dim sql As String = "select  tb_tg_ID,tb_tg_yldm,tb_tg_rq,tb_tg_yw,tb_tg_hsgx,tb_tg_num,tb_tg_tj,tb_tg_ph,tb_tg_pht"
        sql &= " from tb_tg where tb_tg_tj>0 and tb_tg_zl>0 and tb_tg_yw='否' and tb_tg_yldm=" & yldm & ""
        Dim dt1 As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        Return dt1
    End Function
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub UI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        tb_tuoxiu_jgrq.BringToFront()

        If Labelid.Text = "" Then
            tb_tuoxiu_num.Text = ClassPhgn.ClassPhgn_Get("脱臭", "-") '得到当前批号+1的批号
            AddHandler tb_tuoxiu_num.DoubleClick,
                Sub()
                    ClassPhgn.ClassPhgn_SetDqz2("脱臭") '使当前批号+1
                    tb_tuoxiu_num.Text = ClassPhgn.ClassPhgn_Get("脱臭", "-") '得到当前批号+1的批号
                End Sub
        End If

        GS_qhjd(Me) '回车键切换焦点，备注除外
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)

        If tb_tuoxiu_jgrq.Text = "" Then
            tb_tuoxiu_jgrq.Text = _S.YanForDa_2(DateTime.Now)
        End If

        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表

        setvalue("tb_tuoxiu_vsse", 0)

        AddHandler tb_tuoxiu_fgfph.DoubleClick, AddressOf addFangongfen
    End Sub
    Private Sub addFangongfen(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql As String = "select 0 as 使用重量,tb_h195zkc_num,tb_h195zkc_cjcl,tb_h195zkc_jgrq,'KG' as 单位,tb_h195zkc_ID,tb_h195zkc_cplb,tb_h195zkc_mingc from tb_h195zkc where " &
         "tb_h195zkc_cjcl>0 and tb_h195zkc_qaytjy='返工'"
        Dim dt As DataTable = sql.YanGetDb

        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = dt
        objClpam.titleText = "返工油"
        objClpam.phName = "tb_tuoxiu_fgfph"
        objClpam.bsName = "tb_tuoxiu_fgfbs"
        objClpam.callbackFn = Function(pTb As DataTable, pfr As frYanPhzl) As Boolean
                                  pfr.setOwnerVa()
                                  If tb_tuoxiu_sbtb.Text = "tb_h195zkc" Then
                                      Me.tb_tuoxiu_sbid.Text = pfr.m_rvBs
                                  End If
                              End Function
        GS_TCYLLIST_yan(Me, objClpam)
    End Sub
    Private Sub setvalue(ByVal ylph As String, ByVal wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
    Private Sub modfikucun() '更新原料库存
        '''''''''''''''''''''''''''''''''''扣除原料
        GS_kcylkc(tb_tuoxiu_vsse, Me) '更新原料库存
        GS_kcylkc(tb_tuoxiu_zlsz, Me) '更新原料库存
        GS_kcylkc(tb_tuoxiu_msx, Me) '更新原料库存
        GS_kcylkc(tb_tuoxiu_khzy, Me) '更新原料库存
        GS_kcylkc(tb_tuoxiu_llz, Me) '更新原料库存
    End Sub

#Region "原料添加"
    Private Sub tb_tuoxiu_vsse_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_tuoxiu_vsse.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.036'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "维生素E")
    End Sub
    Private Sub tb_tuoxiu_zlsz_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_tuoxiu_zlsz.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.07.035' or tb_i259b_i231a='2.07.047' )")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "抗坏血酸棕榈酸酯 ")
    End Sub
    Private Sub tb_tuoxiu_msx_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_tuoxiu_msx.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.043'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "迷失香提取物")
    End Sub
    Private Sub tb_tuoxiu_khzy_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_tuoxiu_khzy.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.028' or tb_i259b_i231a='2.07.037'  ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "葵花籽油")
    End Sub
    Private Sub tb_tuoxiu_llz_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_tuoxiu_llz.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.06.011' or tb_i259b_i231a='2.07.042')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "卵磷脂")
    End Sub
#End Region

    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填''''''''''''
        If tb_tuoxiu_num2.Text = "" And tb_tuoxiu_fgfph.Text = "" Then
            MsgBox("没有选择批次的情况下返工油不能为空！", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If GF_YZSJ3(Me, "tb_tuoxiu_num,tb_tuoxiu_zl") = False Then '验证控件
            Exit Sub
        End If

        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_tuoxiu_vsse, tb_tuoxiu_vssezl, Me)
        GS_hjkcylkc(tb_tuoxiu_zlsz, tb_tuoxiu_zlszzl, Me)
        GS_hjkcylkc(tb_tuoxiu_msx, tb_tuoxiu_msxzl, Me)
        GS_hjkcylkc(tb_tuoxiu_khzy, tb_tuoxiu_khzyzl, Me)
        GS_hjkcylkc(tb_tuoxiu_llz, tb_tuoxiu_llzzl, Me)

        If Labelid.Text <> "" Then
            If GF_cxph("tb_tuoxiu_num", tb_tuoxiu_num.Text.Trim, Labelid.Text) Then '检测批号重复性
                MsgBox("数据库内已经存在该数据，请重新输入！", MsgBoxStyle.Exclamation) : Exit Sub
            End If
            Dim ylstr As String = Gf_pdylkc(tb_tuoxiu_vsse, Me)
            ylstr &= Gf_pdylkc(tb_tuoxiu_zlsz, Me) & Gf_pdylkc(tb_tuoxiu_msx, Me)
            ylstr &= Gf_pdylkc(tb_tuoxiu_khzy, Me) & Gf_pdylkc(tb_tuoxiu_llz, Me)
            If ylstr <> "" Then
                GS_hycusql(old) '反还原原料
                MsgBox(ylstr) : Exit Sub
            End If
            '还原返工油库存
            Dim sql As String = "select * from tb_tuoxiu where tb_tuoxiu_ID=" & Labelid.Text
            Dim dt As DataTable = sql.YanGetDb
            If dt.Rows.Count > 0 And dt.YanDtValue2("tb_tuoxiu_fgfbs") <> "" And dt.YanDtValue2("tb_tuoxiu_fgfpht") <> "" Then
                Dim tArrPh As String() = dt.YanDtValue2("tb_tuoxiu_fgfbs").Split
                Dim tArrZl As String() = dt.YanDtValue2("tb_tuoxiu_fgfpht").Split
                For i As Integer = 0 To tArrPh.Length - 1
                    _D.GS_upztxx("update tb_h195zkc set tb_h195zkc_cjcl=tb_h195zkc_cjcl+" & tArrZl(i) & " where tb_h195zkc_ID='" & tArrPh(i) & "'")
                Next
            End If
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                GS_hycusql(old) '反还原原料
                GS_hycusql2(old2) '反还原原料罐
                MsgBox("请检查输入项目及数据") : Exit Sub
            Else
                modfikucun() '更新库存扣除原料
                '更新返工油库存
                GS_yanUpdatePhzl(Me, "tb_h195zkc_cjcl", tb_tuoxiu_fgfbs, tb_tuoxiu_fgfpht, pBszd:="id")

                If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据

                    MsgBox("请检查输入项目及数据")
                    Exit Sub
                Else
                    GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
                    GS_storelog3("修改脱臭：" & tb_tuoxiu_num.Text.Trim, "修改脱臭") '储存到日志
                End If
            End If
        Else
            '使用返工油新增
            If GF_cxph("tb_tuoxiu_num", tb_tuoxiu_num.Text.Trim) = True Then '检测批号重复性
                MsgBox("数据库内已经存在该数据，请重新输入！") : Exit Sub
            End If

            Dim tNewBs As String = _D.GF_addsj(Labeltb.Text, Me)
            If tNewBs = "" Then '修改数据
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            '更新返工油库存
            GS_yanUpdatePhzl(Me, "tb_h195zkc_cjcl", tb_tuoxiu_fgfbs, tb_tuoxiu_fgfpht, pBszd:="id")
            ClassPhgn.ClassPhgn_SetDqz2("脱臭") '使当前批号+1
            modfikucun() '更新库存扣除原料
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", tNewBs, G_dlrgh) '更新操作人工号
            GS_storelog3("添加冬化：" & tb_tuoxiu_num.Text.Trim, "添加冬化") '储存到日志
        End If
        ''''''''''''''''''''''''''''''''''''
        MyBase.Close()
    End Sub

End Class