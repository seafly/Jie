Public Class Frqc_list
    Private bm As String
    Private namepp As String
    Private m_wpDt As DataTable = Nothing   '���BC����QCʱ��Ҫ������
    Private m_jcbNum As Integer = -1   '�����Ŀ����(���������Ϊԭ��Ʒ��ԭ�����ʱ��ḳö��ֵ)
    Public m_ListDt As DataTable = Nothing   '�б��DT
    '����Ĺر�
    Private Sub Face_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GS_Close3(sender, e) '����Ĺر�
    End Sub
    Private Sub Frqc_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = G_icon : Me.BackgroundImage = G_backimg
        If GF_storelog1("QC����") = False Then
            Me.Close() : Exit Sub
        End If ' �ж��Ƿ���Ȩ��
        ''''''''''''''''''''''''''''''
        GF_OpenFaceList2(tsMenu) '�л��˵���رղ˵��ļ���
        bcDropDown.Image = Me.ToolStripButton8.Image
        '���BC����
        Dim sql As String = "select * from tb_gxsz where tb_gxsz_isqc='��'  order by tb_gxsz_px"
        Dim dt As DataTable = sql.YanGetDb
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim q As ToolStripDropDownItem = bcDropDown.DropDownItems.Add(dt.YanDtValue2("tb_gxsz_mc", i))
            q.Tag = dt.Rows(i).YanDrToDb
            AddHandler q.Click, Sub(s As System.Object, ev As System.EventArgs)
                                    namepp = "BC����"
                                    bm = "tb_gxsz"
                                    m_wpDt = s.tag
                                    m_jcbNum = -2
                                    showsj()
                                End Sub

        Next
        '��ӷָ���
        'bcDropDown.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {New ToolStripSeparator})
        namepp = "ԭ��" : bm = "tb_t676l"
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

    'С��
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        namepp = "С��"
        bm = "tb_y864q"
        m_jcbNum = en_LcTableName.һ��������
        showsj()
    End Sub
    '�й�
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        namepp = "�й�"
        bm = "tb_f123x"
        m_jcbNum = en_LcTableName.����������
        showsj()
    End Sub
    '���
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        namepp = "���"
        bm = "tb_q546i"
        m_jcbNum = en_LcTableName.���͹�����
        showsj()
    End Sub
    'ø��QC
    Private Sub TSB_MJQC_Click(sender As System.Object, e As System.EventArgs) Handles TSB_MJQC.Click
        namepp = "ø��"
        bm = "tb_meijie"
        m_jcbNum = en_LcTableName.ø��
        showsj()
    End Sub
    'ë��
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        namepp = "ë��"
        bm = "tb_x825p"
        m_jcbNum = en_LcTableName.ë��
        showsj()
    End Sub

    '����
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        namepp = "����"
        bm = "tb_k306c"
        m_jcbNum = en_LcTableName.����
        showsj()
    End Sub
    '����QC
    Private Sub TSB_DHQC_Click(sender As System.Object, e As System.EventArgs) Handles TSB_DHQC.Click
        namepp = "����"
        bm = "tb_donghua"
        m_jcbNum = en_LcTableName.����
        showsj()
    End Sub
    '�ѳ�QC
    Private Sub TSB_TSQC_Click(sender As System.Object, e As System.EventArgs) Handles TSB_TSQC.Click
        namepp = "�ѳ�"
        bm = "tb_tuoxiu"
        m_jcbNum = en_LcTableName.�ѳ�
        showsj()
    End Sub
    '��Ʒ��
    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        namepp = "��Ʒ��"
        bm = "tb_h195z"
        m_jcbNum = en_LcTableName.��Ʒ��
        showsj()
    End Sub

    Private Sub excel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles excel2.Click
        namepp = "�ĺ�����"
        bm = "tb_p525h"
        m_jcbNum = en_LcTableName.�ۼ�С��
        showsj()
    End Sub

    Private Sub web1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles web13131.Click
        namepp = "��������"
        bm = "tb_p525h"
        m_jcbNum = en_LcTableName.�ۼ�С��
        showsj()
    End Sub
    Private Sub tb5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb5.Click
        namepp = "�������"
        bm = "tb_p525h"
        m_jcbNum = en_LcTableName.�ۼ�С��
        showsj()
    End Sub
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        bm = "tb_x832p"
        namepp = "��Ʒ��"
        m_jcbNum = en_LcTableName.��Ʒ��
        showsj()
    End Sub
    Private Function gzshowbds(bm As String) As String
        Dim bds As String = "select " & bm & "_ID," & bm & "_num," & bm & "_num2," & bm & "_jgrq," & bm & "_bz  from " & bm & "  where " & bm & "_qcsh = '��'"
        Return bds
    End Function
    '��������LISTVIEW
    Private Sub showsj()
        GS_CheckGuestDo() ' ������һ�β����Ƿ�ʱ,���ﳬʱ��ֱ���˳�����
        GS_FaceSearch(ComboBoxserchtext, bm, 1) '�ı���ѯ��������������ı��ֶε���ʾ,�ɰ��ѯ����׼��
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        ListView2.CheckBoxes = (bm = "tb_p525h")

        Dim tDt As New DataTable
        tDt.Columns.Add("tText")
        tDt.Columns.Add("tTag")
        ComboBox1.Items.Clear()
        Select Case m_jcbNum
            Case -1 'ԭ��
                'tb_i259b_i231a,tb_i259b_c24u,tb_i259b_num
                tDt.Rows.Add("����", "tb_i259b_num")
                tDt.Rows.Add("���ϴ���", "tb_i259b_i231a")
                tDt.Rows.Add("��������", "tb_i259b_c24u")

                Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.��Ʒ)
                For Each dr As DataRow In tBqcxm.Rows
                    tDt.Rows.Add(dr("tb_QcXm_xmmc"), "")
                Next
                '�������Ŀ�������ȫ����ӽ���
                GS_wlbktlr2(ComboBox1, tDt, 0, "") '��ʾ�ֶ�������
                ComboBox1.Tag = tDt
            Case -2
                tDt.Rows.Add("��������", "tb_sc_dh")
                Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.���� & _
                                                                         " and tb_QcXm_wpbs='" & m_wpDt.YanDtValue2("tb_gxsz_ID") & "'")
                For Each dr As DataRow In tBqcxm.Rows
                    tDt.Rows.Add(dr("tb_QcXm_xmmc"), "")
                Next
                '�������Ŀ�������ȫ����ӽ���
                GS_wlbktlr2(ComboBox1, tDt, 0, "") '��ʾ�ֶ�������
                ComboBox1.Tag = tDt
            Case -3
                tDt.Rows.Add("����", "tb_wlph_wlph")
                Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.��Ʒ)
                For Each dr As DataRow In tBqcxm.Rows
                    tDt.Rows.Add(dr("tb_QcXm_xmmc"), "")
                Next
                '�������Ŀ�������ȫ����ӽ���
                GS_wlbktlr2(ComboBox1, tDt, 0, "") '��ʾ�ֶ�������
                ComboBox1.Tag = tDt
            Case Else
                tDt.Rows.Add("����", GetType(en_LcTableName).YanGetEnText(m_jcbNum) & "_num")
                Dim tBqcxm As DataTable = Cl_DataMag.GF_CreateDataSource("select distinct tb_QcXm_xmmc from tb_QcXm where tb_QcXm_qclx=" & en_QcLX.���� & _
                                                                         " and tb_QcXm_wldm='" & GetType(en_LcTableName).YanGetEnName(m_jcbNum) & "'")
                For Each dr As DataRow In tBqcxm.Rows
                    tDt.Rows.Add(dr("tb_QcXm_xmmc"), "")
                Next
                '�������Ŀ�������ȫ����ӽ���
                GS_wlbktlr2(ComboBox1, tDt, 0, "") '��ʾ�ֶ�������
                ComboBox1.Tag = tDt
        End Select

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim sql As String = ""
        Dim boBox As Boolean = False

        Select Case namepp
            Case "ԭ��"
                'sql = "select tb_t676l_id, tb_t676l_num,tb_t676l_x836q,tb_t676l_p497h,tb_t676l_l345d,tb_t676l_qcsh from tb_t676l where tb_t676l_qcsh='��'  and  tb_t676l_num not in (select tb_i259b_num from tb_i259b where tb_i259b_r596j='�ͼ�ԭ��' or tb_i259b_r596j='����ԭ��') "
                sql = "select * from tb_i259b where tb_i259b_qcsh='��' and tb_i259b_qaspjg='����' and tb_i259b_r596j like '%ԭ��%'"
            Case "����"
                'sql = "select tb_bcQC_id, tb_bcQC_num,tb_bcQC_m386e,tb_bcQC_k338d,tb_bcQC_w792o,tb_bcQC_qcsh  from tb_bcQC where  tb_bcQC_qcsh ='��' "
                sql = "select * from tb_i259b where tb_i259b_qcsh='��' and tb_i259b_qaspjg='����' and tb_i259b_r596j like '%����%'"
            Case "С��"
                sql = "select tb_b970t_ID,tb_b970t_num,tb_b970t_jgrq,tb_b970t_bz from tb_b970t  where tb_b970t_qcsh='��' "
            Case "�й�"
                sql = "select tb_b959t_ID,tb_b959t_num,tb_b959t_num2,tb_b959t_jgrq,tb_b959t_bz from tb_b959t  where tb_b959t_qcsh='��'"
            Case "���"
                sql = "select tb_i234a_ID,tb_i234a_num,tb_i234a_num2,tb_i234a_jgrq,tb_i234a_bz  from tb_i234a  where tb_i234a_qcsh= '��'"
            Case "ø��", "����", "�ѳ�"
                sql = gzshowbds(bm)
            Case "ë��"
                sql = "select tb_x825p_ID,tb_x825p_num,tb_x825p_num2,tb_x825p_jgrq,tb_x825p_r583j,tb_x825p_s640k,tb_x825p_bz,tb_x825p_qcsh from tb_x825p  where tb_x825p_qcsh ='��' order by tb_x825p_jgrq desc   "
            Case "����"
                sql = "select tb_k306c_ID,tb_k306c_num,tb_k306c_num2,tb_k306c_jgrq,tb_k306c_bz from vw_k306c where tb_k306c_qcsh='��'"
            Case "��Ʒ��"
                sql = "select tb_h195z_ID,tb_h195z_num,tb_h195z_cplb,tb_h195z_mingc,tb_h195z_jiagdm,tb_h195z_num2,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_bz,tb_h195z_qcsh from vw_h195z where tb_h195z_qcsh='��' order by tb_h195z_jgrq desc "
            Case "��������"
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_bz  from tb_p525h where tb_p525h_th='3����' and tb_p525h_qcsh='��'"
                boBox = True
            Case "�ĺ�����"
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_bz  from tb_p525h where tb_p525h_th='4����' and tb_p525h_qcsh='��'"
                boBox = True
            Case "�������"
                sql = "select tb_p525h_ID,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_b967t,tb_p525h_th,tb_p525h_bz  from tb_p525h where tb_p525h_th='5����' and tb_p525h_qcsh='��'"
                boBox = True
            Case "��Ʒ��"
                sql = "select tb_x832p_ID,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_cplb,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_num,tb_x832p_scdm,tb_x832p_jgrq,tb_x832p_sjqa,tb_x832p_kss,tb_x832p_nxam,tb_x832p_bz,tb_x832p_qcsh,tb_x832p_hyn,tb_x832p_midu,tb_x832p_vcna from vw_x832p  where tb_x832p_qcsh='��' order by tb_x832p_jgrq "
            Case "BC����"
                sql = "select a.tb_sc_ID,b.tb_gxsz_ID,a.tb_sc_dh,a.tb_sc_ftime,b.tb_gxsz_mc from tb_sc as a left join tb_gxsz as b on a.tb_sc_gxbs=b.tb_gxsz_ID " &
                    "where tb_sc_gxbs='" & m_wpDt.YanDtValue2("tb_gxsz_ID") & "' and tb_sc_ID not in " &
                    "(select tb_QcJc_wlbs from tb_QcJc where tb_QcJc_jcb='tb_sc' and tb_QcJc_sfsh='��')"
            Case "BC����Ʒ", "BC��Ʒ"
                sql = "select tb_wlph_ID,b.tb_wp_ID,b.tb_wp_pm,tb_wlph_wlph,tb_wlph_cjfs,tb_wlph_sl,tb_wlph_ftime " &
                    "from tb_wlph as a left join tb_wp as b on a.tb_wlph_wpbs=b.tb_wp_ID " &
                    "where tb_wp_isqc='��' and tb_wp_wpfl='" & namepp.Replace("BC", "") & "' and tb_wlph_ID not in (select tb_QcJc_wlbs from tb_QcJc where tb_QcJc_jcb='tb_wlph' and tb_QcJc_sfsh='��') " &
                    "and case when tb_wlph_cjtb<>'tb_sc' then 0 else " &
                    "case when exists(select * from tb_wlph where tb_wlph_ID=a.tb_wlph_ID and tb_wlph_cjbs in " &
                    "(select tb_sc_ID from tb_sc where tb_sc_isEnd='" & en_sczt.���.ToString & "')) " &
                    "then 0	else 1	end end=0"
        End Select
        GroupBox2.Text = "QC����⣺" & namepp
        Dim dt As DataTable = GF_CreateDataSource(G_cnnstr, sql)
        m_ListDt = dt
        Select Case namepp
            Case "BC����"
                dt.Columns.Add("��������")
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim tDtph As DataTable = _D.GF_CreateDataSource("select * from tb_scxq where tb_scxq_lx='����' and tb_scxq_scbs=" & dt.YanDtValue2("tb_sc_ID", i))
                    dim tSph As String=""
                    For j As Integer = 0 To tDtph.Rows.Count - 1
                        tSph &= tDtph.YanDtValue2("tb_scxq_value").Split("|")(1) & ","
                    Next
                    dt.Rows(i)("��������") = tSph.YanRemovedh
                Next
        End Select

        Dim menu1 As ContextMenuStrip = Nothing

        If boBox Then
            menu1 = New ContextMenuStrip
            menu1.Items.Add("�鿴��ϸ")
            AddHandler menu1.ItemClicked, AddressOf GS_mendj
            menu1.Items.Add("�������")
            AddHandler menu1.ItemClicked, AddressOf update_all
        End If
        GS_useviewbydb2(ListView2, dt, -1, 100, boBox, menu1)
        Select Case namepp
            Case "BC����"
                ListView2.Columns(1).Width = 0
            Case "BC����Ʒ"
                ListView2.Columns(1).Width = 0
        End Select
        'If namepp = "ԭ��" Or namepp = "����" Then
        '    GS_setbackcolor(ListView2, Color.Red, 9)
        'End If
        ''''''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' �������һ�β���ʱ��
    End Sub

    Private Sub update_all(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        If e.ClickedItem.Text <> "�������" Then
            Return
        End If

        If MsgBox("ȷ��Ҫ���������", MsgBoxStyle.OkCancel) <> vbOK Then
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
        nform.tb_p525h_c17u.Text = "0/1��50g"
        nform.ShowDialog()
        showsj()
        'sql = "update tb_p525h set tb_p525h_qcsh='��' where tb_p525h_ID in (" & strIdList & ")"
        'DeepCode.DeepDoDataTable.GS_upztxx(G_cnnstr, sql)
    End Sub

    '�ɰ��ѯ
    Private Sub showsearch(ByVal tt1 As String, ByVal tt2 As String)
        GS_CheckGuestDo() ' ������һ�β����Ƿ�ʱ,���ﳬʱ��ֱ���˳�����
        Dim showwhat As String = ""
        If tt1 = tt2 Then
            showwhat = "QC��¼��ѯ��" & tt1 & namepp
        Else
            showwhat = "QC��¼��ѯ��" & tt1 & "��" & tt2 & namepp
        End If
        GroupBox3.Text = showwhat
        Dim bmzd As String = bm & "_qcrq" '�õ�ȡ��ʱ���ֶ�
        Dim sql As String = "select "
        Dim sqlbds As String = "*"
        Select Case namepp
            Case "��Ʒ��"
                'sqlbds = "tb_h195z_ID,tb_h195z_qcsh,tb_h195z_num2,tb_h195z_num,tb_h195z_cplb,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_e95w,tb_h195z_o460g,tb_h195z_p495h,tb_h195z_y878r,tb_h195z_c998u,tb_h195z_g179y,tb_h195z_b989t,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_u704m,tb_h195z_q554i,tb_h195z_t673l,tb_h195z_bz,tb_h195z_qcrq,tb_h195z_y855q,tb_h195z_c6u,tb_h195z_c28u,tb_h195z_m403e,tb_h195z_b991u,tb_h195z_k309c,tb_h195z_a948s,tb_h195z_j268b,tb_h195z_l356d,tb_h195z_o485g,tb_h195z_h192z,tb_h195z_g158y,tb_h195z_d36v,tb_h195z_qarq,tb_h195z_qaspjg,tb_h195z_qajgsm,tb_h195z_yg,tb_h195z_bzxs,tb_h195z_cfdd,tb_h195z_rkts,tb_h195z_rkbz,tb_h195z_kczl,tb_h195z_sykczl,tb_h195z_czrgh,tb_h195z_o460gt,tb_h195z_y878rt,tb_h195z_g179yt,tb_h195z_qcczrgh,tb_h195z_qaczrgh,tb_h195z_y876r"
                sqlbds = "*"
            Case "����"
                'sqlbds = "tb_k306c_ID,tb_k306c_qcsh,tb_k306c_num,tb_k306c_num2,tb_k306c_jgrq,tb_k306c_f125x,tb_k306c_k337d,tb_k306c_m383e,tb_k306c_h217z,tb_k306c_z903r,tb_k306c_c5u,tb_k306c_u716m,tb_k306c_m398e,tb_k306c_v744n,tb_k306c_y860q,tb_k306c_z902r,tb_k306c_d47v,tb_k306c_c27u,tb_k306c_d39v,tb_k306c_s626k,tb_k306c_j299c,tb_k306c_t653l,tb_k306c_r574j,tb_k306c_t678l,tb_k306c_qarq,tb_k306c_qaspjg,tb_k306c_qajgsm,tb_k306c_glid,tb_k306c_czrgh,tb_k306c_h217zt,tb_k306c_u716mt,tb_k306c_c27ut,tb_k306c_s626kt,tb_k306c_t653lt,tb_k306c_qaczrgh,tb_k306c_qcrq,tb_k306c_r591j,tb_k306c_d68w,tb_k306c_u714m,tb_k306c_v749n,tb_k306c_s616k,tb_k306c_f133x,tb_k306c_w798p,tb_k306c_p508h,tb_k306c_qcczrgh,tb_k306c_q559i,tb_k306c_bz,tb_k306c_zjcr"
                sqlbds = "*"
            Case "��Ʒ��"
                'sqlbds = "tb_x832p_ID,tb_x832p_qcsh,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_num,tb_x832p_num2,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_jgrq,tb_x832p_qarq,tb_x832p_qaspjg,tb_x832p_qajgsm,tb_x832p_czrgh,tb_x832p_bz,tb_x832p_qaczrgh,tb_x832p_qcrq,tb_x832p_cplb,tb_x832p_d65v,tb_x832p_a948s,tb_x832p_n422f,tb_x832p_s624k,tb_x832p_s644l,tb_x832p_c995u,tb_x832p_s613k,tb_x832p_m381e,tb_x832p_j284b,tb_x832p_c12u,tb_x832p_f119x,tb_x832p_s626k,tb_x832p_e106x,tb_x832p_n446f,tb_x832p_h199z,tb_x832p_o468g,tb_x832p_u691m,tb_x832p_c16u,tb_x832p_k308c,tb_x832p_r599j,tb_x832p_d39v,tb_x832p_qcczrgh,tb_x832p_sjqa,tb_x832p_kss,tb_x832p_nxam,tb_x832p_hms,tb_x832p_remark"
                sqlbds = "*"
            Case "ë��"
                'sqlbds = "tb_x825p_ID,tb_x825p_qcsh,tb_x825p_num,tb_x825p_num2,tb_x825p_jgrq,tb_x825p_d42v,tb_x825p_l349d,tb_x825p_k317c,tb_x825p_r583j,tb_x825p_d68w,tb_x825p_s640k,tb_x825p_w798p,tb_x825p_f144y,tb_x825p_qcrq,tb_x825p_q547i,tb_x825p_u699m,tb_x825p_r600j,tb_x825p_o479g,tb_x825p_b959t,tb_x825p_m387e,tb_x825p_t686m,tb_x825p_qarq,tb_x825p_qaspjg,tb_x825p_qajgsm,tb_x825p_yg,tb_x825p_bzxs,tb_x825p_cfdd,tb_x825p_rkts,tb_x825p_rkbz,tb_x825p_kczl,tb_x825p_sykczl,tb_x825p_czrgh,tb_x825p_qcczrgh,tb_x825p_qaczrgh,tb_x825p_r602j,tb_x825p_cplb,tb_x825p_sn,tb_x825p_bz"
            Case "һ������", "��������", "�ĺ�����", "�������"
                sqlbds = "tb_p525h_ID,tb_p525h_qcsh,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_l362d,tb_p525h_qcrq,tb_p525h_o479g,tb_p525h_g162y,tb_p525h_p499h,tb_p525h_u711m,tb_p525h_i249a,tb_p525h_r591j,tb_p525h_v755n,tb_p525h_s629k,tb_p525h_b966t,tb_p525h_i259b,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_d46v,tb_p525h_bz,tb_p525h_qcczrgh"
            Case "���"
                'sqlbds = "tb_q546i_ID,tb_q546i_qcsh,tb_q546i_num,tb_q546i_qcrq,tb_q546i_t651l,tb_q546i_a935s,tb_q546i_r604j,tb_q546i_h209z,tb_q546i_h193z,tb_q546i_q559i,tb_q546i_a941s,tb_q546i_j300c,tb_q546i_x817p,tb_q546i_n455g,tb_q546i_g184z,tb_q546i_n448f,tb_q546i_v744n,tb_q546i_f144x,tb_q546i_czrgh,tb_q546i_bz"
            Case "ø��"
                sqlbds = "tb_meijie_ID,tb_meijie_qcsh,tb_meijie_num,tb_meijie_qcrq,tb_meijie_jj,tb_meijie_zy,tb_meijie_sf,tb_meijie_bz,tb_meijie_qcczrgh"
            Case "����"
                sqlbds = "tb_donghua_ID,tb_donghua_qcsh,tb_donghua_num,tb_donghua_qcrq,tb_donghua_rzdha,tb_donghua_rzav,tb_donghua_rzpov,tb_donghua_rzr,tb_donghua_rzy,tb_donghua_rzsf,tb_donghua_yzdha,tb_donghua_qcczrgh"
            Case "�ѳ�"
                sqlbds = "tb_tuoxiu_ID,tb_tuoxiu_qcsh,tb_tuoxiu_num,tb_tuoxiu_qcrq,tb_tuoxiu_dha,tb_tuoxiu_AV,tb_tuoxiu_POV,tb_tuoxiu_R,tb_tuoxiu_Y,tb_tuoxiu_fszfs,tb_tuoxiu_qcczrgh"
            Case "ԭ��"
                sqlbds = "tb_t676l_id,tb_t676l_num,tb_t676l_x836q,tb_t676l_p497h,tb_t676l_l345d,tb_t676l_qcrq,tb_t676l_f129x,tb_t676l_h204z,tb_t676l_w768o,tb_t676l_t683m,tb_t676l_t681l,tb_t676l_i257a,tb_t676l_r596j,tb_t676l_t686m,tb_t676l_s628k,tb_t676l_s623k,tb_t676l_s617k,tb_t676l_s634k,tb_t676l_j276b,tb_t676l_h206z,tb_t676l_g152y,tb_t676l_i250a,tb_t676l_u688m,tb_t676l_o458g,tb_t676l_h223a,tb_t676l_q556i,tb_t676l_j264b,tb_t676l_c25u,tb_t676l_e88w,tb_t676l_g161y,tb_t676l_y868q,tb_t676l_k338d,tb_t676l_r604j,tb_t676l_a931s,tb_t676l_d70w,tb_t676l_n451f,tb_t676l_f123x,tb_t676l_y869q,tb_t676l_x816p,tb_t676l_xbtb,tb_t676l_glid,tb_t676l_xbrq,tb_t676l_czrgh,tb_t676l_qyl,tb_t676l_d222a,tb_t676l_z882r,tb_t676l_o479g,tb_t676l_sjqa,tb_t676l_longlin,tb_t676l_ajd,tb_t676l_yjl,tb_t676l_c5,tb_t676l_qcsh"
                sqlbds = " * "
            Case "DHAԭ��"
                sqlbds = ""
            Case "����"
                sqlbds = "tb_bcQC_id,tb_bcQC_num,tb_bcQC_m386e,tb_bcQC_k338d,tb_bcQC_w792o,tb_bcQC_qcrq,tb_bcQC_v748n,tb_bcQC_p519h,tb_bcQC_e103w,tb_bcQC_l359d,tb_bcQC_o471g,tb_bcQC_m395e,tb_bcQC_p525h,tb_bcQC_l340d,tb_bcQC_k317c,tb_bcQC_b985t,tb_bcQC_j267b,tb_bcQC_i261b,tb_bcQC_x831p,tb_bcQC_h205z,tb_bcQC_n446f,tb_bcQC_t686m,tb_bcQC_n442f,tb_bcQC_g154y,tb_bcQC_a951t,tb_bcQC_y878r,tb_bcQC_h212z,tb_bcQC_l343d,tb_bcQC_i256a,tb_bcQC_o477g,tb_bcQC_n419f,tb_bcQC_i241a,tb_bcQC_w788o,tb_bcQC_z909r,tb_bcQC_h196z,tb_bcQC_a927s,tb_bcQC_m401e,tb_bcQC_a917s,tb_bcQC_q546i,tb_bcQC_e104w,tb_bcQC_f129x,tb_bcQC_x829p,tb_bcQC_r571j,tb_bcQC_v745n,tb_bcQC_s628k,tb_bcQC_z881r,tb_bcQC_d50v,tb_bcQC_m414f,tb_bcQC_m405e,tb_bcQC_x810p,tb_bcQC_k332c,tb_bcQC_bz,tb_bcQC_czrgh,tb_bcQC_qcsh"
        End Select


        Dim dt As DataTable
        sql = sql & sqlbds & "  from " & bm & " where " & bmzd & " between '" & tt1 & "' and '" & tt2 & "'"
        Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext)
        sql = sql & sqlbdssep '�ı���ѯ�������ҽӵ���ѯ�ı�
        dt = GF_CreateDataSource(G_cnnstr, sql)

        GS_DataGridViewbyDb(ListView3, dt, "0", True, True)
        ''''''''''''''''''''''''''''''''''''''''
        GS_StoreLastDo() ' �������һ�β���ʱ��
    End Sub
    '�°��ѯ
    Private Sub showsearch2(ByVal tt1 As String, ByVal tt2 As String)
        GS_CheckGuestDo() ' ������һ�β����Ƿ�ʱ,���ﳬʱ��ֱ���˳�����
        Dim showwhat As String = ""
        If tt1 = tt2 Then
            showwhat = "QC��¼��ѯ��" & tt1 & namepp
        Else
            showwhat = "QC��¼��ѯ��" & tt1 & "��" & tt2 & namepp
        End If
        GroupBox3.Text = showwhat
        Dim bmzd As String = bm & "_qcrq" '�õ�ȡ��ʱ���ֶ�
        Dim sql As String = "select "
        Dim sqlbds As String = "*"
        Select Case namepp
            Case "��Ʒ��"
                'sqlbds = "tb_h195z_ID,tb_h195z_qcsh,tb_h195z_num2,tb_h195z_num,tb_h195z_cplb,tb_h195z_jgrq,tb_h195z_m408e,tb_h195z_e95w,tb_h195z_o460g,tb_h195z_p495h,tb_h195z_y878r,tb_h195z_c998u,tb_h195z_g179y,tb_h195z_b989t,tb_h195z_n426f,tb_h195z_s621k,tb_h195z_u704m,tb_h195z_q554i,tb_h195z_t673l,tb_h195z_bz,tb_h195z_qcrq,tb_h195z_y855q,tb_h195z_c6u,tb_h195z_c28u,tb_h195z_m403e,tb_h195z_b991u,tb_h195z_k309c,tb_h195z_a948s,tb_h195z_j268b,tb_h195z_l356d,tb_h195z_o485g,tb_h195z_h192z,tb_h195z_g158y,tb_h195z_d36v,tb_h195z_qarq,tb_h195z_qaspjg,tb_h195z_qajgsm,tb_h195z_yg,tb_h195z_bzxs,tb_h195z_cfdd,tb_h195z_rkts,tb_h195z_rkbz,tb_h195z_kczl,tb_h195z_sykczl,tb_h195z_czrgh,tb_h195z_o460gt,tb_h195z_y878rt,tb_h195z_g179yt,tb_h195z_qcczrgh,tb_h195z_qaczrgh,tb_h195z_y876r"
                sqlbds = "*"
            Case "����"
                'sqlbds = "tb_k306c_ID,tb_k306c_qcsh,tb_k306c_num,tb_k306c_num2,tb_k306c_jgrq,tb_k306c_f125x,tb_k306c_k337d,tb_k306c_m383e,tb_k306c_h217z,tb_k306c_z903r,tb_k306c_c5u,tb_k306c_u716m,tb_k306c_m398e,tb_k306c_v744n,tb_k306c_y860q,tb_k306c_z902r,tb_k306c_d47v,tb_k306c_c27u,tb_k306c_d39v,tb_k306c_s626k,tb_k306c_j299c,tb_k306c_t653l,tb_k306c_r574j,tb_k306c_t678l,tb_k306c_qarq,tb_k306c_qaspjg,tb_k306c_qajgsm,tb_k306c_glid,tb_k306c_czrgh,tb_k306c_h217zt,tb_k306c_u716mt,tb_k306c_c27ut,tb_k306c_s626kt,tb_k306c_t653lt,tb_k306c_qaczrgh,tb_k306c_qcrq,tb_k306c_r591j,tb_k306c_d68w,tb_k306c_u714m,tb_k306c_v749n,tb_k306c_s616k,tb_k306c_f133x,tb_k306c_w798p,tb_k306c_p508h,tb_k306c_qcczrgh,tb_k306c_q559i,tb_k306c_bz,tb_k306c_zjcr"
                sqlbds = "*"
            Case "��Ʒ��"
                'sqlbds = "tb_x832p_ID,tb_x832p_qcsh,tb_x832p_mingc,tb_x832p_jiagdm,tb_x832p_num,tb_x832p_num2,tb_x832p_y864q,tb_x832p_l349d,tb_x832p_i232a,tb_x832p_jgrq,tb_x832p_qarq,tb_x832p_qaspjg,tb_x832p_qajgsm,tb_x832p_czrgh,tb_x832p_bz,tb_x832p_qaczrgh,tb_x832p_qcrq,tb_x832p_cplb,tb_x832p_d65v,tb_x832p_a948s,tb_x832p_n422f,tb_x832p_s624k,tb_x832p_s644l,tb_x832p_c995u,tb_x832p_s613k,tb_x832p_m381e,tb_x832p_j284b,tb_x832p_c12u,tb_x832p_f119x,tb_x832p_s626k,tb_x832p_e106x,tb_x832p_n446f,tb_x832p_h199z,tb_x832p_o468g,tb_x832p_u691m,tb_x832p_c16u,tb_x832p_k308c,tb_x832p_r599j,tb_x832p_d39v,tb_x832p_qcczrgh,tb_x832p_sjqa,tb_x832p_kss,tb_x832p_nxam,tb_x832p_hms,tb_x832p_remark"
                sqlbds = "*"
            Case "ë��"
                'sqlbds = "tb_x825p_ID,tb_x825p_qcsh,tb_x825p_num,tb_x825p_num2,tb_x825p_jgrq,tb_x825p_d42v,tb_x825p_l349d,tb_x825p_k317c,tb_x825p_r583j,tb_x825p_d68w,tb_x825p_s640k,tb_x825p_w798p,tb_x825p_f144y,tb_x825p_qcrq,tb_x825p_q547i,tb_x825p_u699m,tb_x825p_r600j,tb_x825p_o479g,tb_x825p_b959t,tb_x825p_m387e,tb_x825p_t686m,tb_x825p_qarq,tb_x825p_qaspjg,tb_x825p_qajgsm,tb_x825p_yg,tb_x825p_bzxs,tb_x825p_cfdd,tb_x825p_rkts,tb_x825p_rkbz,tb_x825p_kczl,tb_x825p_sykczl,tb_x825p_czrgh,tb_x825p_qcczrgh,tb_x825p_qaczrgh,tb_x825p_r602j,tb_x825p_cplb,tb_x825p_sn,tb_x825p_bz"
            Case "һ������", "��������", "�ĺ�����", "�������"
                sqlbds = "tb_p525h_ID,tb_p525h_qcsh,tb_p525h_num2,tb_p525h_num,tb_p525h_jgrq,tb_p525h_l362d,tb_p525h_qcrq,tb_p525h_o479g,tb_p525h_g162y,tb_p525h_p499h,tb_p525h_u711m,tb_p525h_i249a,tb_p525h_r591j,tb_p525h_v755n,tb_p525h_s629k,tb_p525h_b966t,tb_p525h_i259b,tb_p525h_c17u,tb_p525h_u721n,tb_p525h_d46v,tb_p525h_bz,tb_p525h_qcczrgh"
            Case "���"
                'sqlbds = "tb_q546i_ID,tb_q546i_qcsh,tb_q546i_num,tb_q546i_qcrq,tb_q546i_t651l,tb_q546i_a935s,tb_q546i_r604j,tb_q546i_h209z,tb_q546i_h193z,tb_q546i_q559i,tb_q546i_a941s,tb_q546i_j300c,tb_q546i_x817p,tb_q546i_n455g,tb_q546i_g184z,tb_q546i_n448f,tb_q546i_v744n,tb_q546i_f144x,tb_q546i_czrgh,tb_q546i_bz"
            Case "ø��"
                sqlbds = "tb_meijie_ID,tb_meijie_qcsh,tb_meijie_num,tb_meijie_qcrq,tb_meijie_jj,tb_meijie_zy,tb_meijie_sf,tb_meijie_bz,tb_meijie_qcczrgh"
            Case "����"
                sqlbds = "tb_donghua_ID,tb_donghua_qcsh,tb_donghua_num,tb_donghua_qcrq,tb_donghua_rzdha,tb_donghua_rzav,tb_donghua_rzpov,tb_donghua_rzr,tb_donghua_rzy,tb_donghua_rzsf,tb_donghua_yzdha,tb_donghua_qcczrgh"
            Case "�ѳ�"
                sqlbds = "tb_tuoxiu_ID,tb_tuoxiu_qcsh,tb_tuoxiu_num,tb_tuoxiu_qcrq,tb_tuoxiu_dha,tb_tuoxiu_AV,tb_tuoxiu_POV,tb_tuoxiu_R,tb_tuoxiu_Y,tb_tuoxiu_fszfs,tb_tuoxiu_qcczrgh"
            Case "ԭ��"
                sqlbds = "*"
            Case "DHAԭ��"
                sqlbds = ""
            Case "����"
                sqlbds = "tb_bcQC_id,tb_bcQC_num,tb_bcQC_m386e,tb_bcQC_k338d,tb_bcQC_w792o,tb_bcQC_qcrq,tb_bcQC_v748n,tb_bcQC_p519h,tb_bcQC_e103w,tb_bcQC_l359d,tb_bcQC_o471g,tb_bcQC_m395e,tb_bcQC_p525h,tb_bcQC_l340d,tb_bcQC_k317c,tb_bcQC_b985t,tb_bcQC_j267b,tb_bcQC_i261b,tb_bcQC_x831p,tb_bcQC_h205z,tb_bcQC_n446f,tb_bcQC_t686m,tb_bcQC_n442f,tb_bcQC_g154y,tb_bcQC_a951t,tb_bcQC_y878r,tb_bcQC_h212z,tb_bcQC_l343d,tb_bcQC_i256a,tb_bcQC_o477g,tb_bcQC_n419f,tb_bcQC_i241a,tb_bcQC_w788o,tb_bcQC_z909r,tb_bcQC_h196z,tb_bcQC_a927s,tb_bcQC_m401e,tb_bcQC_a917s,tb_bcQC_q546i,tb_bcQC_e104w,tb_bcQC_f129x,tb_bcQC_x829p,tb_bcQC_r571j,tb_bcQC_v745n,tb_bcQC_s628k,tb_bcQC_z881r,tb_bcQC_d50v,tb_bcQC_m414f,tb_bcQC_m405e,tb_bcQC_x810p,tb_bcQC_k332c,tb_bcQC_bz,tb_bcQC_czrgh,tb_bcQC_qcsh"
        End Select

        Dim dt As DataTable
        sql = sql & sqlbds & "  from " & bm & " where " & bmzd & " between '" & tt1 & "' and '" & tt2 & "'"
        'Debug.Print(sql)
        'Dim sqlbdssep As String = GF_FaceSearchBDS(ComboBoxserchtext, TextBoxserchtext)

        Dim menu1 As ContextMenuStrip = Nothing
        menu1 = New ContextMenuStrip
        menu1.Items.Add("�鿴��ϸ")
        AddHandler menu1.Items(0).Click, AddressOf cl_YanMd.showCkxq

        Dim strWhere As String = "where 1=1 and tb_QcJc_ftime between  '" & tt1 & "' and '" & tt2 & "' "
        Dim strWhere2 As String = ""
        If TextBox1.Text.Trim <> "" Then
            If ComboBox1.Text = "����" Or ComboBox1.Text = "���ϴ���" Or ComboBox1.Text = "��������" Or ComboBox1.Text = "��������" Then
                Dim strTag As String = CType(ComboBox1.Tag, DataTable).Rows(ComboBox1.SelectedIndex)("tTag")
                strWhere &= " and " & strTag & "='" & TextBox1.Text & "'"
            Else
                strWhere &= " and tb_QcJc_ID in (select tb_QcVa_Qcbs from tb_QcVa where tb_QcVa_xmmc='" & ComboBox1.Text _
                    & "' and tb_QcVa_xmva='" & TextBox1.Text.Trim & "')"
            End If
        End If
        'Ҫ���ص���
        dim strHidcol As String=""
        '����¼��Ӧ��QC����¼
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
        '��ӽ�������
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
        GS_StoreLastDo() ' �������һ�β���ʱ��
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

        If namepp = "��������" Or namepp = "�ĺ�����" Or namepp = "�������" Then
            Dim sql As String = ""
            Dim strIdList As String = ListView2.SelectedItems(0).SubItems(0).Text
            Dim nform As New Frtb_n441f
            nform.Labeltb.Text = "tb_p525h"
            nform.Labelid.Text = strIdList
            nform.tb_p525h_num.Text = ListView2.SelectedItems(0).SubItems(2).Text
            nform.tb_p525h_c17u.Text = "0/1��50g"
            nform.ShowDialog()
            showsj()
            Exit Sub
        End If

        Select Case namepp
            Case "ԭ��", "����"
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
                'nform.m_objMyDataCl.setDataTb("tb_i259b", GF_GetListText(ListView2, "tb_i259b_id"))  '�������������ݴ����������
                nform.m_qclx = en_QcLX.��Ʒ
                nform.m_jcb = "tb_i259b"
                nform.m_wlbs = GF_GetListText(ListView2, "tb_i259b_id")
                nform.tb_i259b_c24u.Text = GF_GetListText(ListView2, "tb_i259b_c24u")
                nform.Label8.Text = GF_GetListText(ListView2, "tb_i259b_num")
                nform.ShowDialog()
            Case "BC����"
                Dim nform As New FrWlJc
                nform.m_qclx = en_QcLX.����
                nform.m_jcb = "tb_sc"
                nform.m_wlbs = ListView2.SelectedItems(0).SubItems(0).Text
                nform.m_wpbs = ListView2.SelectedItems(0).SubItems(1).Text
                nform.tb_i259b_c24u.Text = GF_GetListText(ListView2, "tb_gxsz_mc")
                nform.Label8.Text = GF_GetListText(ListView2, "tb_sc_dh")
                nform.ShowDialog()
            Case "BC����Ʒ", "BC��Ʒ"
                Dim nform As New FrWlJc
                nform.m_qclx = en_QcLX.��Ʒ
                nform.m_jcb = "tb_wlph"
                nform.m_wlbs = ListView2.SelectedItems(0).SubItems(0).Text
                nform.m_wpbs = ListView2.SelectedItems(0).SubItems(1).Text
                nform.tb_i259b_c24u.Text = GF_GetListText(ListView2, "tb_wp_pm")
                nform.Label8.Text = GF_GetListText(ListView2, "tb_wlph_wlph")
                nform.ShowDialog()
            Case Else
                Dim nform As New FrWlJc
                nform.m_qclx = en_QcLX.����
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
        ''��֤����
        'MsgBox("")
        If GF_MakeIsSD(bm, choiseid) = False Then
            Exit Sub
        End If

        Dim sql As String = Nothing
        Select Case namepp
            'Case "ԭ��"
            '    If Null2String(ListView3.SelectedRows(0).Cells("tb_t676l_qcsh").Value) = "��" Then
            '        MessageBox.Show("����˵����ݲ�׼�޸ģ�")
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
            'Case "����"
            '    If Null2String(ListView3.SelectedRows(0).Cells("tb_bcQC_qcsh").Value) = "��" Then
            '        MessageBox.Show("����˵����ݲ�׼�޸ģ�")
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
            Case "С��"
                Dim ph1 As String = ListView3.SelectedRows(0).Cells(1).Value
                Dim ss As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_b970t_id from tb_b970t where tb_b970t_qcsh='��' and tb_b970t_num='" & ph1 & "'")
                If ss.Rows.Count = 0 Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_xgqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.tb_y864q_num.Text = ph1
                nform.ShowDialog()
            Case "�й�"
                Dim ph1 As String = ListView3.SelectedRows(0).Cells(1).Value
                Dim ss As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_b959t_id from tb_b959t where tb_b959t_qcsh='��' and tb_b959t_num='" & ph1 & "'")
                If ss.Rows.Count = 0 Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_zgqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.tb_f123x_num.Text = ph1
                nform.ShowDialog()
            Case "���"
                Dim ph1 As String = ListView3.SelectedRows(0).Cells(1).Value
                Dim ss As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_i234a_id from tb_i234a where tb_i234a_qcsh='��' and tb_i234a_num='" & ph1 & "'")
                If ss.Rows.Count = 0 Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_dgqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.tb_q546i_num.Text = ph1
                nform.ShowDialog()
            Case "ø��"
                Dim ph1 As String = ListView3.SelectedRows(0).Cells(1).Value
                Dim ss As DataTable = GF_CreateDataSource(G_cnnstr, "select tb_meijie_id from tb_i234a where tb_meijie_qcsh='��' and tb_meijie_num='" & ph1 & "'")
                If ss.Rows.Count = 0 Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_meijieQC
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.tb_meijie_num.Text = ph1
                nform.ShowDialog()
            Case "ë��"
                If ListView3.SelectedRows(0).Cells(1).Value = "��" Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_fgqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.isxg = True 'ȷ�������޸�
                nform.ShowDialog()
            Case "����"
                If ListView3.SelectedRows(0).Cells(1).Value = "��" Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_jlqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.ShowDialog()
            Case "����"
                If ListView3.SelectedRows(0).Cells(1).Value = "��" Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_donghuaQC
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.ShowDialog()
            Case "�ѳ�"
                If ListView3.SelectedRows(0).Cells(1).Value = "��" Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_tuoxiuQC
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.ShowDialog()
            Case "��Ʒ��"
                If ListView3.SelectedRows(0).Cells(1).Value = "��" Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_cpqc
                nform.Labeltb.Text = bm
                nform.Labelid.Text = choiseid
                nform.ShowDialog()
            Case "һ������", "��������", "�ĺ�����", "�������"
                If ListView3.SelectedRows(0).Cells(1).Value = "��" Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
                    Exit Sub
                End If
                Dim nform As New Frtb_n441f
                nform.Labeltb.Text = "tb_p525h"
                nform.Labelid.Text = choiseid
                nform.tb_p525h_num.Text = ListView3.SelectedRows(0).Cells(3).Value
                'nform.tb_p525h_c17u.Text = "0/1��50g"
                nform.ShowDialog()
            Case "��Ʒ��"
                If ListView3.SelectedRows(0).Cells(2).Value = "��" Then
                    MsgBox("������¼�Ѿ����,�޷��޸Ļ���ɾ��!")
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
        If GF_storelog2("��ѯ��ˮ����¼", "��ѯ��ˮ����¼") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_wsjcjl")
    End Sub

    Private Sub hjMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hjMenuItem.Click
        '''''''''''''''''''''
        If GF_storelog2("��ѯ����΢������", "��ѯ����΢������") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_hjwswjc")
    End Sub
    '�����Ŀ��¼
    Private Sub wjMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wjMenuItem.Click
        '''''''''''''''''''''
        If GF_storelog2("��ѯ�����Ŀ��¼", "��ѯ�����Ŀ��¼") = False Then
            Exit Sub
        End If
        ''''''''''''''''''''''
        showform("tb_wjxmjl")
    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click
        GS_toexcel(ListView3, DateTimePicker1.Text & "��" & DateTimePicker2.Text, Me)
    End Sub
    Private Sub QCelseMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QCelseMenuItem.Click
        showform("tb_elsecheck")
    End Sub
    Private Sub showform(ByVal str As String)
        Dim nform As New Frshowadd
        nform.Text = GF_cnwithen(_D.G_biaoinf, "tb_biaoinf_mc='" & str & "'", 2) '�õ���������˼
        nform.TextBox1.Text = str
        nform.ShowDialog()
    End Sub

    Private Sub ToolHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GS_Help("QC��")
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
    Private Sub ��Ʒ��������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ��Ʒ��������ToolStripMenuItem.Click
        Dim aa As New Frtb_reserved
        aa.ShowDialog()
    End Sub

    Private Sub QC����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QC����ToolStripMenuItem.Click
        Dim aa As New FrQcSz
        aa.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        namepp = "ԭ��"
        bm = "tb_t676l"
        m_jcbNum = -1
        showsj()
    End Sub
    Private Sub ToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        namepp = "����"
        bm = "tb_bcQC"
        m_jcbNum = -1
        showsj()
    End Sub

    Private Sub ����ƷToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ����ƷToolStripMenuItem.Click
        namepp = "BC" & en_wpfl.����Ʒ.ToString()
        bm = "tb_wlph"
        m_jcbNum = -3
        showsj()
    End Sub

    Private Sub ��ƷToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ��ƷToolStripMenuItem.Click
        namepp = "BC" & en_wpfl.��Ʒ.ToString()
        bm = "tb_wlph"
        m_jcbNum = -3
        showsj()
    End Sub
End Class