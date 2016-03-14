Public Class FrYJ_jlts
    Public old(5, 1) As String
    Dim dt As DataTable
    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub FrYJ_jlts_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        Dim sql As String = "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效' " '库存大于0
        dt = GF_CreateDataSource(G_cnnstr, sql) '得到原料表
        setvalue("tb_k306c_u716m", 0)
        setvalue("tb_k306c_c27u", 1)
        setvalue("tb_k306c_s626k", 2)
        setvalue("tb_k306c_t653l", 3)
        setvalue("tb_k306c_h217z", 4)
        setvalue("tb_k306c_jiwanph", 5)

        If Labelid.Text = "" Then
            tb_k306c_num.Text = ClassPhgn.ClassPhgn_Get("精炼", "-") '得到当前批号+1的批号
            AddHandler tb_k306c_num.DoubleClick,
                Sub()
                    ClassPhgn.ClassPhgn_SetDqz2("精炼") '使当前批号+1
                    tb_k306c_num.Text = ClassPhgn.ClassPhgn_Get("精炼", "-") '得到当前批号+1的批号
                End Sub
        Else
            sql = "select * from tb_mypl where tb_mypl_num=(select tb_k306c_num2 from vw_k306c where tb_k306c_ID=" & Labelid.Text & ")"
            tb_mypl_num2.Text = Cl_DataMag.GF_CreateDataSource(sql).YanDtValue2("tb_mypl_num2")
        End If

        If tb_k306c_jgrq.Text = "" Then
            tb_k306c_jgrq.Text = _S.YanForDa_2(DateTime.Now)
        End If

        AddHandler tb_k306c_fgfph.DoubleClick, AddressOf addFangongfen
    End Sub
    Private Sub addFangongfen(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql As String = "select 0 as 使用重量,tb_h195zkc_num,tb_h195zkc_cjcl,tb_h195zkc_jgrq,'KG' as 单位,tb_h195zkc_ID,tb_h195zkc_cplb,tb_h195zkc_mingc from tb_h195zkc where " &
         "tb_h195zkc_cjcl>0 and tb_h195zkc_qaytjy='返工'"
        Dim dt As DataTable = sql.YanGetDb

        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = dt
        objClpam.titleText = "返工油"
        objClpam.phName = "tb_k306c_fgfph"
        objClpam.bsName = "tb_k306c_fgfbs"
        objClpam.callbackFn = Function(pTb As DataTable, pfr As frYanPhzl) As Boolean
                                  pfr.setOwnerVa()
                                  If tb_k306c_sbtb.Text = "tb_h195zkc" Then
                                      Me.tb_k306c_sbid.Text = pfr.m_rvBs
                                  End If
                              End Function
        GS_TCYLLIST_yan(Me, objClpam)
    End Sub
    Private Sub setvalue(ylph As String, wd As Integer)
        old(wd, 0) = Me.Controls(ylph).Text
        old(wd, 1) = Me.Controls(ylph & "t").Text
    End Sub
#Region "原料添加"
    Private Sub tb_k306c_c27u_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_k306c_c27u.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.06.005'or tb_i259b_i231a='2.06.010' or tb_i259b_i231a='2.07.041'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "二氧化硅（干胶）")
    End Sub

    Private Sub tb_k306c_h217z_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_k306c_h217z.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.05.009' or tb_i259b_i231a='2.07.044')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "氢氧化钠")
    End Sub

    Private Sub tb_k306c_s626k_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_k306c_s626k.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.06.007' or tb_i259b_i231a='2.07.040'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "活性炭")
    End Sub

    Private Sub tb_k306c_u716m_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_k306c_u716m.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, "(tb_i259b_i231a='2.06.002' or tb_i259b_i231a ='2.07.045' ) ")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "柠檬酸")
    End Sub
    Private Sub tb_k306c_t653l_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_k306c_t653l.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt, " (tb_i259b_i231a='2.06.003' or  tb_i259b_i231a='2.07.038')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "活性白土")
    End Sub
    'Private Sub tb_k306c_jiwanph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_k306c_jiwanph.DoubleClick
    '    Dim dt1 As DataTable = GF_czmctb(dt, "tb_i259b_i231a='2.07.024'")
    '    GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "己烷")
    'End Sub
#End Region

    Private Sub modfikucun() '更新库存
        GS_kcylkc(tb_k306c_u716m, Me) '更新原料库存
        GS_kcylkc(tb_k306c_c27u, Me) '更新原料库存
        GS_kcylkc(tb_k306c_s626k, Me) '更新原料库存
        GS_kcylkc(tb_k306c_t653l, Me) '更新原料库存
        GS_kcylkc(tb_k306c_h217z, Me) '更新原料库存
        GS_kcylkc(tb_k306c_jiwanph, Me) '更新原料库存
    End Sub

    Private Sub SSSQD_Click(sender As System.Object, e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '''''''''判断必填''''''''''''
        If tb_mypl_num2.Text = "" And tb_k306c_fgfph.Text = "" Then
            MsgBox("没有选择批次的情况下返工油不能为空！", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If GF_YZSJ3(Me, "tb_k306c_num,tb_k306c_t678l") = False Then '验证控件
            Exit Sub
        End If
        ''''''''''''''''''''合计汇总
        GS_hjkcylkc(tb_k306c_u716m, tb_k306c_m398e, Me)
        GS_hjkcylkc(tb_k306c_c27u, tb_k306c_d39v, Me)
        GS_hjkcylkc(tb_k306c_s626k, tb_k306c_j299c, Me)
        GS_hjkcylkc(tb_k306c_t653l, tb_k306c_r574j, Me)
        GS_hjkcylkc(tb_k306c_h217z, tb_k306c_z903r, Me)
        GS_hjkcylkc(tb_k306c_jiwanph, tb_k306c_jiwanphzl, Me)

        If Labelid.Text <> "" Then
            If GF_cxph("tb_k306c_num", tb_k306c_num.Text.Trim, Labelid.Text) Then '检测批号重复性
                MsgBox("数据库内已经存在该数据，请重新输入！", MsgBoxStyle.Exclamation) : Exit Sub
            End If
            ''''''''''''''''''''
            GS_sancusql(old) ''''还原原料
            ''''''''''''''''''''''''判断原料库存是否够
            Dim ylstr As String = Gf_pdylkc(tb_k306c_u716m, Me) & Gf_pdylkc(tb_k306c_c27u, Me)
            ylstr = ylstr & Gf_pdylkc(tb_k306c_s626k, Me) & Gf_pdylkc(tb_k306c_t653l, Me)
            ylstr = ylstr & Gf_pdylkc(tb_k306c_h217z, Me) & Gf_pdylkc(tb_k306c_jiwanph, Me)
            If ylstr <> "" Then
                GS_hycusql(old) '反还原原料
                MsgBox(ylstr) : Exit Sub
            End If
            '还原返工油库存
            Dim sql As String = "select * from tb_k306c where tb_k306c_ID=" & Labelid.Text
            Dim dt As DataTable = sql.YanGetDb
            If dt.Rows.Count > 0 And dt.YanDtValue2("tb_k306c_fgfbs") <> "" And dt.YanDtValue2("tb_k306c_fgfpht") <> "" Then
                Dim tArrPh As String() = dt.YanDtValue2("tb_k306c_fgfbs").Split
                Dim tArrZl As String() = dt.YanDtValue2("tb_k306c_fgfpht").Split
                For i As Integer = 0 To tArrPh.Length - 1
                    _D.GS_upztxx("update tb_h195zkc set tb_h195zkc_cjcl=tb_h195zkc_cjcl+" & tArrZl(i) & " where tb_h195zkc_ID='" & tArrPh(i) & "'")
                Next
            End If
            ''''''''''''''''''''''''''''''''''''

            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then '修改数据
                GS_hycusql(old) '反还原原料
                MsgBox("请检查输入项目及数据")
                Exit Sub
            Else
                modfikucun() '更新库存
                '更新返工油库存
                GS_yanUpdatePhzl(Me, "tb_h195zkc_cjcl", tb_k306c_fgfbs, tb_k306c_fgfpht, pBszd:="id")
                GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
                GS_storelog3("修改精炼：" & tb_k306c_num.Text.Trim, "修改精炼") '储存到日志
            End If
        Else
            '返工油添加
            If GF_cxph("tb_k306c_num", tb_k306c_num.Text.Trim) Then '检测批号重复性
                MsgBox("数据库内已经存在该数据，请重新输入！", MsgBoxStyle.Exclamation) : Exit Sub
            End If

            Dim tNewBs As String = _D.GF_addsj(Labeltb.Text, Me)
            If tNewBs = "" Then '修改数据
                MsgBox("请检查输入项目及数据")
                Exit Sub
            End If
            '更新返工油库存
            GS_yanUpdatePhzl(Me, "tb_h195zkc_cjcl", tb_k306c_fgfbs, tb_k306c_fgfpht, pBszd:="id")
            ClassPhgn.ClassPhgn_SetDqz2("精炼") '使当前批号+1
            modfikucun() '更新库存扣除原料
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", tNewBs, G_dlrgh) '更新操作人工号
            GS_storelog3("添加精炼：" & tb_k306c_num.Text.Trim, "添加精炼") '储存到日志
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

End Class