Public Class Frtb_x832p
    Public ngthm As String '哪个塔的成品粉
    Public old(0, 1) As String
    Public old2(2, 1) As String
    Dim dt21 As DataTable
    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉'")
        GS_bcfbd(dt, 1, tb_x832p_cplb)
        tb_x832p_cplb.SelectedIndex = 0
        tb_x832p_mingc.SelectedIndex = 0
        tb_x832p_jiagdm.SelectedIndex = 0
    End Sub
    Private Sub tb_x832p_cplb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x832p_cplb.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & sender.text & "'")
        GS_bcfbd(dt, 2, tb_x832p_mingc)
    End Sub
    Private Sub tb_x832p_mingc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_x832p_mingc.SelectedIndexChanged
        Dim dt As DataTable = DeepCode.DeepDoDataTable.GF_czmctb(G_SYCPDMB, "tb_cpdmhz_cpxz='成品粉' and tb_cpdmhz_cplx='" & tb_x832p_cplb.Text & "' and tb_cpdmhz_cpdm='" & sender.text & "'")
        GS_bcfbd(dt, 3, tb_x832p_jiagdm)
    End Sub
    Private Sub Frtb_x832p_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg

        dt21 = GF_CreateDataSource(G_cnnstr, "select * from tb_i259b where tb_i259b_p518h>0 and tb_i259b_qaspjg='合格' and tb_i259b_yxx='有效'") '得到原料表库存大于0
        G_SYCPDMB = GF_CreateDataSource(G_cnnstr, "select * from tb_cpdmhz where tb_cpdmhz_yxx='有效'")

        Dim czid As String = Labelid.Text
        If czid <> "" Then
            Gs_showsj(Labeltb.Text, Me, Labelid.Text)
        End If

        old2(0, 0) = tb_x832p_ybdph.Text
        old2(0, 1) = tb_x832p_ybdpht.Text
        old2(1, 0) = tb_x832p_ypybdph.Text
        old2(1, 1) = tb_x832p_ypybdpht.Text
        old2(2, 0) = tb_x832p_yjlbdph.Text
        old2(2, 1) = tb_x832p_yjlbdpht.Text
        'If ngthm = "34号塔成品粉" Then
        '    tb_x832p_z886r.Enabled = False
        'End If
        tb_x832p_l349d.Text = 0
        tb_x832p_y864q.Text = 0

        AddHandler tb_x832p_fgfph.DoubleClick, AddressOf addFangongfen
    End Sub
    Private Sub addFangongfen(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql As String = "select 0 as 使用重量,tb_x832pkc_num,tb_x832pkc_cjcl,tb_x832pkc_jgrq,'KG' as 单位,tb_x832pkc_ID,tb_x832pkc_cplb,tb_x832pkc_mingc from tb_x832pkc where " &
         "tb_x832pkc_cjcl>0 and tb_x832pkc_qaytjy='返工'"
        Dim dt As DataTable = sql.YanGetDb

        Dim objClpam As New frYanPhzl.CLphzlPam
        objClpam.souserDt = dt
        objClpam.titleText = "返工粉"
        objClpam.phName = "tb_x832p_fgfph"
        objClpam.bsName = "tb_x832p_fyfbs"
        objClpam.callbackFn = Function(pTb As DataTable, pfr As frYanPhzl) As Boolean
                                  pfr.setOwnerVa()
                                  If tb_x832p_sbtb.Text = "tb_x832pkc" Then
                                      'Me.tb_x832p_sbid.Text = pTb.Select("convert(使用重量,'System.Double')>0").YanArrDrToDb.YanDtToStr("tb_fangong_ID")
                                      Me.tb_x832p_sbid.Text = pfr.m_rvBs
                                  End If
                              End Function
        GS_TCYLLIST_yan(Me, objClpam)
    End Sub

    Private Sub SSSQX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQX.Click
        Me.Close()
    End Sub
    Private Sub SSSQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SSSQD.Click
        If MsgBox("确定更新数据吗？", 1, "提示") <> 1 Then
            Exit Sub
        End If
        '’‘’‘’‘’‘’‘’‘ 判定批号是否为8位
        Dim sr As String = tb_x832p_num.Text
        Dim zf() As Char = sr.ToCharArray()
        If zf.Length <> 6 Then
            MsgBox("批号必须为6位数！") : Exit Sub
        End If

        '然后除以每批投入量(Kg)
        If ngthm <> "34号塔成品粉" Then
            Dim i232a As Decimal = Cl_StrMag.YanFormatNum(tb_x832p_i232a.Text)
            Dim l349d As Decimal = Cl_StrMag.YanFormatNum(tb_x832p_l349d.Text)
        End If
        '’‘’‘’‘’‘’‘’‘’‘合计汇总
        GS_hjkcylkc(tb_x832p_ybdph, tb_x832p_ybdzl, Me)
        GS_hjkcylkc(tb_x832p_ypybdph, tb_x832p_ypybdzl, Me)
        GS_hjkcylkc(tb_x832p_yjlbdph, tb_x832p_yjlbdzl, Me)
        GS_hjkcylkc(tb_x832p_bzjjm, tb_x832p_bzjjmzl, Me)
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        If Labelid.Text <> "" Then
            ''''''''''''''''''''
            If GF_storelog1("修改成品粉") = False Then
                Exit Sub
            End If ' 判断是否有权限
            GS_sancusql(old2) ''''还原原料
            ''''''''''''''''''''''''判断原料库存是否够
            Dim ylstr As String = Gf_pdylkc(tb_x832p_ybdph, Me) & Gf_pdylkc(tb_x832p_ypybdph, Me) & Gf_pdylkc(tb_x832p_yjlbdph, Me)
            If ylstr <> "" Then
                GS_hycusql(old2) ''''反还原原料
                MsgBox(ylstr) : Exit Sub
            End If
            '''''''''''''''''''''
            '''''''''''''''''''''
            If GF_modsj(Labeltb.Text, Me, Labelid.Text) = False Then
                GS_hycusql(old2) '反还原原料
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            '更新喷雾时间
            Dim sql As String = "update tb_p525h set tb_p525h_jgrq='" & tb_x832p_pwkssj.Text & "',tb_p525h_b967t='" & tb_x832p_pwjssj.Text & "' " & _
                " where tb_p525h_glid='" & Labelid.Text & "'"
            GS_upztxx(G_cnnstr, sql)

            GS_kcylkc(tb_x832p_ybdph, Me) '更新原料库存
            GS_kcylkc(tb_x832p_ypybdph, Me) '更新原料库存
            GS_kcylkc(tb_x832p_yjlbdph, Me) '更新原料库存
            GS_kcylkc(tb_x832p_bzjjm, Me) '更新原料库存
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", Labelid.Text, G_dlrgh) '更新操作人工号
            GS_storelog3("修改成品粉：" & tb_x832p_num.Text.Trim, "修改成品粉") '储存到日志
        Else
            If GF_storelog1("添加成品粉") = False Then
                Exit Sub
            End If ' 判断是否有权限
            '''''''''''''''''''''
            '如果没有选择小批，那么返工粉不能为空
            If Labelid2.Text = "" Then
                If tb_x832p_fgfph.Text = "" Then
                    MsgBox("没有选择小批的情况下返工粉不能为空！")
                    Exit Sub
                End If
            End If
            If GF_YZSJ3(Me, "tb_x832p_i232a") = False Then
                Return
            End If
            If GF_cxph("tb_x832p_num", tb_x832p_num.Text.Trim) = True Then '检测批号重复性
                MsgBox("数据库内已经存在该数据，请重新输入！") : Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''''
            Dim jj As String = GF_addsj(Labeltb.Text, Me)
            If jj = "" Then
                MsgBox("请检查输入项目及数据") : Exit Sub
            End If
            GS_modczsj(Labeltb.Text, Labeltb.Text & "_czrgh", jj, G_dlrgh) '更新操作人工号
            GS_storelog3("添加成品粉：" & tb_x832p_num.Text.Trim, "添加成品粉") '储存到日志
            Dim sql As String = ""
            If Labelid2.Text <> "" Then
                '更新粉剂小批表中的“下步表ID”字段
                sql = "update tb_p525h set tb_p525h_glid='" & jj & "', tb_p525h_xbtb='tb_x832p' where  tb_p525h_Id in(" & Labelid2.Text & ")"
                GS_upztxx(G_cnnstr, sql)
            End If
            '更新喷雾时间
            sql = "update tb_p525h set tb_p525h_jgrq='" & tb_x832p_pwkssj.Text & "',tb_p525h_b967t='" & tb_x832p_pwjssj.Text & "' " & _
                " where tb_p525h_glid='" & jj & "'"
            GS_upztxx(G_cnnstr, sql)

            GS_kcylkc(tb_x832p_ybdph, Me) '更新原料库存
            GS_kcylkc(tb_x832p_ypybdph, Me) '更新原料库存
            GS_kcylkc(tb_x832p_yjlbdph, Me) '更新原料库存
            GS_kcylkc(tb_x832p_bzjjm, Me) '更新原料库存
            '更新返工粉
            GS_yanUpdatePhzl(Me, "tb_x832pkc_cjcl", tb_x832p_fyfbs, tb_x832p_fgfpht, pBszd:="id")
            '更新进度表
            cl_theCl.saveBb(en_saveBb.成品粉生产进度2, jj)
        End If

        Me.Close()
    End Sub
    Private Function ggetph(ByVal str As String) As String
        Dim qztemp As String = ""
        Dim xh1 As String = ""
        Dim qsz As String = ""
        If str = "1号塔成品粉" Then
            xh1 = ClassPhgn.ClassPhgn_GetQz("1号塔成品粉") '序号前面部分
            qsz = ClassPhgn.ClassPhgn_GetDqz("1号塔成品粉") '起始值
        Else
            xh1 = ClassPhgn.ClassPhgn_GetQz("34号塔成品粉") '序号前面部分
            qsz = ClassPhgn.ClassPhgn_GetDqz("34号塔成品粉") '起始值
        End If
        qsz = qsz + 1
        ggetph = xh1 & GF_PF_bzhs(qsz, 6, "0") & "0"
    End Function
    Private Sub gxdpph(ByVal str As String) '更新起始值
        Dim qztemp As String = ""
        If str = "1号塔成品粉" Then
            qztemp = "1号塔成品粉"
        Else
            qztemp = "34号塔成品粉"
        End If
  ClassPhgn.ClassPhgn_SetDqz2(qztemp) '更新起始值
    End Sub

    Private Sub ltcsh33(ByVal db1 As DataTable, ByVal frlv1 As ListView, ByVal str0 As String, ByVal str1 As Integer, ByVal str2 As Integer, ByVal str3 As String, ByVal str4 As String)
        Dim strph() As String = Split(str3, ",")
        Dim strzl() As String = Split(str4, ",")
        With frlv1
            .Clear() : .Visible = True : .CausesValidation = False : .View = View.Details : .LabelEdit = True
            .BeginUpdate()
            .Columns.Add("提取数", CType(.Width / 4 - 4, Integer), HorizontalAlignment.Center)
            .Columns.Add("大批批次", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add("零头", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            .Columns.Add("塔号", CType(.Width / 4, Integer), HorizontalAlignment.Center)
            For i As Integer = 0 To db1.Rows.Count - 1
                .Items.Add(0)
                .Items(i).SubItems.Add(db1.Rows(i)(str1))
                .Items(i).SubItems.Add(db1.Rows(i)(str2))
                .Items(i).SubItems.Add(Null2String(db1.Rows(i)(str2 + 1)))

            Next
            .EndUpdate()
            For i As Integer = 0 To strph.Length - 1
                For j As Integer = 0 To .Items.Count - 1
                    If .Items(j).SubItems(1).Text = strph(i) Then
                        .Items(j).SubItems(0).Text = strzl(i)
                        GoTo XXX
                    End If
                Next
XXX:
            Next
        End With
    End Sub

    Private Sub tb_x832p_ybdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_ybdph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt21, " (tb_i259b_i231a='3.08.002' or tb_i259b_i231a='3.08.101')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "5KG粉剂铝箔袋")
    End Sub

    Private Sub tb_x832p_ypybdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_ypybdph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt21, " (tb_i259b_i231a='3.08.003' or tb_i259b_i231a='3.08.102' )")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "1KG粉剂铝箔袋")
    End Sub


    Private Sub tb_x832p_yjlbdph_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_yjlbdph.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt21, " (tb_i259b_i231a='3.08.020' or tb_i259b_i231a='3.08.103')")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "优粉铝箔袋")
    End Sub

    Private Sub tb_x832p_bzjjm_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_bzjjm.DoubleClick
        Dim dt1 As DataTable = GF_czmctb(dt21, "tb_i259b_i231a='3.08.022'")
        GS_TCYLLIST(Me, dt1, CType(sender, Control).Name, "包装机卷膜")
    End Sub

    Private Sub tb_x832p_num_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_x832p_num.MouseLeave
        ph.Text = UCase(ph.Text)
    End Sub
End Class