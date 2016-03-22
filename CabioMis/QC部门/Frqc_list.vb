Public Class Frqc_list
    Private bm As String
    Private namepp As String
    Private m_wpDt As DataTable = Nothing   '点击BC工艺QC时需要的数据
    Private m_jcbNum As Integer = -1   '检测项目类型(当检测类型为原成品或原工序的时候会赋枚举值)
    Public m_ListDt As DataTable = Nothing   '列表的DT
    '窗体的关闭
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '窗体的关闭
    End Sub
    Private Sub Frqc_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        If GF_storelog1("QC界面") = False Then
            Me.Close() : Exit Sub
        End If ' 判断是否有权限
        ''''''''''''''''''''''''''''''
        GF_OpenFaceList2(tsMenu) '切换菜单与关闭菜单的加载
        bcDropDown.Image = Me.ToolStripButton8.Image
        '添加BC工艺
        Dim sql As String = "select * from tb_gxsz where tb_gxsz_isqc='是'  order by tb_gxsz_px"
        Dim dt As DataTable = sql.YanGetDb
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim q As ToolStripDropDownItem = bcDropDown.DropDownItems.Add(dt.YanDtValue2("tb_gxsz_mc", i))
            q.Tag = dt.Rows(i).YanDrToDb
            AddHandler q.Click, Sub(s As System.Object, ev As System.EventArgs)
                                    namepp = "BC工艺"
                                    bm = "tb_gxsz"
                                    m_wpDt = s.tag
                                    m_jcbNum = -2
                                    showsj()
                                End Sub

        Next
        '添加分割线
        'bcDropDown.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {New ToolStripSeparator})
        namepp = "原料" : bm = "tb_t676l"
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

    Private Sub Frqc_list_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        weizhi()
    End Sub

    '小罐
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        namepp = "小罐"
        bm = "tb_y864q"
        m_jcbNum = en_LcTableName.一级罐生产
        showsj()
    End Sub
    '中罐
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        namepp = "中罐"
        bm = "tb_f123x"
        m_jcbNum = en_LcTableName.二级罐生产
        showsj()
    End Sub
    '大罐
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        namepp = "大罐"
        bm = "tb_q546i"
        m_jcbNum = en_LcTableName.发酵罐生产
        showsj()
    End Sub
    '酶解QC
    Private Sub TSB_MJQC_Click(sender As System.Object, e As System.EventArgs) Handles TSB_MJQC.Click
        namepp = "酶解"
        bm = "tb_meijie"
        m_jcbNum = en_LcTableName.酶解
        showsj()
    End Sub
    '毛油
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        namepp = "毛油"
        bm = "tb_x825p"
        m_jcbNum = en_LcTableName.毛油
        showsj()
    End Sub

    '精炼
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        namepp = "精炼"
        bm = "tb_k306c"
        m_jcbNum = en_LcTableName.精炼
        showsj()
    End Sub
    '冬化QC
    Private Sub TSB_DHQC_Click(sender As System.Object, e As System.EventArgs) Handles TSB_DHQC.Click
        namepp = "冬化"
        bm = "tb_donghua"
        m_jcbNum = en_LcTableName.冬化
        showsj()
    End Sub
    '脱臭QC
    Private Sub TSB_TSQC_Click(sender As System.Object, e As System.EventArgs) Handles TSB_TSQC.Click
        namepp = "脱臭"
        bm = "tb_tuoxiu"
        m_jcbNum = en_LcTableName.脱臭
        showsj()
    End Sub
    '成品油
    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        namepp = "成品油"
        bm = "tb_h195z"
        m_jcbNum = en_LcTableName.成品油
        showsj()
    End Sub

    Private Sub excel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles excel2.Click
        namepp = "四号塔内"
        bm = "tb_p525h"
        m_jcbNum = en_LcTableName.粉剂小批
        showsj()
    End Sub

    Private Sub web1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles web13131.Click
        namepp = "三号塔内"
        bm = "tb_p525h"
        m_jcbNum = en_LcTableName.粉剂小批
        showsj()
    End Sub
    Private Sub tb5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb5.Click
        namepp = "五号塔内"
        bm = "tb_p525h"
        m_jcbNum = en_LcTableName.粉剂小批
        showsj()
    End Sub
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        bm = "tb_x832p"
        namepp = "成品粉"
        m_jcbNum = en_LcTableName.成品粉
        showsj()
    End Sub
    Private Function gzshowbds(bm As String) As String
        Dim bds As String = "select " & bm & "_ID," & bm & "_num," & bm & "_num2," & bm & "_jgrq," & bm & "_bz  from " & bm & "  where " & bm & "_qcsh = '否'"
        Return bds
    End Function
    '填充上面的LISTVIEW
    Private Sub showsj()
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        GS_FaceSearch(ComboBoxserchtext, bm, 1) '文本查询函数：关联表的文本字段的显示,旧版查询数据准备
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        ListView2.CheckBoxes = (bm = "tb_p525h")

        Dim tDt As New DataTable
        tDt.Columns.Add("tText")
        tDt.Columns.Add("tTag")
        ComboBox1.Items.Clear()
        Select Case m_jcbNum
            Case -1 '原料
                'tb_i259b_i231a,tb_i259b_c24u,tb_i259b_num
                tDt.Rows.Add("批号", "tb_i259b_num")
                tDt.Rows.Add("物料代码", "tb_i259b_i231a")
                tDt.Rows.Add("物料名称", "tb_i259b_c24u")

                Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.物品)
                For Each dr As DataRow In tBqcxm.Rows
                    tDt.Rows.Add(dr("tb_QcXm_xmmc"), "")
                Next
                '将检测项目表的内容全部添加进来
                GS_wlbktlr2(ComboBox1, tDt, 0, "") '显示字段中文名
                ComboBox1.Tag = tDt
            Case -2
                tDt.Rows.Add("生产单号", "tb_sc_dh")
                Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.工艺 & _
                                                                         " and tb_QcXm_wpbs='" & m_wpDt.YanDtValue2("tb_gxsz_ID") & "'")
                For Each dr As DataRow In tBqcxm.Rows
                    tDt.Rows.Add(dr("tb_QcXm_xmmc"), "")
                Next
                '将检测项目表的内容全部添加进来
                GS_wlbktlr2(ComboBox1, tDt, 0, "") '显示字段中文名
                ComboBox1.Tag = tDt
            Case -3
                tDt.Rows.Add("批号", "tb_wlph_wlph")
                Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.物品)
                For Each dr As DataRow In tBqcxm.Rows
                    tDt.Rows.Add(dr("tb_QcXm_xmmc"), "")
                Next
                '将检测项目表的内容全部添加进来
                GS_wlbktlr2(ComboBox1, tDt, 0, "") '显示字段中文名
                ComboBox1.Tag = tDt
            Case Else
                tDt.Rows.Add("批号", GetType(en_LcTableName).YanGetEnText(m_jcbNum) & "_num")
                Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.工序 & _
                                                                         " and tb_QcXm_wldm='" & GetType(en_LcTableName).YanGetEnName(m_jcbNum) & "'")
                For Each dr As DataRow In tBqcxm.Rows
                    tDt.Rows.Add(dr("tb_QcXm_xmmc"), "")
                Next
                '将检测项目表的内容全部添加进来
                GS_wlbktlr2(ComboBox1, tDt, 0, "") '显示字段中文名
                ComboBox1.Tag = tDt
        End Select

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim sql As String = ""
        Dim boBox As Boolean = False

        Select Case namepp
            Case "原料"
                'sql = "select tb_t676l_id, tb_t676l_num,tb_t676l_x836q,tb_t676l_p497h,tb_t676l_l345d,tb_t676l_qcsh from tb_t676l where tb_t676l_qcsh='否'  and  tb_t676l_num not in (select tb_i259b_num from tb_i259b where tb_i259b_r596j='油剂原料' or tb_i259b_r596j='发酵原料') "
                sql = "select * from tb_i259b where tb_i259b_qcsh='否' and tb_i259b_qaspjg='待定' and tb_i259b_r596j like '%原料%'"
            Case "包材"
                'sql = "select tb_bcQC_id, tb_bcQC_num,tb_bcQC_m386e,tb_bcQC_k338d,tb_bcQC_w792o,tb_bcQC_qcsh  from tb_bcQC where  tb_bcQC_qcsh ='否' "
                sql = "select * from tb_i259b where tb_i259b_qcsh='否' and tb_i259b_qaspjg='待定' and tb_i259b_r596j like '%包材%'"
            Case "小罐"
                sql = "select tb_b970t_ID,tb_b970t_num,tb_b970t_jgrq,tb_b970t_bz from tb_b970t  where tb_b970t_qcsh='否' "
            Case "中罐"
                sql = "select tb_b959t_ID,tb_b959t_num,tb_b959t_num2,tb_b959t_jgrq,tb_b959t_bz from tb_b959t  where tb_b959t_qcsh='否'"
            Case "大罐"
                sql = "select tb_i234a_ID,tb_i234a_num,tb_i234a_num2,tb_i234a_jgrq,tb_i234a_bz  from tb_i234a  where tb_i234a_qcsh= '否'"
            Case "酶解", "冬化", "脱臭"
                sql = gzshowbds(bm)
            Case "毛油"
                sql = "select tb_x825p_ID,tb_x825p_num,tb_x825p_num2,tb_x825p_jgrq,tb_x825p_r583j,tb_x825p_s640k,tb_x825p_bz,tb_x825p_qcsh from tb_x825p  where tb_x825p_qcsh ='否' order by tb_x825p_jgrq desc   "
            Case "精炼"
                sql = "select tb_k306c_ID,tb_k306c_num,tb_k306c_num2,tb_k306c_jgrq,tb_k306c_bz from vw_k306c where tb_k306c_qcsh='否'"
            Case "成品油"
                sql = "select tb_h195z_ID,tb_h195z_num,tb_h195z_cplb,tb_h195z_mingc,tb_h195z_jiagdm,tb_h195z_num2,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_bz,tb_h195z_qcsh from vw_h195z where tb_h195z_qcsh='否' order by tb_h195z_jgrq desc "
            Case "三号塔内"
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_bz  from tb_p525h where tb_p525h_th='3号塔' and tb_p525h_qcsh='否'"
                boBox = True
            Case "四号塔内"
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_bz  from tb_p525h where tb_p525h_th='4号塔' and tb_p525h_qcsh='否'"
                boBox = True
            Case "五号塔内"
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_bz  from tb_p525h where tb_p525h_th='5号塔' and tb_p525h_qcsh='否'"
                boBox = True
            Case "成品粉"
                sql = "select tb_x832p_ID,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_cplb,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_num,tb_x832p_scdm,tb_x832p_jgrq,tb_x832p_sjqa,tb_x832p_kss,tb_x832p_nxam,tb_x832p_bz,tb_x832p_qcsh,tb_x832p_hyn,tb_x832p_midu,tb_x832p_vcna from vw_x832p  where tb_x832p_qcsh='否' order by tb_x832p_jgrq "
            Case "BC工艺"
                sql = "select a.tb_sc_ID,b.tb_gxsz_ID,a.tb_sc_dh,a.tb_sc_ftime,b.tb_gxsz_mc from tb_sc as a left join tb_gxsz as b on a.tb_sc_gxbs=b.tb_gxsz_ID " &
                    "where tb_sc_gxbs='" & m_wpDt.YanDtValue2("tb_gxsz_ID") & "' and tb_sc_ID not in " &
                    "(select tb_QcJc_wlbs from tb_QcJc where tb_QcJc_jcb='tb_sc' and tb_QcJc_sfsh='是')"
            Case "BC过程品", "BC成品"
                sql = "select tb_wlph_ID,b.tb_wp_ID,b.tb_wp_pm,tb_wlph_wlph,tb_wlph_cjfs,tb_wlph_sl,tb_wlph_ftime " &
                    "from tb_wlph as a left join tb_wp as b on a.tb_wlph_wpbs=b.tb_wp_ID " &
                    "where tb_wp_isqc='是' and tb_wp_wpfl='" & namepp.Replace("BC", "") & "' and tb_wlph_ID not in (select tb_QcJc_wlbs from tb_QcJc where tb_QcJc_jcb='tb_wlph' and tb_QcJc_sfsh='是') " &
                    "and case when tb_wlph_cjtb<>'tb_sc' then 0 else " &
                    "case when exists(select * from tb_wlph where tb_wlph_ID=a.tb_wlph_ID and tb_wlph_cjbs in " &
                    "(select tb_sc_ID from tb_sc where tb_sc_isEnd='" & en_sczt.完成.ToString & "')) " &
                    "then 0	else 1	end end=0"
        End Select
        GroupBox2.Text = "QC待检测：" & namepp
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        m_ListDt = dt
        Select Case namepp
            Case "BC工艺"
                dt.Columns.Add("产出批号")
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim tDtph As DataTable = _D.GF_CreateDataSource("select * from tb_scxq where tb_scxq_lx='产出' and tb_scxq_scbs=" & dt.YanDtValue2("tb_sc_ID", i))
                    dim tSph As String=""
                    For j As Integer = 0 To tDtph.Rows.Count - 1
                        tSph &= tDtph.YanDtValue2("tb_scxq_value").Split("|")(1) & ","
                    Next
                    dt.Rows(i)("产出批号") = tSph.YanRemovedh
                Next
        End Select

        Dim menu1 As ContextMenuStrip = Nothing

        If boBox Then
            menu1 = New ContextMenuStrip
            menu1.Items.Add("查看明细")
            AddHandler menu1.ItemClicked, AddressOf GS_mendj
            menu1.Items.Add("批量审核")
            AddHandler menu1.ItemClicked, AddressOf update_all
        End If
        GS_useviewbydb2(ListView2, dt, -1, 100, boBox, menu1)
        Select Case namepp
            Case "BC工艺"
                ListView2.Columns(1).Width = 0
            Case "BC过程品"
                ListView2.Columns(1).Width = 0
        End Select
        'If namepp = "原料" Or namepp = "包材" Then
        '    GS_setbackcolor(ListView2, Color.Red, 9)
        'End If
        ''''''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' 更新最后一次操作时间
    End Sub

    Private Sub update_all(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        If e.ClickedItem.Text <> "批量审核" Then
            Return
        End If

        If MsgBox("确定要批量审核吗？", MsgBoxStyle.OkCancel) <> vbOK Then
            Return
        End If

        Dim sql As String = ""
        Dim strIdList As String = ""
        For i As Integer = 0 To ListView2.CheckedItems.Count - 1
            strIdList &= "," & ListView2.CheckedItems(i).SubItems(0).Text
        Next
        strIdList = strIdList.Remove(0, 1)

        Dim nform As New Frtb_n441f
        nform.Labeltb.Text = "tb_p525h"
        nform.Labelid.Text = strIdList
        nform.tb_p525h_num.Text = ListView2.SelectedItems(0).SubItems(2).Text
        nform.tb_p525h_c17u.Text = "0/1×50g"
        nform.ShowDialog()
        showsj()
        'sql = "update tb_p525h set tb_p525h_qcsh='是' where tb_p525h_ID in (" & strIdList & ")"
        'DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, sql)
    End Sub

    '旧版查询
    Private Sub showsearch(ByVal tt1 As String, ByVal tt2 As String)
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        Dim showwhat As String = ""
        If tt1 = tt2 Then
            showwhat = "QC记录查询：" & tt1 & namepp
        Else
            showwhat = "QC记录查询：" & tt1 & "至" & tt2 & namepp
        End If
        GroupBox3.Text = showwhat
        Dim bmzd As String = bm & "_qcrq" '得到取样时间字段
        Dim sql As String = "select "
        Dim sqlbds As String = "*"
        Select Case namepp
            Case "成品油"
                'sqlbds = "tb_h195z_ID,tb_h195z_qcsh,tb_h195z_num2,tb_h195z_num,tb_h195z_cplb,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_e95w,tb_h195z_o460g,tb_h195z_p495h,tb_h195z_y878r,tb_h195z_c998u,tb_h195z_g179y,tb_h195z_b989t,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_u704m,tb_h195z_q554i,tb_h195z_t673l,tb_h195z_bz,tb_h195z_qcrq,tb_h195z_y855q,tb_h195z_c6u,tb_h195z_c28u,tb_h195z_m403e,tb_h195z_b991u,tb_h195z_k309c,tb_h195z_a948s,tb_h195z_j268b,tb_h195z_l356d,tb_h195z_o485g,tb_h195z_h192z,tb_h195z_g158y,tb_h195z_d36v,tb_h195z_qarq,tb_h195z_qaspjg,tb_h195z_qajgsm,tb_h195z_yg,tb_h195z_bzxs,tb_h195z_cfdd,tb_h195z_rkts,tb_h195z_rkbz,tb_h195z_kczl,tb_h195z_sykczl,tb_h195z_czrgh,tb_h195z_o460gt,tb_h195z_y878rt,tb_h195z_g179yt,tb_h195z_qcczrgh,tb_h195z_qaczrgh,tb_h195z_y876r"
                sqlbds = "*"
            Case "精炼"
                'sqlbds = "tb_k306c_ID,tb_k306c_qcsh,tb_k306c_num,tb_k306c_num2,tb_k306c_jgrq,tb_k306c_f125x,tb_k306c_k337d,tb_k306c_m383e,tb_k306c_h217z,tb_k306c_z903r,tb_k306c_c5u,tb_k306c_u716m,tb_k306c_m398e,tb_k306c_v744n,tb_k306c_y860q,tb_k306c_z902r,tb_k306c_d47v,tb_k306c_c27u,tb_k306c_d39v,tb_k306c_s626k,tb_k306c_j299c,tb_k306c_t653l,tb_k306c_r574j,tb_k306c_t678l,tb_k306c_qarq,tb_k306c_qaspjg,tb_k306c_qajgsm,tb_k306c_glid,tb_k306c_czrgh,tb_k306c_h217zt,tb_k306c_u716mt,tb_k306c_c27ut,tb_k306c_s626kt,tb_k306c_t653lt,tb_k306c_qaczrgh,tb_k306c_qcrq,tb_k306c_r591j,tb_k306c_d68w,tb_k306c_u714m,tb_k306c_v749n,tb_k306c_s616k,tb_k306c_f133x,tb_k306c_w798p,tb_k306c_p508h,tb_k306c_qcczrgh,tb_k306c_q559i,tb_k306c_bz,tb_k306c_zjcr"
                sqlbds = "*"
            Case "成品粉"
                'sqlbds = "tb_x832p_ID,tb_x832p_qcsh,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_num,tb_x832p_num2,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_jgrq,tb_x832p_qarq,tb_x832p_qaspjg,tb_x832p_qajgsm,tb_x832p_czrgh,tb_x832p_bz,tb_x832p_qaczrgh,tb_x832p_qcrq,tb_x832p_cplb,tb_x832p_d65v,tb_x832p_a948s,tb_x832p_n422f,tb_x832p_s624k,tb_x832p_s644l,tb_x832p_c995u,tb_x832p_s613k,tb_x832p_m381e,tb_x832p_j284b,tb_x832p_c12u,tb_x832p_f119x,tb_x832p_s626k,tb_x832p_e106x,tb_x832p_n446f,tb_x832p_h199z,tb_x832p_o468g,tb_x832p_u691m,tb_x832p_c16u,tb_x832p_k308c,tb_x832p_r599j,tb_x832p_d39v,tb_x832p_qcczrgh,tb_x832p_sjqa,tb_x832p_kss,tb_x832p_nxam,tb_x832p_hms,tb_x832p_remark"
                sqlbds = "*"
            Case "毛油"
                'sqlbds = "tb_x825p_ID,tb_x825p_qcsh,tb_x825p_num,tb_x825p_num2,tb_x825p_jgrq,tb_x825p_d42v,tb_x825p_l349d,tb_x825p_k317c,tb_x825p_r583j,tb_x825p_d68w,tb_x825p_s640k,tb_x825p_w798p,tb_x825p_f144y,tb_x825p_qcrq,tb_x825p_q547i,tb_x825p_u699m,tb_x825p_r600j,tb_x825p_o479g,tb_x825p_b959t,tb_x825p_m387e,tb_x825p_t686m,tb_x825p_qarq,tb_x825p_qaspjg,tb_x825p_qajgsm,tb_x825p_yg,tb_x825p_bzxs,tb_x825p_cfdd,tb_x825p_rkts,tb_x825p_rkbz,tb_x825p_kczl,tb_x825p_sykczl,tb_x825p_czrgh,tb_x825p_qcczrgh,tb_x825p_qaczrgh,tb_x825p_r602j,tb_x825p_cplb,tb_x825p_sn,tb_x825p_bz"
            Case "一号塔内", "三号塔内", "四号塔内", "五号塔内"
                sqlbds = "tb_p525h_ID,tb_p525h_qcsh,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_l362d,tb_p525h_qcrq,tb_p525h_o479g,tb_p525h_g162y,tb_p525h_p499h,tb_p525h_u711m,tb_p525h_i249a,tb_p525h_r591j,tb_p525h_v755n,tb_p525h_s629k,tb_p525h_b966t,tb_p525h_i259b,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_d46v,tb_p525h_bz,tb_p525h_qcczrgh"
            Case "大罐"
                'sqlbds = "tb_q546i_ID,tb_q546i_qcsh,tb_q546i_num,tb_q546i_qcrq,tb_q546i_t651l,tb_q546i_a935s,tb_q546i_r604j,tb_q546i_h209z,tb_q546i_h193z,tb_q546i_q559i,tb_q546i_a941s,tb_q546i_j300c,tb_q546i_x817p,tb_q546i_n455g,tb_q546i_g184z,tb_q546i_n448f,tb_q546i_v744n,tb_q546i_f144x,tb_q546i_czrgh,tb_q546i_bz"
            Case "酶解"
                sqlbds = "tb_meijie_ID,tb_meijie_qcsh,tb_meijie_num,tb_meijie_qcrq,tb_meijie_jj,tb_meijie_zy,tb_meijie_sf,tb_meijie_bz,tb_meijie_qcczrgh"
            Case "冬化"
                sqlbds = "tb_donghua_ID,tb_donghua_qcsh,tb_donghua_num,tb_donghua_qcrq,tb_donghua_rzdha,tb_donghua_rzav,tb_donghua_rzpov,tb_donghua_rzr,tb_donghua_rzy,tb_donghua_rzsf,tb_donghua_yzdha,tb_donghua_qcczrgh"
            Case "脱臭"
                sqlbds = "tb_tuoxiu_ID,tb_tuoxiu_qcsh,tb_tuoxiu_num,tb_tuoxiu_qcrq,tb_tuoxiu_dha,tb_tuoxiu_AV,tb_tuoxiu_POV,tb_tuoxiu_R,tb_tuoxiu_Y,tb_tuoxiu_fszfs,tb_tuoxiu_qcczrgh"
            Case "原料"
                sqlbds = "tb_t676l_id,tb_t676l_num,tb_t676l_x836q,tb_t676l_p497h,tb_t676l_l345d,tb_t676l_qcrq,tb_t676l_f129x,tb_t676l_h204z,tb_t676l_w768o,tb_t676l_t683m,tb_t676l_t681l,tb_t676l_i257a,tb_t676l_r596j,tb_t676l_t686m,tb_t676l_s628k,tb_t676l_s623k,tb_t676l_s617k,tb_t676l_s634k,tb_t676l_j276b,tb_t676l_h206z,tb_t676l_g152y,tb_t676l_i250a,tb_t676l_u688m,tb_t676l_o458g,tb_t676l_h223a,tb_t676l_q556i,tb_t676l_j264b,tb_t676l_c25u,tb_t676l_e88w,tb_t676l_g161y,tb_t676l_y868q,tb_t676l_k338d,tb_t676l_r604j,tb_t676l_a931s,tb_t676l_d70w,tb_t676l_n451f,tb_t676l_f123x,tb_t676l_y869q,tb_t676l_x816p,tb_t676l_xbtb,tb_t676l_glid,tb_t676l_xbrq,tb_t676l_czrgh,tb_t676l_qyl,tb_t676l_d222a,tb_t676l_z882r,tb_t676l_o479g,tb_t676l_sjqa,tb_t676l_longlin,tb_t676l_ajd,tb_t676l_yjl,tb_t676l_c5,tb_t676l_qcsh"
                sqlbds = " * "
            Case "DHA原料"
                sqlbds = ""
            Case "包材"
                sqlbds = "tb_bcQC_id,tb_bcQC_num,tb_bcQC_m386e,tb_bcQC_k338d,tb_bcQC_w792o,tb_bcQC_qcrq,tb_bcQC_v748n,tb_bcQC_p519h,tb_bcQC_e103w,tb_bcQC_l359d,tb_bcQC_o471g,tb_bcQC_m395e,tb_bcQC_p525h,tb_bcQC_l340d,tb_bcQC_k317c,tb_bcQC_b985t,tb_bcQC_j267b,tb_bcQC_i261b,tb_bcQC_x831p,tb_bcQC_h205z,tb_bcQC_n446f,tb_bcQC_t686m,tb_bcQC_n442f,tb_bcQC_g154y,tb_bcQC_a951t,tb_bcQC_y878r,tb_bcQC_h212z,tb_bcQC_l343d,tb_bcQC_i256a,tb_bcQC_o477g,tb_bcQC_n419f,tb_bcQC_i241a,tb_bcQC_w788o,tb_bcQC_z909r,tb_bcQC_h196z,tb_bcQC_a927s,tb_bcQC_m401e,tb_bcQC_a917s,tb_bcQC_q546i,tb_bcQC_e104w,tb_bcQC_f129x,tb_bcQC_x829p,tb_bcQC_r571j,tb_bcQC_v745n,tb_bcQC_s628k,tb_bcQC_z881r,tb_bcQC_d50v,tb_bcQC_m414f,tb_bcQC_m405e,tb_bcQC_x810p,tb_bcQC_k332c,tb_bcQC_bz,tb_bcQC_czrgh,tb_bcQC_qcsh"
        End Select


        Dim dt As DataTable
        sql = sql & sqlbds & "  from " & bm & " where " & bmzd & " between '" & tt1 & "' and '" & tt2 & "'"
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext)
        sql = sql & sqlbdssep '文本查询函数：挂接到查询文本
        dt = GF_CreateDataSource(G_cnnstr, sql)

        GS_DataGridViewbyDb(ListView3, dt, "0", True, True)
        ''''''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' 更新最后一次操作时间
    End Sub
    '新版查询
    Private Sub showsearch2(ByVal tt1 As String, ByVal tt2 As String)
        GS_CheckGuestDo() ' 检测最后一次操作是否超时,这里超时将直接退出程序
        Dim showwhat As String = ""
        If tt1 = tt2 Then
            showwhat = "QC记录查询：" & tt1 & namepp
        Else
            showwhat = "QC记录查询：" & tt1 & "至" & tt2 & namepp
        End If
        GroupBox3.Text = showwhat
        Dim bmzd As String = bm & "_qcrq" '得到取样时间字段
        Dim sql As String = "select "
        Dim sqlbds As String = "*"
        Select Case namepp
            Case "成品油"
                'sqlbds = "tb_h195z_ID,tb_h195z_qcsh,tb_h195z_num2,tb_h195z_num,tb_h195z_cplb,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_e95w,tb_h195z_o460g,tb_h195z_p495h,tb_h195z_y878r,tb_h195z_c998u,tb_h195z_g179y,tb_h195z_b989t,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_u704m,tb_h195z_q554i,tb_h195z_t673l,tb_h195z_bz,tb_h195z_qcrq,tb_h195z_y855q,tb_h195z_c6u,tb_h195z_c28u,tb_h195z_m403e,tb_h195z_b991u,tb_h195z_k309c,tb_h195z_a948s,tb_h195z_j268b,tb_h195z_l356d,tb_h195z_o485g,tb_h195z_h192z,tb_h195z_g158y,tb_h195z_d36v,tb_h195z_qarq,tb_h195z_qaspjg,tb_h195z_qajgsm,tb_h195z_yg,tb_h195z_bzxs,tb_h195z_cfdd,tb_h195z_rkts,tb_h195z_rkbz,tb_h195z_kczl,tb_h195z_sykczl,tb_h195z_czrgh,tb_h195z_o460gt,tb_h195z_y878rt,tb_h195z_g179yt,tb_h195z_qcczrgh,tb_h195z_qaczrgh,tb_h195z_y876r"
                sqlbds = "*"
            Case "精炼"
                'sqlbds = "tb_k306c_ID,tb_k306c_qcsh,tb_k306c_num,tb_k306c_num2,tb_k306c_jgrq,tb_k306c_f125x,tb_k306c_k337d,tb_k306c_m383e,tb_k306c_h217z,tb_k306c_z903r,tb_k306c_c5u,tb_k306c_u716m,tb_k306c_m398e,tb_k306c_v744n,tb_k306c_y860q,tb_k306c_z902r,tb_k306c_d47v,tb_k306c_c27u,tb_k306c_d39v,tb_k306c_s626k,tb_k306c_j299c,tb_k306c_t653l,tb_k306c_r574j,tb_k306c_t678l,tb_k306c_qarq,tb_k306c_qaspjg,tb_k306c_qajgsm,tb_k306c_glid,tb_k306c_czrgh,tb_k306c_h217zt,tb_k306c_u716mt,tb_k306c_c27ut,tb_k306c_s626kt,tb_k306c_t653lt,tb_k306c_qaczrgh,tb_k306c_qcrq,tb_k306c_r591j,tb_k306c_d68w,tb_k306c_u714m,tb_k306c_v749n,tb_k306c_s616k,tb_k306c_f133x,tb_k306c_w798p,tb_k306c_p508h,tb_k306c_qcczrgh,tb_k306c_q559i,tb_k306c_bz,tb_k306c_zjcr"
                sqlbds = "*"
            Case "成品粉"
                'sqlbds = "tb_x832p_ID,tb_x832p_qcsh,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_num,tb_x832p_num2,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_jgrq,tb_x832p_qarq,tb_x832p_qaspjg,tb_x832p_qajgsm,tb_x832p_czrgh,tb_x832p_bz,tb_x832p_qaczrgh,tb_x832p_qcrq,tb_x832p_cplb,tb_x832p_d65v,tb_x832p_a948s,tb_x832p_n422f,tb_x832p_s624k,tb_x832p_s644l,tb_x832p_c995u,tb_x832p_s613k,tb_x832p_m381e,tb_x832p_j284b,tb_x832p_c12u,tb_x832p_f119x,tb_x832p_s626k,tb_x832p_e106x,tb_x832p_n446f,tb_x832p_h199z,tb_x832p_o468g,tb_x832p_u691m,tb_x832p_c16u,tb_x832p_k308c,tb_x832p_r599j,tb_x832p_d39v,tb_x832p_qcczrgh,tb_x832p_sjqa,tb_x832p_kss,tb_x832p_nxam,tb_x832p_hms,tb_x832p_remark"
                sqlbds = "*"
            Case "毛油"
                'sqlbds = "tb_x825p_ID,tb_x825p_qcsh,tb_x825p_num,tb_x825p_num2,tb_x825p_jgrq,tb_x825p_d42v,tb_x825p_l349d,tb_x825p_k317c,tb_x825p_r583j,tb_x825p_d68w,tb_x825p_s640k,tb_x825p_w798p,tb_x825p_f144y,tb_x825p_qcrq,tb_x825p_q547i,tb_x825p_u699m,tb_x825p_r600j,tb_x825p_o479g,tb_x825p_b959t,tb_x825p_m387e,tb_x825p_t686m,tb_x825p_qarq,tb_x825p_qaspjg,tb_x825p_qajgsm,tb_x825p_yg,tb_x825p_bzxs,tb_x825p_cfdd,tb_x825p_rkts,tb_x825p_rkbz,tb_x825p_kczl,tb_x825p_sykczl,tb_x825p_czrgh,tb_x825p_qcczrgh,tb_x825p_qaczrgh,tb_x825p_r602j,tb_x825p_cplb,tb_x825p_sn,tb_x825p_bz"
            Case "一号塔内", "三号塔内", "四号塔内", "五号塔内"
                sqlbds = "tb_p525h_ID,tb_p525h_qcsh,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_l362d,tb_p525h_qcrq,tb_p525h_o479g,tb_p525h_g162y,tb_p525h_p499h,tb_p525h_u711m,tb_p525h_i249a,tb_p525h_r591j,tb_p525h_v755n,tb_p525h_s629k,tb_p525h_b966t,tb_p525h_i259b,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_d46v,tb_p525h_bz,tb_p525h_qcczrgh"
            Case "大罐"
                'sqlbds = "tb_q546i_ID,tb_q546i_qcsh,tb_q546i_num,tb_q546i_qcrq,tb_q546i_t651l,tb_q546i_a935s,tb_q546i_r604j,tb_q546i_h209z,tb_q546i_h193z,tb_q546i_q559i,tb_q546i_a941s,tb_q546i_j300c,tb_q546i_x817p,tb_q546i_n455g,tb_q546i_g184z,tb_q546i_n448f,tb_q546i_v744n,tb_q546i_f144x,tb_q546i_czrgh,tb_q546i_bz"
            Case "酶解"
                sqlbds = "tb_meijie_ID,tb_meijie_qcsh,tb_meijie_num,tb_meijie_qcrq,tb_meijie_jj,tb_meijie_zy,tb_meijie_sf,tb_meijie_bz,tb_meijie_qcczrgh"
            Case "冬化"
                sqlbds = "tb_donghua_ID,tb_donghua_qcsh,tb_donghua_num,tb_donghua_qcrq,tb_donghua_rzdha,tb_donghua_rzav,tb_donghua_rzpov,tb_donghua_rzr,tb_donghua_rzy,tb_donghua_rzsf,tb_donghua_yzdha,tb_donghua_qcczrgh"
            Case "脱臭"
                sqlbds = "tb_tuoxiu_ID,tb_tuoxiu_qcsh,tb_tuoxiu_num,tb_tuoxiu_qcrq,tb_tuoxiu_dha,tb_tuoxiu_AV,tb_tuoxiu_POV,tb_tuoxiu_R,tb_tuoxiu_Y,tb_tuoxiu_fszfs,tb_tuoxiu_qcczrgh"
            Case "原料"
                sqlbds = "*"
            Case "DHA原料"
                sqlbds = ""
            Case "包材"
                sqlbds = "tb_bcQC_id,tb_bcQC_num,tb_bcQC_m386e,tb_bcQC_k338d,tb_bcQC_w792o,tb_bcQC_qcrq,tb_bcQC_v748n,tb_bcQC_p519h,tb_bcQC_e103w,tb_bcQC_l359d,tb_bcQC_o471g,tb_bcQC_m395e,tb_bcQC_p525h,tb_bcQC_l340d,tb_bcQC_k317c,tb_bcQC_b985t,tb_bcQC_j267b,tb_bcQC_i261b,tb_bcQC_x831p,tb_bcQC_h205z,tb_bcQC_n446f,tb_bcQC_t686m,tb_bcQC_n442f,tb_bcQC_g154y,tb_bcQC_a951t,tb_bcQC_y878r,tb_bcQC_h212z,tb_bcQC_l343d,tb_bcQC_i256a,tb_bcQC_o477g,tb_bcQC_n419f,tb_bcQC_i241a,tb_bcQC_w788o,tb_bcQC_z909r,tb_bcQC_h196z,tb_bcQC_a927s,tb_bcQC_m401e,tb_bcQC_a917s,tb_bcQC_q546i,tb_bcQC_e104w,tb_bcQC_f129x,tb_bcQC_x829p,tb_bcQC_r571j,tb_bcQC_v745n,tb_bcQC_s628k,tb_bcQC_z881r,tb_bcQC_d50v,tb_bcQC_m414f,tb_bcQC_m405e,tb_bcQC_x810p,tb_bcQC_k332c,tb_bcQC_bz,tb_bcQC_czrgh,tb_bcQC_qcsh"
        End Select

        Dim dt As DataTable
        sql = sql & sqlbds & "  from " & bm & " where " & bmzd & " between '" & tt1 & "' and '" & tt2 & "'"
        'Debug.Print(sql)
        'Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext)

        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("查看明细")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq

        Dim strWhere As String = "where 1=1 and tb_QcJc_ftime between  '" & tt1 & "' and '" & tt2 & "' "
        Dim strWhere2 As String = ""
        If TextBox1.Text.Trim <> "" Then
            If ComboBox1.Text = "批号" Or ComboBox1.Text = "物料代码" Or ComboBox1.Text = "物料名称" Or ComboBox1.Text = "生产单号" Then
                Dim strTag As String = CType(ComboBox1.Tag, DataTable).Rows(ComboBox1.SelectedIndex)("tTag")
                strWhere &= " and " & strTag & "='" & TextBox1.Text & "'"
            Else
                strWhere &= " and tb_QcJc_ID in (select tb_QcVa_Qcbs from tb_QcVa where tb_QcVa_xmmc='" & ComboBox1.Text _
                    & "' and tb_QcVa_xmva='" & TextBox1.Text.Trim & "')"
            End If
        End If
        '要隐藏的列
        dim strHidcol As String=""
        '主记录对应的QC检测记录
        Select Case m_jcbNum
            Case -1
                strWhere &= " and tb_QcJc_jcb='tb_i259b'"
                sql = "select * from tb_QcJc as a left join tb_i259b as b on a.tb_QcJc_wlbs=b.tb_i259b_ID  " & strWhere
            Case -2
                strWhere &= " and tb_QcJc_jcb='tb_sc'"
                sql = "select tb_gxsz_mc,a.*,b.* from tb_QcJc as a left join tb_sc as b on a.tb_QcJc_wlbs=b.tb_sc_ID  " &
                    "left join tb_gxsz as c on b.tb_sc_gxbs=c.tb_gxsz_ID " & strWhere
                strHidcol = "tb_QcJc_ID,tb_sc_ID,tb_sc_gxbs"
            Case -3
                strWhere &= " and tb_QcJc_jcb='tb_wlph'"
                strWhere &= " and tb_wp_wpfl='"& namepp.Replace("BC","") &"'"
                sql = "select tb_wp_pm,a.*,tb_wlph_wpdm,tb_wlph_wlph,tb_wlph_cjfs,tb_wlph_sl,tb_wlph_ftime from tb_QcJc as a left join tb_wlph as b on a.tb_QcJc_wlbs=b.tb_wlph_ID  " &
                    "left join tb_wp as c on b.tb_wlph_wpbs=c.tb_wp_ID " & strWhere
                strHidcol = "tb_QcJc_ID"
            Case Else
                strWhere &= " and tb_QcJc_jcb='" & GetType(en_LcTableName).YanGetEnText(m_jcbNum) & "'"
                sql = "select * from tb_QcJc as a left join " & GetType(en_LcTableName).YanGetEnText(m_jcbNum) & " as b on " & _
                    "a.tb_QcJc_wlbs=b." & GetType(en_LcTableName).YanGetEnText(m_jcbNum) & "_ID   " & strWhere
        End Select

        dt = GF_CreateDataSource(G_cnnstr, sql)
        '添加结果检测列
        Select Case m_jcbNum
            Case -2
                cl_theCl.setQcshowView(dt, m_jcbNum, pWpbs:=m_wpDt.YanDtValue2("tb_gxsz_ID"))
            Case -3
                cl_theCl.setQcshowView(dt, -1)
            Case Else
                cl_theCl.setQcshowView(dt, m_jcbNum)
        End Select

        'GS_DataGridViewbyDb(ListView3, dt, True, True, menu1)
        If ListView3.DataSource IsNot Nothing Then
            CType(ListView3.DataSource, DataTable).Clear()
            ListView3.DataSource = Nothing
        End If

        dt.YanDataBind(ListView3, strHidcol, menu1)
        ListView3.Columns("tb_QcJc_wlbs").Visible = False
        ''''''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' 更新最后一次操作时间
    End Sub


    Private Sub showDhaQcList(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim frShow As New FrQcShowView

        GS_useviewbydb2(frShow.ListView1, cl_YanMd.getQcLsjl(Cl_StrMag.YanNull(ListView3.SelectedRows(0).Cells("tb_QcJc_wlbs").Value)))
        frShow.ShowDialog()
    End Sub

    Private Sub openaddqc(ui As Form, bm As String, num As String, xgid As String)
        With ui
            .Controls("Labeltb").Text = bm
            .Controls("Labelid").Text = xgid
            .Controls(bm & "_num").Text = num
            .ShowDialog()
        End With
        showsj()
    End Sub
    Private Sub ListView2_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
        If ListView2.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        If namepp = "三号塔内" Or namepp = "四号塔内" Or namepp = "五号塔内" Then
            Dim sql As String = ""
            Dim strIdList As String = ListView2.SelectedItems(0).SubItems(0).Text
            Dim nform As New Frtb_n441f
            nform.Labeltb.Text = "tb_p525h"
            nform.Labelid.Text = strIdList
            nform.tb_p525h_num.Text = ListView2.SelectedItems(0).SubItems(2).Text
            nform.tb_p525h_c17u.Text = "0/1×50g"
            nform.ShowDialog()
            showsj()
            Exit Sub
        End If

        Select Case namepp
            Case "原料", "包材"
                'Dim nform As New Frtb_t676l
                'nform.Labeltb.Text = bm
                'nform.tb_t676l_l345d.Text = Null2zero(GF_GetListText(ListView2, "tb_t676l_l345d", 0, 2))
                'nform.tb_t676l_num.Text = Null2String(GF_GetListText(ListView2, "tb_t676l_num", 0, 2))
                'nform.tb_t676l_x836q.Text = Null2String(GF_GetListText(ListView2, "tb_t676l_x836q", 0, 2))
                'nform.tb_t676l_p497h.Text = Null2String(GF_GetListText(ListView2, "tb_t676l_p497h", 0, 2))
                'nform.Labelid.Text = Null2String(GF_GetListText(ListView2, "tb_t676l_id", 0, 2))
                'nform.ShowDialog()
                'showsj()
                Dim nform As New FrWlJc
                'nform.m_objMyDataCl.setDataTb("tb_i259b", GF_GetListText(ListView2, "tb_i259b_id"))  '将该条物料数据传入操作界面
                nform.m_qclx = en_QcLX.物品
                nform.m_jcb = "tb_i259b"
                nform.m_wlbs = GF_GetListText(ListView2, "tb_i259b_id")
                nform.tb_i259b_c24u.Text = GF_GetListText(ListView2, "tb_i259b_c24u")
                nform.Label8.Text = GF_GetListText(ListView2, "tb_i259b_num")
                nform.ShowDialog()
            Case "BC工艺"
                Dim nform As New FrWlJc
                nform.m_qclx = en_QcLX.工艺
                nform.m_jcb = "tb_sc"
                nform.m_wlbs = ListView2.SelectedItems(0).SubItems(0).Text
                nform.m_wpbs = ListView2.SelectedItems(0).SubItems(1).Text
                nform.tb_i259b_c24u.Text = GF_GetListText(ListView2, "tb_gxsz_mc")
                nform.Label8.Text = GF_GetListText(ListView2, "tb_sc_dh")
                nform.ShowDialog()
            Case "BC过程品", "BC成品"
                Dim nform As New FrWlJc
                nform.m_qclx = en_QcLX.物品
                nform.m_jcb = "tb_wlph"
                nform.m_wlbs = ListView2.SelectedItems(0).SubItems(0).Text
                nform.m_wpbs = ListView2.SelectedItems(0).SubItems(1).Text
                nform.tb_i259b_c24u.Text = GF_GetListText(ListView2, "tb_wp_pm")
                nform.Label8.Text = GF_GetListText(ListView2, "tb_wlph_wlph")
                nform.ShowDialog()
            Case Else
                Dim nform As New FrWlJc
                nform.m_qclx = en_QcLX.工序
                nform.m_jcb = GetType(en_LcTableName).YanGetEnText(m_jcbNum)
                nform.m_wlbs = ListView2.SelectedItems(0).SubItems(0).Text
                nform.tb_i259b_c24u.Text = GetType(en_LcTableName).YanGetEnName(m_jcbNum)
                nform.Label8.Text = GF_GetListText(ListView2, GetType(en_LcTableName).YanGetEnText(m_jcbNum) & "_num")
                nform.ShowDialog()
        End Select
        showsj()

    End Sub

    Private Sub Buttsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttsearch.Click
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        showsearch(tt1, tt2)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"

        showsearch2(tt1, tt2)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GS_tohtml(ListView2, GroupBox2.Text)
    End Sub

    Private Sub ListView3_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView3.MouseDoubleClick
        If ListView3.SelectedRows.Count < 1 Then
            Exit Sub
        End If
        Dim choiseid As String = ListView3.SelectedRows(0).Cells(0).Value
        ''验证锁定
        'MsgBox("")
        If GF_MakeIsSD(bm, choiseid) = False Then
            Exit Sub
        End If

        Dim sql As String = Nothing
        Select Case namepp
            'Case "原料"
            '    If Null2String(ListView3.SelectedRows(0).Cells("tb_t676l_qcsh").Value) = "是" Then
            '        MessageBox.Show("已审核的数据不准修改！")
            '        Exit Sub
            '    End If
            '    Dim nform As New Frtb_t676l
            '    nform.Labeltb.Text = bm
            '    nform.tb_t676l_l345d.Text = ListView3.SelectedRows(0).Cells("tb_t676l_l345d").Value
            '    nform.tb_t676l_num.Text = ListView3.SelectedRows(0).Cells("tb_t676l_num").Value
            '    nform.tb_t676l_x836q.Text = ListView3.SelectedRows(0).Cells("tb_t676l_x836q").Value
            '    nform.tb_t676l_p497h.Text = ListView3.SelectedRows(0).Cells("tb_t676l_p497h").Value
            '    nform.Labelid.Text = ListView3.SelectedRows(0).Cells("tb_t676l_id").Value
            '    nform.ShowDialog()
            '    showsj()
            'Case "包材"
            '    If Null2String(ListView3.SelectedRows(0).Cells("tb_bcQC_qcsh").Value) = "是" Then
            '        MessageBox.Show("已审核的数据不准修改！")
            '        Exit Sub
            '    End If
            '    Dim nform As New Frtb_bcQC
            '    nform.Labeltb.Text = bm
            '    nform.tb_bcQC_w792o.Text = ListView3.SelectedRows(0).Cells("tb_bcQC_w792o").Value
            '    nform.tb_bcQC_num.Text = ListView3.SelectedRows(0).Cells("tb_bcQC_num").Value
            '    nform.tb_bcQC_m386e.Text = ListView3.SelectedRows(0).Cells("tb_bcQC_m386e").Value
            '    nform.tb_bcQC_k338d.Text = ListView3.SelectedRows(0).Cells("tb_bcQC_k338d").Value
            '    nform.Labelid.Text = ListView3.SelectedRows(0).Cells("tb_bcQC_id").Value
            '    nform.ShowDialog()
            '    showsj()
            Case "小罐"
                Dim ph1 As String = ListView3.SelectedRows(0).Cells(1).Value
                Dim ss As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_b970t_id from tb_b970t where tb_b970t_qcsh='否' and tb_b970t_num='" & ph1 & "'")
                If ss.Rows.Count = 0 Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_xgqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.tb_y864q_num.Text = ph1
                nform.ShowDialog()
            Case "中罐"
                Dim ph1 As String = ListView3.SelectedRows(0).Cells(1).Value
                Dim ss As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_b959t_id from tb_b959t where tb_b959t_qcsh='否' and tb_b959t_num='" & ph1 & "'")
                If ss.Rows.Count = 0 Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_zgqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.tb_f123x_num.Text = ph1
                nform.ShowDialog()
            Case "大罐"
                Dim ph1 As String = ListView3.SelectedRows(0).Cells(1).Value
                Dim ss As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_i234a_id from tb_i234a where tb_i234a_qcsh='否' and tb_i234a_num='" & ph1 & "'")
                If ss.Rows.Count = 0 Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_dgqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.tb_q546i_num.Text = ph1
                nform.ShowDialog()
            Case "酶解"
                Dim ph1 As String = ListView3.SelectedRows(0).Cells(1).Value
                Dim ss As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_meijie_id from tb_i234a where tb_meijie_qcsh='否' and tb_meijie_num='" & ph1 & "'")
                If ss.Rows.Count = 0 Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_meijieQC
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.tb_meijie_num.Text = ph1
                nform.ShowDialog()
            Case "毛油"
                If ListView3.SelectedRows(0).Cells(1).Value = "是" Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_fgqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.isxg = True '确认这是修改
                nform.ShowDialog()
            Case "精炼"
                If ListView3.SelectedRows(0).Cells(1).Value = "是" Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_jlqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.ShowDialog()
            Case "冬化"
                If ListView3.SelectedRows(0).Cells(1).Value = "是" Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_donghuaQC
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.ShowDialog()
            Case "脱臭"
                If ListView3.SelectedRows(0).Cells(1).Value = "是" Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_tuoxiuQC
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.ShowDialog()
            Case "成品油"
                If ListView3.SelectedRows(0).Cells(1).Value = "是" Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_cpqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.ShowDialog()
            Case "一号塔内", "三号塔内", "四号塔内", "五号塔内"
                If ListView3.SelectedRows(0).Cells(1).Value = "是" Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtb_n441f
                nform.Labeltb.Text = "tb_p525h"
                nform.Labelid.Text = choiseid
                nform.tb_p525h_num.Text = ListView3.SelectedRows(0).Cells(3).Value
                'nform.tb_p525h_c17u.Text = "0/1×50g"
                nform.ShowDialog()
            Case "成品粉"
                If ListView3.SelectedRows(0).Cells(2).Value = "是" Then
                    MsgBox("本条记录已经审核,无法修改或者删除!")
                    Exit Sub
                End If
                Dim nform As New Frtbfj_qc
                nform.Labeltb.Text = "tb_x832p"
                nform.Labelid.Text = choiseid
                nform.tb_x832p_num.Text = ListView3.SelectedRows(0).Cells(1).Value
                nform.ShowDialog()
        End Select
        Dim tt1, tt2 As String
        tt1 = GF_gettrqsj(DateTimePicker1.Text)
        tt2 = GF_gettrqsj(DateTimePicker2.Text)
        tt1 = tt1 & " 00:00:00" : tt2 = tt2 & " 23:59:59"
        showsearch(tt1, tt2)
    End Sub

    Private Sub wsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wsMenuItem.Click
        '''''''''''''''''''''
        If GF_storelog2("查询污水检测记录", "查询污水检测记录") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_wsjcjl")
    End Sub

    Private Sub hjMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hjMenuItem.Click
        '''''''''''''''''''''
        If GF_storelog2("查询环境微生物检测", "查询环境微生物检测") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_hjwswjc")
    End Sub
    '外检项目记录
    Private Sub wjMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wjMenuItem.Click
        '''''''''''''''''''''
        If GF_storelog2("查询外检项目记录", "查询外检项目记录") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_wjxmjl")
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView3, DateTimePicker1.Text & "至" & DateTimePicker2.Text, Me)
    End Sub
    Private Sub QCelseMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QCelseMenuItem.Click
        showform("tb_elsecheck")
    End Sub
    Private Sub showform(ByVal str As String)
        Dim nform As New Frshowadd
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & str & "'", 2) '得到表中文意思
        nform.TextBox1.Text = str
        nform.ShowDialog()
    End Sub

    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GS_Help("QC部")
    End Sub

    Private Sub ToolStripMenuItemGRPXDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemGRPXDA.Click
        Dim nform As New Frpxlb
        nform.ShowDialog()
    End Sub

    Private Sub ToolStripHJWSWBZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripHJWSWBZ.Click
        showform("tb_hjwswbz")
    End Sub

    Private Sub ToolStripHJWSWJCSJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripHJWSWJCSJ.Click
        showform("tb_hjwswjcsj")
    End Sub
    Private Sub 样品留样管理ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 样品留样管理ToolStripMenuItem.Click
        Dim aa As New Frtb_reserved
        aa.ShowDialog()
    End Sub

    Private Sub QC设置ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC设置ToolStripMenuItem.Click
        Dim aa As New FrQcSz
        aa.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        namepp = "原料"
        bm = "tb_t676l"
        m_jcbNum = -1
        showsj()
    End Sub
    Private Sub ToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        namepp = "包材"
        bm = "tb_bcQC"
        m_jcbNum = -1
        showsj()
    End Sub

    Private Sub 过程品ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 过程品ToolStripMenuItem.Click
        namepp = "BC" & en_wpfl.过程品.ToString()
        bm = "tb_wlph"
        m_jcbNum = -3
        showsj()
    End Sub

    Private Sub 成品ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 成品ToolStripMenuItem.Click
        namepp = "BC" & en_wpfl.成品.ToString()
        bm = "tb_wlph"
        m_jcbNum = -3
        showsj()
    End Sub
End Class