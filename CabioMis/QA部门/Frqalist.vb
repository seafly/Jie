Public Class Frqalist
    Private bm As String
    Private m_wpDt As DataTable = Nothing
    Private namepp As String
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub
    Private Sub Frqalist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GF_storelog1("QA界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        '切换菜单与关闭菜单的加载
        GF_OpenFaceList2(tsMenu)
        '加载BC菜单
        bcDropDown.Image = Frqc_list.ToolStripButton8.Image
        'Dim sql As String = "select a.*,b.tb_wp_pm from tb_gxsz as a left join tb_wp as b on a.tb_gxsz_wpbs=b.tb_wp_ID order by tb_gxsz_px"
        Dim sql As String = "select a.tb_gxcccp_wpbs,b.* from (select distinct tb_gxcccp_wpbs from tb_gxcccp) as a " &
            "left join tb_wp as b on a.tb_gxcccp_wpbs=b.tb_wp_ID " &
        " where tb_wp_isQa='是' order by tb_wp_dm"
        Dim dt As DataTable = sql.YanGetDb
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim q As ToolStripDropDownItem = bcDropDown.DropDownItems.Add(dt.YanDtValue2("tb_wp_pm", i))
            q.Tag = dt.Rows(i).YanDrToDb
            AddHandler q.Click, Sub(s As System.Object, ev As System.EventArgs)
                                    namepp = "BC"
                                    bm = "tb_wlph"
                                    m_wpDt = s.tag
                                    showsj()
                                End Sub

            Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        Next
        ''''''''''''''''''''''''''''''
        tb_x832p_qaspjg.Items.Add("待定")
        tb_x832p_qaspjg.Items.Add("合格")
        tb_x832p_qaspjg.Items.Add("不合格")
        tb_x832p_qaspjg.SelectedIndex = 0
        AddHandler tb_x832p_qaspjg.SelectedIndexChanged,
            Sub()
                If namepp = en_LcTableName.成品粉.ToString Or namepp = en_LcTableName.成品油.ToString Or namepp = "BC" Then
                    showsj()
                End If
            End Sub
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        namepp = "原料"
        bm = "tb_i259b"
        weizhi()
        showsj()
    End Sub

    Private Sub weizhi()
        GroupBox2.Width = Me.Width - GroupBox2.Left - 10
        GroupBox3.Top = GroupBox2.Bottom + 10
        GroupBox3.Height = Me.Height - GroupBox3.Top - 40
        GroupBox3.Width = Me.Width - GroupBox3.Left - 10
        ListView3.Width = GroupBox3.Width - 5
        ListView3.Height = GroupBox3.Height - 45
    End Sub

    Private Sub Frqalist_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        weizhi()
    End Sub

    '毛油
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        namepp = "毛油" : bm = "tb_x825p" : showsj()
    End Sub
    '成品油
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        namepp = "成品油" : bm = "tb_h195z" : showsj()
    End Sub
    ''成品粉混批计划
    'Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
    '    namepp = "成品粉混批计划" : bm = "tb_pljh" : showsj()
    'End Sub
    '成品粉 中检测小批
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        namepp = "成品粉小批" : bm = "tb_p525h" : showsj()
    End Sub
    '显示上面一个LISTVIEW的
    Private Sub showsj()
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序

        If namepp = en_LcTableName.成品粉.ToString Or namepp = en_LcTableName.成品油.ToString Or namepp = "BC" Then
            tb_x832p_qaspjg.Enabled = True
        Else
            tb_x832p_qaspjg.SelectedIndex = 0
            tb_x832p_qaspjg.Enabled = False
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        GS_FaceSearch(ComboBoxserchtext, bm, 1) '文本查询函数：关联表的文本字段的显示
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim sql As String = ""
        GroupBox2.Text = "QA待检测：" & namepp
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        Select Case namepp
            Case "原料"
                sql = "select tb_i259b_ID,tb_i259b_r596j,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_num2,tb_i259b_kczl,tb_i259b_scs,tb_i259b_y840q,tb_i259b_f122x,tb_i259b_qaspjg,tb_i259b_qajgsm,tb_i259b_bz from tb_i259b" _
           & " where (tb_i259b_qaspjg='待定' or tb_i259b_qaspjg='冻结' )  and right(tb_i259b_r596j,2) = '原料' and tb_i259b_qcsh = '是'"
            Case "包材"
                sql = "select tb_i259b_ID,tb_i259b_r596j,tb_i259b_i231a,tb_i259b_c24u,tb_i259b_h200z,tb_i259b_num,tb_i259b_num2,tb_i259b_kczl,tb_i259b_scs,tb_i259b_y840q,tb_i259b_f122x,tb_i259b_bz,tb_i259b_qcrq,tb_i259b_czrgh from tb_i259b" _
           & " where (tb_i259b_qaspjg='待定' or tb_i259b_qaspjg='冻结' ) and  right(tb_i259b_r596j,2) = '包材' and tb_i259b_qcsh = '是'"
            Case "毛油"
                sql = "select tb_x825p_ID,tb_x825p_num,tb_x825p_num2,tb_x825p_jgrq,tb_x825p_r583j,tb_x825p_s640k,tb_x825p_qarq,tb_x825p_qaspjg,tb_x825p_qajgsm from tb_x825p " _
           & " where (tb_x825p_qaspjg='待定' or tb_x825p_qaspjg='冻结' )  and tb_x825p_qcsh='是'"
            Case "成品油"
                sql = "select tb_h195z_ID,tb_h195z_num2,tb_h195z_cplb,tb_h195z_mingc,tb_h195z_jiagdm,tb_h195z_num,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_e95w,tb_h195z_o460g," &
                    "tb_h195z_p495h,tb_h195z_y878r,tb_h195z_c998u,tb_h195z_g179y,tb_h195z_b989t,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_u704m,tb_h195z_q554i,tb_h195z_t673l," &
                    "tb_h195z_bz,tb_h195z_qarq,tb_h195z_qaspjg,tb_h195z_qaytjy,tb_h195z_qajgsm from tb_h195z "
                If tb_x832p_qaspjg.Text <> en_qaJg.待定.ToString Then
                    sql &= "where tb_h195z_num in (select tb_h195z_num from tb_h195z as a left join tb_h195zkc as b on a.tb_h195z_num=b.tb_h195zkc_num " &
                    " where  tb_h195z_qaspjg='" & tb_x832p_qaspjg.Text & "' and (tb_h195zkc_sykczl is null or tb_h195zkc_sykczl>0))"
                Else
                    sql &= " where (tb_h195z_qaspjg='待定' or tb_h195z_qaspjg='冻结' )  and tb_h195z_qcsh='是'"
                End If
                sql &= " order by tb_h195z_qarq desc"
            Case "成品粉"
                sql = "select tb_x832p_ID,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_cplb,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_num,tb_x832p_scdm,tb_x832p_bz,tb_x832p_qarq,tb_x832p_qaspjg,tb_x832p_qajgsm,tb_x832p_qaytjy,tb_x832p_hms,tb_x832p_remark from tb_x832p "
                If tb_x832p_qaspjg.Text <> en_qaJg.待定.ToString Then
                    sql &= "where tb_x832p_num in (select tb_x832p_num from tb_x832p as a left join tb_x832pkc as b on a.tb_x832p_num=b.tb_x832pkc_num" & vbCrLf & _
                    " where  tb_x832p_qaspjg='" & tb_x832p_qaspjg.Text & "' and (tb_x832pkc_sykczl is null or tb_x832pkc_sykczl>0))"
                Else
                    sql &= "where (tb_x832p_qaspjg='待定' or tb_x832p_qaspjg='冻结') and tb_x832p_qcsh='是'"
                End If
                sql &= " order by tb_x832p_qarq desc"
            Case "成品粉小批"
                sql = "select tb_p525h_ID,tb_p525h_num,tb_p525h_num2,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_qarq,tb_p525h_qaspjg,tb_p525h_u721n,tb_p525h_qajgsm  from tb_p525h where  " & _
                    "tb_p525h_qcsh='是'  and (tb_p525h_qaspjg='待定' or tb_p525h_qaspjg='冻结' )"
            Case "成品粉混批计划"
                sql = "select tb_pljh_ID,tb_pljh_num,tb_pljh_rq,tb_pljh_ph,tb_pljh_phzl, tb_pljh_czrgh from tb_pljh where (tb_pljh_qaspjg='待定' or tb_pljh_qaspjg='冻结'  or tb_pljh_qaspjg='不合格')"
            Case "BC"
                sql = "select tb_wlph_ID,tb_wlph_wpbs,tb_wlph_wpdm,tb_wlph_wlph,tb_wlph_cjfs,tb_wlph_sl,tb_wlph_ftime," &
                    "tb_qa_ftime,tb_qa_qaspjg,tb_qa_qaytjy,tb_qa_czr,tb_qa_qajgsm " &
                    " from tb_wlph as a left join tb_qa as b on a.tb_wlph_ID=b.tb_qa_wlbs " &
                    " where tb_wlph_wpbs='" & m_wpDt.YanDtValue2("tb_gxcccp_wpbs") & "' "
                If m_wpDt.YanDtValue2("tb_wp_isQc") = "是" Then
                    sql &= "and tb_wlph_ID in (select tb_QcJc_wlbs from tb_QcJc where tb_QcJc_jcb='tb_wlph' and tb_QcJc_sfsh='是') "
                End If
                If tb_x832p_qaspjg.Text = en_qaJg.待定.ToString Then
                    sql &= " and (tb_wlph_ID not in (select tb_qa_wlbs from tb_qa) or tb_wlph_ID in (select tb_qa_wlbs from tb_qa " &
                        "where tb_qa_qaspjg='" & en_qaJg.待定.ToString & "'))"
                Else
                    sql &= " and tb_wlph_ID in (select tb_qa_wlbs from tb_qa where tb_qa_qaspjg='" & tb_x832p_qaspjg.Text & "')"
                End If

        End Select
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        GS_useviewbydb2(ListView2, dt, 0, 100)
        ''''''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' 更新最后一次操作时间
    End Sub

    '双击弹出QA检测
    Private Sub ListView2_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
        If ListView2.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        ''验证锁定
        'If GF_MakeIsSD(bm, ListView2.SelectedItems(0).SubItems(0).Text) = False Then
        '    Exit Sub
        'End If

        Select Case namepp
            Case "原料"
                Dim nform As New Frtb_ylqa
                nform.Labeltb.Text = bm
                nform.Labelid.Text = ListView2.SelectedItems(0).SubItems(0).Text
                nform.m_lb = ListView2.SelectedItems(0).SubItems(1).Text
                ''''下面为QC显示记录准备
                nform.qcbiao.Text = "tb_t676l"
                nform.qczd.Text = "tb_t676l_num"
                nform.qcph.Text = ListView2.SelectedItems(0).SubItems(5).Text
                nform.m_jcbNum = -1
                nform.m_wldm = GF_GetListText(ListView2, "tb_i259b_i231a")
                nform.ShowDialog()
                showsj()
            Case "包材"
                Dim nform As New Frtb_ylqa
                nform.Labeltb.Text = bm
                nform.Labelid.Text = ListView2.SelectedItems(0).SubItems(0).Text
                ''''下面为QC显示记录准备
                nform.qcbiao.Text = "tb_bcQC"
                nform.qczd.Text = "tb_bcQC_num"
                nform.qcph.Text = ListView2.SelectedItems(0).SubItems(5).Text
                nform.m_jcbNum = -1
                nform.m_wldm = GF_GetListText(ListView2, "tb_i259b_i231a")
                nform.ShowDialog()
                showsj()
            Case "毛油"
                Dim nform As New Frtb_ylqa
                nform.Labeltb.Text = bm
                nform.Labelid.Text = ListView2.SelectedItems(0).SubItems(0).Text
                ''''下面为QC显示记录准备
                nform.qcbiao.Text = "tb_x825p"
                nform.biao2 = "tb_x825pkc"
                nform.qcph.Text = ListView2.SelectedItems(0).SubItems(1).Text
                nform.qczd.Text = "tb_x825p_num"
                nform.m_jcbNum = en_LcTableName.毛油
                nform.ShowDialog()
                showsj()
            Case "成品油"
                Dim nform As New Frtb_ylqa
                nform.Labeltb.Text = bm
                nform.Labelid.Text = ListView2.SelectedItems(0).SubItems(0).Text
                ''''下面为QC显示记录准备
                nform.qcbiao.Text = "tb_h195z"
                nform.biao2 = "tb_h195zkc"
                nform.qcph.Text = ListView2.SelectedItems(0).SubItems(5).Text
                nform.qczd.Text = "tb_h195z_num"
                nform.m_jcbNum = en_LcTableName.成品油
                nform.ShowDialog()
                showsj()
            Case "成品粉"
                Dim nform As New Frtb_ylqa
                nform.Labeltb.Text = bm
                nform.Labelid.Text = ListView2.SelectedItems(0).SubItems(0).Text
                ''''下面为QC显示记录准备
                nform.qcbiao.Text = "tb_x832p"
                nform.biao2 = "tb_x832pkc"
                nform.qcph.Text = ListView2.SelectedItems(0).SubItems(7).Text
                nform.qczd.Text = "tb_x832p_num"
                nform.m_jcbNum = en_LcTableName.成品粉
                nform.ShowDialog()
                showsj()
            Case "成品粉小批"
                Dim nform As New Frtb_ylqa
                nform.Labelid.Text = ListView2.SelectedItems(0).SubItems(0).Text
                nform.Labeltb.Text = "tb_p525h"
                'nform.ShowDialog()
                ''''下面为QC显示记录准备
                nform.qcbiao.Text = "tb_p525h"
                nform.qcph.Text = ListView2.SelectedItems(0).SubItems(1).Text
                nform.qczd.Text = "tb_p525h_num"
                nform.m_jcbNum = en_LcTableName.粉剂小批
                nform.ShowDialog()
                showsj()
            Case "成品粉混批计划"
                Dim nform As New FrQA2
                nform.Labelid.Text = ListView2.SelectedItems(0).SubItems(0).Text
                nform.tb_pljh_num.Text = ListView2.SelectedItems(0).SubItems(1).Text
                nform.ShowDialog()
            Case "BC"
                Dim nform As New Frqa_Add
                nform.m_wlbs = ListView2.SelectedItems(0).SubItems(0).Text
                If nform.ShowDialog() = DialogResult.OK Then
                    showsj()
                End If
        End Select
    End Sub


    Private Sub showsearch(ByVal tt1 As String, ByVal tt2 As String)
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序


        Dim showwhat As String = ""
        If tt1 = tt2 Then
            showwhat = "QA记录查询：" & tt1 & namepp
        Else
            showwhat = "QA记录查询：" & tt1 & "至" & tt2 & namepp
        End If
        GroupBox3.Text = showwhat
        Dim bmzd As String = bm & "_qarq" '得到取样时间字段
        Dim sql As String = "select " & bm & "_ID," & bm & "_num," & bm & "_qarq," & bm & "_qaspjg," & bm & "_qajgsm ," & bm & "_qaczrgh"
        Select Case namepp '查询原料的时候显示类别名称数量字段
            Case "原料"
                sql = sql & ",tb_i259b_r596j,tb_i259b_c24u,tb_i259b_p518h,tb_i259b_kczl from " & bm & " where " & bmzd & " between '" & tt1 & "' and '" & tt2 & "' and right(tb_i259b_r596j,2) = '原料' and  tb_i259b_qaspjg<>'待定'"
            Case "包材"
                sql = sql & ",tb_i259b_r596j,tb_i259b_c24u,tb_i259b_p518h,tb_i259b_kczl from " & bm & " where " & bmzd & " between '" & tt1 & "' and '" & tt2 & "' and right(tb_i259b_r596j,2)='包材'and  tb_i259b_qaspjg<>'待定'"
            Case "成品粉混批计划"
                sql = sql & ",tb_pljh_rq,tb_pljh_num,tb_pljh_ph,tb_pljh_phzl,tb_pljh_qczx, tb_pljh_czrgh  from " & bm & " where " & bmzd & " between '" & tt1 & "' and '" & tt2 & "'and " & bm & "_qaspjg<>'待定' "
            Case "成品粉小批"
                sql = sql & ",tb_p525h_dpbfl from " & bm & " where " & bmzd & " between '" & tt1 & "' and '" & tt2 & "' "
            Case "BC"
                sql = "select tb_wlph_ID,tb_wlph_wpbs,tb_wlph_wpdm,tb_wlph_wlph,tb_wlph_cjfs,tb_wlph_sl,tb_wlph_ftime," &
                    "tb_qa_ftime,tb_qa_qaspjg,tb_qa_qaytjy,tb_qa_czr,tb_qa_qajgsm " &
                    " from tb_wlph as a left join tb_qa as b on a.tb_wlph_ID=b.tb_qa_wlbs " &
                    " where tb_wlph_wpbs='" & m_wpDt.YanDtValue2("tb_gxcccp_wpbs") & "' "
                sql &= " and tb_wlph_ID in (select tb_qa_wlbs from tb_qa where tb_qa_qaspjg<>'" & en_qaJg.待定.ToString & "' and tb_qa_qaspjg is not null)"
                sql &= " and tb_qa_ftime between '" & tt1 & "' and '" & tt2 & "'"
            Case Else
                sql = sql & "  from " & bm & " where " & bmzd & " between '" & tt1 & "' and '" & tt2 & "' and " & bm & "_qaspjg<>'待定' "
        End Select

        '''''''''''''''''''''''''''''''''''''''''''''''
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext)
        sql = sql & sqlbdssep '文本查询函数：挂接到查询文本
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)

        'GS_useviewbydb2(ListView3, dt, 0, 150)
        GS_DataGridViewbyDb(ListView3, dt, "0", True, True)
        ''''''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' 更新最后一次操作时间
    End Sub



    Private Sub Buttsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttsearch.Click
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        showsearch(tt1, tt2)
    End Sub




    Private Sub showform(ByVal str As String)
        Dim nform As New Frshowadd
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & str & "'", 2) '得到表中文意思
        nform.TextBox1.Text = str
        nform.ShowDialog()
    End Sub
    Private Sub INSERT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSERT1.Click
        '''''''''''''''''''''
        If GF_storelog2("查询MOC台账", "查询MOC台账") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        Call showform("tb_tz")
    End Sub


    Private Sub INSERT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSERT2.Click
        '''''''''''''''''''''
        If GF_storelog2("查询偏差台账", "查询偏差台账") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        Call showform("tb_pctz")
    End Sub

    'Private Sub INSERT3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INSERT3.Click
    '    '''''''''''''''''''''
    '    If GF_storelog2("查询食品安全质量（FSQ）审核改进情况统计表", "查询食品安全质量（FSQ）审核改进情况统计表") = False Then
    '        Exit Sub
    '    End If
    '    ''''''''''''''''''''''
    '    Call showform("tb_spaqnwsh")
    'End Sub

    Private Sub wsButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wsButton3.Click
        '''''''''''''''''''''
        If GF_storelog2("查询现场检查发现项跟踪系统", "查询现场检查发现项跟踪系统") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        Call showform("tb_jcfxx")
    End Sub


    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView3, DateTimePicker1.Text & "至" & DateTimePicker2.Text, Me)
    End Sub

    Private Sub ylMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ylMenuItem.Click
        namepp = "原料" : bm = "tb_i259b" : showsj()
    End Sub

    Private Sub bcMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcMenuItem.Click
        namepp = "包材" : bm = "tb_i259b" : showsj()
    End Sub

    Private Sub CustomerComplaintsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerComplaintsToolStripMenuItem.Click
        '''''''''''''''''''''
        'If GF_storelog2("查询Customer complaints", "查询Customer complaints") = False Then
        '    Exit Sub
        'End If
        ''''''''''''''''''''''
        Call showform("tb_QAcc")
        'Dim nform As New frQAcc
        'nform.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        namepp = "成品粉" : bm = "tb_x832p" : showsj()
    End Sub

    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolHelp.Click
        GS_Help("QA部")
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub

    Private Sub MenuItemWJQD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemWJQD.Click
        '''''''''''''''''''''
        If GF_storelog2("查询文件清单", "查询文件清单") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        Call showform("tb_xtwjqd")
    End Sub

    Private Sub MenuItemKHTSJL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemKHTSJL.Click
        '''''''''''''''''''''
        If GF_storelog2("查询客户投诉记录", "查询客户投诉记录") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        Call showform("tb_khtsjlb")
    End Sub

    Private Sub MenuItemGYSSHTZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemGYSSHTZ.Click
        '''''''''''''''''''''
        If GF_storelog2("查询供应商现场审核台账", "查询供应商现场审核台账") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''

        Call showform("tb_gysshtz")
    End Sub

    Private Sub MenuItemFSQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemFSQ.Click
        '''''''''''''''''''''
        If GF_storelog2("查询查询FSQ内审", "查询查询FSQ内审") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        Call showform("tb_fsq")
    End Sub

    Private Sub MenuItemWBSHQK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemWBSHQK.Click
        '''''''''''''''''''''
        If GF_storelog2("查询外部审核情况", "查询外部审核情况") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        Call showform("tb_2009nwbshqktj")
    End Sub
End Class